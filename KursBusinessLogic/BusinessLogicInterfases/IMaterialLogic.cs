using KursContracts.BindingModels;
using KursContracts.ViewModels;
using System.Collections.Generic;

namespace KursContracts.BusinessLogicInterfases
{
    public interface IMaterialLogic
    {
        List<MaterialViewModel> Read(MaterialBindingModel model);

        void CreateOrUpdate(MaterialBindingModel model);

        void Delete(MaterialBindingModel model);        
    }
}
