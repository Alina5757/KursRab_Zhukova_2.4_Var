using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursContracts.BindingModels
{
    public class TaskBindingModel
    {
        public int? Id { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateComplete { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public Dictionary<int, (string, int)> Materials { get; set; }
    }
}
