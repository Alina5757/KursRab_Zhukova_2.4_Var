using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace KursModels.Models
{
    public class StudentD
    {
        public int Id { get; set; }

        [Required]
        public string FIO { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Email { get; set; }

        //Connection
        [ForeignKey("StudentId")]
        public virtual List<CraftD> Crafts { get; set; }

        [ForeignKey("StudentId")]
        public virtual List<MMInteresStudent> InteresStudents { get; set; }

        [ForeignKey("StudentId")]
        public virtual List<ProductD> Products { get; set; }
    }
}
