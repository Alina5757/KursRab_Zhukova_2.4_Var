using KursContracts.BindingModels;
using KursContracts.ViewModels;
using System.Collections.Generic;

namespace KursContracts.StorageContracts
{
    public interface IClassStorage
    {
        List<ClassViewModel> GetFullList();

        List<ClassViewModel> GetFilteredList(ClassBindingModel model);

        ClassViewModel GetElement(ClassBindingModel model);

        void Insert(ClassBindingModel model);

        void Update(ClassBindingModel model);

        void Delete(ClassBindingModel model);
    }
}
