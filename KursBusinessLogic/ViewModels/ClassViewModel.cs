using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursContracts.ViewModels
{
    public class ClassViewModel
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }

        [DisplayName("Номер занятия")]
        public int Number { get; set; }

        [DisplayName("Тема занятия")]
        public string Theme { get; set; }

        [DisplayName("Дата проведения")]
        public DateTime Date { get; set; }

        [DisplayName("Преподаватель")]
        public string TeacherName { get; set; }
    }
}
