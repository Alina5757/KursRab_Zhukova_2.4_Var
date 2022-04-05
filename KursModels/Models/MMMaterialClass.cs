using System.ComponentModel.DataAnnotations;

namespace KursModels.Models
{
    public class MMMaterialClass
    {
        public int Id { get; set; }

        [Required]
        public int MaterialId { get; set; }

        [Required]
        public int? ClassId { get; set; }

        [Required]
        public int Count { get; set; }

        //Connection
        public virtual Material Material { get; set; }

        public virtual Class Class { get; set; }
    }
}
