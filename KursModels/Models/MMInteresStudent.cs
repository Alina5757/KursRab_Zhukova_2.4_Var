using System.ComponentModel.DataAnnotations;

namespace KursModels.Models
{
    public class MMInteresStudent
    {
        public int Id { get; set; }

        [Required]
        public int InteresId { get; set; }

        [Required]
        public int StudentId { get; set; }

        //Connection
        public virtual InterestD Interes { get; set; }

        public virtual StudentD Student { get; set; }
    }
}
