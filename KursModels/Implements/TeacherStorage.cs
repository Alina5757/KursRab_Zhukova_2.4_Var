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
    public class TeacherStorage : ITeacherStorage
    {
        public List<TeacherViewModel> GetFullList()
        {
            using var context = new KursDataBase();
            return context.Teachers
                .Select(CreateModel)
                .ToList();
        }

        public List<TeacherViewModel> GetFilteredList(TeacherBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new KursDataBase();
            return context.Teachers
                .Where(rec => rec.Id.Equals(model.Id))
                .Select(CreateModel)
                .ToList();
        }

        public TeacherViewModel GetElement(TeacherBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new KursDataBase();
            var teacher = context.Teachers
            .FirstOrDefault(rec => rec.Login == model.Login && rec.Password == model.Password);
            return teacher != null ? CreateModel(teacher) : null;
        }

        public void Insert(TeacherBindingModel model)
        {
            using var context = new KursDataBase();
            context.Teachers.Add(CreateModel(model, new Teacher()));
            context.SaveChanges();
        }

        public void Update(TeacherBindingModel model)
        {
            using var context = new KursDataBase();
            var element = context.Teachers.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
            context.SaveChanges();
        }

        public void Delete(TeacherBindingModel model)
        {
            using var context = new KursDataBase();
            Teacher element = context.Teachers.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Teachers.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        private static Teacher CreateModel(TeacherBindingModel model, Teacher teacher)
        {
            teacher.Login = model.Login;
            teacher.FIO = model.FIO;
            teacher.Email = model.Email;
            teacher.Password = model.Password;
            return teacher;
        }

        private static TeacherViewModel CreateModel(Teacher teacher)
        {
            return new TeacherViewModel
            {
                Id = teacher.Id,
                Login = teacher.Login,
                FIO = teacher.FIO,
                Email = teacher.Email,
                Password = teacher.Password
            };
        }
    }
}
