using KursContracts.BindingModels;
using KursContracts.ViewModels;
using System.Collections.Generic;

namespace KursContracts.BusinessLogicInterfases
{
    public interface ITeacherLogic
    {
        List<TeacherViewModel> Read(TeacherBindingModel model);

        void Create(TeacherBindingModel model);

        TeacherViewModel Enter(TeacherBindingModel model);

        void Update(TeacherBindingModel model);

        void Delete(TeacherBindingModel model);
    }
}
