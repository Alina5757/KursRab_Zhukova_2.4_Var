using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KursModels.Models
{
    public class InterestD
    {
        public int Id { get; set; }

        [Required]
        public string Thema { get; set; }

        //Connection
        [ForeignKey("InteresId")]
        public virtual List<MMInteresCraft> InteresCrafts { get; set; }

        [ForeignKey("InteresId")]
        public virtual List<MMInteresStudent> InteresStudents { get; set; }

        [ForeignKey("InteresId")]
        public virtual List<MMInteresProduct> InteresProducts { get; set; }
    }
}
