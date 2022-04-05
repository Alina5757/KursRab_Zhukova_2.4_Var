using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KursModels.Models
{
    public class ProductD
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int StudentId { get; set; }

        //Connection
        public virtual StudentD Student { get; set; }

        [ForeignKey("ProductId")]
        public virtual List<MMInteresProduct> InteresProducts { get; set; }

        [ForeignKey("ProductId")]
        public virtual List<MMClassProduct> ClassProducts { get; set; }
    }
}
