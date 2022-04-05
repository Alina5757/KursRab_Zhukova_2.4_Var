using KursContracts.BindingModels;
using KursContracts.ViewModels;
using System.Collections.Generic;

namespace KursContracts.BusinessLogicInterfases
{
    public interface IClassLogic
    {
        List<ClassViewModel> Read(ClassBindingModel model);

        void CreateOrUpdate(ClassBindingModel model);

        void Delete(ClassBindingModel model);
    }
}
