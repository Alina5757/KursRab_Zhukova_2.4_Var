using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KursModels.Models
{
    public class CraftD
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int TaskId { get; set; }

        public int StudentId { get; set; }

        //Connection
        public virtual Task Task { get; set; }

        public virtual StudentD Student { get; set; }

        [ForeignKey("CraftId")]
        public virtual List<MMInteresCraft> InteresCrafts { get; set; }
    }
}
