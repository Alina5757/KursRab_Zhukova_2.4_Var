using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursContracts.BindingModels
{
    public class ClassBindingModel
    {
        public int? Id { get; set; }
        public int Number { get; set; }
        public string Theme { get; set; }
        public int TeacherId { get; set; }
        public DateTime Date { get; set; }
        public Dictionary<int, (string, int)> Materials { get; set; }
    }
}
