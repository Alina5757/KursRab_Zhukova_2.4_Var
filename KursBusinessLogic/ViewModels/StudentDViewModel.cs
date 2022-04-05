using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursContracts.ViewModels
{
    public class StudentDViewModel
    {
        public int Id { get; set; }

        [DisplayName("ФИО")]
        public string FIO { get; set; }

        [DisplayName("Логин")]
        public string Login { get; set; }

        [DisplayName("Почта")]
        public string Email { get; set; }
    }
}
