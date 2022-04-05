using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursContracts.ViewModels
{
    public class TeacherViewModel
    {
        public int Id { get; set; }
        public string Password { get; set; }

        [DisplayName("Преподаватель")]
        public string FIO { get; set; }

        [DisplayName("Логин")]
        public string Login { get; set; }

        [DisplayName("Почта")]
        public string Email { get; set; }
    }
}
