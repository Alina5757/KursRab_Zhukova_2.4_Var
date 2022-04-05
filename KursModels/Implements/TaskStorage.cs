using KursContracts.BindingModels;
using KursContracts.StorageContracts;
using KursContracts.ViewModels;
using KursModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KursModels.Implements
{
    public class TaskStorage : ITaskStorage
    {
        public List<TaskViewModel> GetFullList()
        {
            using var context = new KursDataBase();
            return context.Tasks
                .Include(rec => rec.MaterialTasks)
                .ThenInclude(rec => rec.Material)
                .ToList()
                .Select(CreateModel)
                .ToList();
        }

        public List<TaskViewModel> GetFilteredList(TaskBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new KursDataBase();
            return context.Tasks
                .Include(rec => rec.MaterialTasks)
                .ThenInclude(rec => rec.Material)
                .Where(rec => rec.Name.Equals(model.Name))
                .ToList()
                .Select(CreateModel)
                .ToList();
        }

        public TaskViewModel GetElement(TaskBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using var context = new KursDataBase();
            var task = context.Tasks
                .Include(rec => rec.MaterialTasks)
                .ThenInclude(rec => rec.Material)
                .FirstOrDefault(rec => rec.Id == model.Id);

            return task != null ? CreateModel(task) : null;
        }

        public void Insert(TaskBindingModel model)
        {
            using var context = new KursDataBase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                Task task_to_add = CreateModel(model, new Task());
                context.Tasks.Add(task_to_add);
                context.SaveChanges();

                foreach (var material in model.Materials)
                {
                    context.MaterialTasks.Add(new MMMaterialTask
                    {
                        MaterialId = material.Key,
                        TaskId = task_to_add.Id,
                        Count = material.Value.Item2
                    });
                    context.SaveChanges();
                }

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Update(TaskBindingModel model)
        {
            using var context = new KursDataBase();
            var element = context.Tasks.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Задание не найдено");
            }
            CreateModel(model, element);
            context.SaveChanges();
        }

        public void Delete(TaskBindingModel model)
        {
            using var context = new KursDataBase();
            Task element = context.Tasks.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Tasks.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Задание не найдено");
            }
        }

        private static Task CreateModel(TaskBindingModel model, Task task)
        {
            task.Name = model.Name;
            task.TeacherId = model.TeacherId;
            task.DateCreate = model.DateCreate;
            task.DateComplete = model.DateComplete;

            using var context = new KursDataBase();
            if (model.Id.HasValue)
            {
                var NeedMaterials = context.MaterialTasks.Where(rec => rec.TaskId == model.Id.Value).ToList();

                context.MaterialTasks.RemoveRange(NeedMaterials.Where(rec => !model.Materials.ContainsKey(rec.MaterialId)).ToList());
                context.SaveChanges();

                foreach(var newmaterial in NeedMaterials)
                {
                    newmaterial.Count = model.Materials[newmaterial.MaterialId].Item2;
                    model.Materials.Remove(newmaterial.MaterialId);
                }
                context.SaveChanges();

                foreach (var material in model.Materials)
                {
                    context.MaterialTasks.Add(new MMMaterialTask
                    {
                        MaterialId = material.Key,
                        TaskId = model.Id,
                        Count = material.Value.Item2
                    });
                    context.SaveChanges();
                }
            }
            return task;
        }
        private static TaskViewModel CreateModel(Task task)
        {
            return new TaskViewModel
            {
                Id = task.Id,
                Name = task.Name,
                TeacherId = task.TeacherId,
                DateCreate = task.DateCreate,
                DateComplete = task.DateComplete,
                Materials = task.MaterialTasks.ToDictionary(rec => rec.MaterialId, rec => (rec.Material?.Name, rec.Count))
            };
        }
    }
}