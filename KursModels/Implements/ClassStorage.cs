using KursContracts.BindingModels;
using KursContracts.StorageContracts;
using KursContracts.ViewModels;
using KursModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KursModels.Implements
{
    public class ClassStorage : IClassStorage
    {
        public List<ClassViewModel> GetFullList()
        {
            using var context = new KursDataBase();
            return context.Classes
                .Select(CreateModel)
                .ToList();
        }

        public List<ClassViewModel> GetFilteredList(ClassBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new KursDataBase();
            return context.Classes
                .Where(rec => rec.Date.Equals(model.Date))
                .Select(CreateModel)
                .ToList();
        }

        public ClassViewModel GetElement(ClassBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using var context = new KursDataBase();
            var clss = context.Classes
                .FirstOrDefault(rec => rec.Id == model.Id);

            return clss != null ? CreateModel(clss) : null;
        }

        public void Insert(ClassBindingModel model)
        {
            using var context = new KursDataBase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                Class class_to_add = CreateModel(model, new Class());
                context.Classes.Add(class_to_add);
                context.SaveChanges();

                foreach (var material in model.Materials)
                {
                    context.MaterialClasses.Add(new MMMaterialClass
                    {
                        MaterialId = material.Key,
                        ClassId = class_to_add.Id,
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

        public void Update(ClassBindingModel model)
        {
            using var context = new KursDataBase();
            var element = context.Classes.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Занятие не найдено");
            }
            CreateModel(model, element);
            context.SaveChanges();
        }

        public void Delete(ClassBindingModel model)
        {
            using var context = new KursDataBase();
            Class element = context.Classes.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Classes.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Занятие не найдено");
            }
        }

        private static Class CreateModel(ClassBindingModel model, Class clss)
        {
            clss.Number = model.Number;
            clss.Theme = model.Theme;
            clss.Date = model.Date;
            clss.TeacherId = model.TeacherId;

            using var context = new KursDataBase();
            if (model.Id.HasValue)
            {
                var NeedMaterials = context.MaterialClasses.Where(rec => rec.ClassId == model.Id.Value).ToList();

                context.MaterialClasses.RemoveRange(NeedMaterials.Where(rec => !model.Materials.ContainsKey(rec.MaterialId)).ToList());
                context.SaveChanges();

                foreach (var newmaterial in NeedMaterials)
                {
                    newmaterial.Count = model.Materials[newmaterial.MaterialId].Item2;
                    model.Materials.Remove(newmaterial.MaterialId);
                }
                context.SaveChanges();

                foreach (var material in model.Materials)
                {
                    context.MaterialClasses.Add(new MMMaterialClass
                    {
                        MaterialId = material.Key,
                        ClassId = model.Id,
                        Count = material.Value.Item2
                    });
                    context.SaveChanges();
                }
            }
            return clss;
        }
        private static ClassViewModel CreateModel(Class clss)
        {
            using var context = new KursDataBase();
            return new ClassViewModel
            {
                Id = clss.Id,
                Number = clss.Number,
                Theme = clss.Theme,
                TeacherId = clss.TeacherId,
                Date = clss.Date,
                TeacherName = context.Teachers.FirstOrDefault(rec => rec.Id == clss.TeacherId).FIO
            };
        }
    }
}
