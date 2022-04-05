using System.ComponentModel.DataAnnotations;

namespace KursModels.Models
{
    public class MMInteresProduct
    {
        public int Id { get; set; }

        [Required]
        public int InteresId { get; set; }

        [Required]
        public int ProductId { get; set; }

        //Connection
        public virtual InterestD Interes { get; set; }

        public virtual ProductD Product { get; set; }
    }
}
