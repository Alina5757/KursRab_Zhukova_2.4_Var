using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursContracts.BindingModels
{
    public class ProductDBindingModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public Dictionary<int, (string, int)> Interests { get; set; }
    }
}
