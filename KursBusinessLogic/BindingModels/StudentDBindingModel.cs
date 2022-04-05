using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursContracts.BindingModels
{
    public class StudentDBindingModel
    {
        public int? Id { get; set; }
        public string FIO { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
    }
}
