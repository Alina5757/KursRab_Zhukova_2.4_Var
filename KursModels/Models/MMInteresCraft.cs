using System.ComponentModel.DataAnnotations;

namespace KursModels.Models
{
    public class MMInteresCraft
    {
        public int Id { get; set; }

        [Required]
        public int InteresId { get; set; }

        [Required]
        public int CraftId { get; set; }

        //Connection
        public virtual InterestD Interes { get; set; }

        public virtual CraftD Craft { get; set; }
    }
}
