using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursContracts.ViewModels
{
    public class ProductDViewModel
    {
        public int Id { get; set; }
        public int StudentId { get; set; }

        [DisplayName("Название")]
        public string Name { get; set; }
        [DisplayName("Ученик")]
        public int StudentName { get; set; }
    }
}
