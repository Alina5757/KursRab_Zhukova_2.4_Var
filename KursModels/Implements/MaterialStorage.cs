using KursContracts.BindingModels;
using KursContracts.StorageContracts;
using KursContracts.ViewModels;
using KursModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KursModels.Implements
{
    public class MaterialStorage : IMaterialStorage
    {
        public List<MaterialViewModel> GetFullList()
        {
            using var context = new KursDataBase();
            return context.Materials
                .Select(CreateModel)
                .ToList();
        }

        public List<MaterialViewModel> GetFilteredList(MaterialBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new KursDataBase();
            return context.Materials
                .Where(rec => rec.Name.Equals(model.Name))
                .Select(CreateModel)
                .ToList();
        }

        public MaterialViewModel GetElement(MaterialBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using var context = new KursDataBase();
            var component = context.Materials
                .FirstOrDefault(rec => rec.Name == model.Name ||
                rec.Id == model.Id);

            return component != null ? CreateModel(component) : null;
        }

        public void Insert(MaterialBindingModel model)
        {
            using var context = new KursDataBase();
            context.Materials.Add(CreateModel(model, new Material()));
            context.SaveChanges();
        }

        public void Update(MaterialBindingModel model)
        {
            using var context = new KursDataBase();
            var element = context.Materials.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Материал не найден");
            }
            CreateModel(model, element);
            context.SaveChanges();
        }

        public void Delete(MaterialBindingModel model)
        {
            using var context = new KursDataBase();
            Material element = context.Materials.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Materials.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Материал не найден");
            }
        }

        private static Material CreateModel(MaterialBindingModel model, Material material)
        {
            material.Name = model.Name;
            material.GroupMaterials = model.GroupMaterials;
            return material;
        }
        private static MaterialViewModel CreateModel(Material material)
        {
            return new MaterialViewModel
            {
                Id = material.Id,
                Name = material.Name,
                GroupMaterials = material.GroupMaterials
            };
        }
    }
}
