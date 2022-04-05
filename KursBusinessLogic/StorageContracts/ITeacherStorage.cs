using KursContracts.BindingModels;
using KursContracts.ViewModels;
using System.Collections.Generic;

namespace KursContracts.StorageContracts
{
    public interface ITeacherStorage
    {
        List<TeacherViewModel> GetFullList();

        List<TeacherViewModel> GetFilteredList(TeacherBindingModel model);

        TeacherViewModel GetElement(TeacherBindingModel model);

        void Insert(TeacherBindingModel model);

        void Update(TeacherBindingModel model);

        void Delete(TeacherBindingModel model);
    }
}
