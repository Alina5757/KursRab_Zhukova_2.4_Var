using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursContracts.BindingModels
{
    public class MaterialBindingModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string GroupMaterials { get; set; }
    }
}
