using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursContracts.ViewModels
{
    public class CraftDViewModel
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int StudentId { get; set; }

        [DisplayName("Название поделки")]
        public string Name { get; set; }

        [DisplayName("Задание")]
        public int TaskName { get; set; }

        [DisplayName("Ученик")]
        public int StudentName { get; set; }
    }
}
