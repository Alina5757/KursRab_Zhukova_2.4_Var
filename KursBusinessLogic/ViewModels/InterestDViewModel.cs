using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursContracts.ViewModels
{
    public class InterestDViewModel
    {
        public int Id { get; set; }

        [DisplayName("Тема")]
        public string Thema { get; set; }
    }
}
