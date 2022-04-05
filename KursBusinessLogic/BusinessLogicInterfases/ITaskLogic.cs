using KursContracts.BindingModels;
using KursContracts.ViewModels;
using System.Collections.Generic;

namespace KursContracts.BusinessLogicInterfases
{
    public interface ITaskLogic
    {
        List<TaskViewModel> Read(TaskBindingModel model);

        void CreateOrUpdate(TaskBindingModel model);

        void Delete(TaskBindingModel model);
    }
}
