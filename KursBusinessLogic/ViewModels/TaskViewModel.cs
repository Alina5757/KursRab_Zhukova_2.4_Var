using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace KursContracts.ViewModels
{
    public class TaskViewModel
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }

        [DisplayName("Задание выдано")]
        public DateTime DateCreate { get; set; }

        [DisplayName("Дата сдачи")]
        public DateTime DateComplete { get; set; }

        [DisplayName("Название")]
        public string Name { get; set; }

        public Dictionary<int, (string, int)> Materials { get; set; }
    }
}
