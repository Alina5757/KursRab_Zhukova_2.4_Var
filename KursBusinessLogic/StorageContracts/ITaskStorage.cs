using KursContracts.BindingModels;
using KursContracts.ViewModels;
using System.Collections.Generic;

namespace KursContracts.StorageContracts
{
    public interface ITaskStorage
    {
        List<TaskViewModel> GetFullList();

        List<TaskViewModel> GetFilteredList(TaskBindingModel model);

        TaskViewModel GetElement(TaskBindingModel model);

        void Insert(TaskBindingModel model);

        void Update(TaskBindingModel model);

        void Delete(TaskBindingModel model);
    }
}
