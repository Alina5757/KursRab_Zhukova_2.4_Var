using System.ComponentModel.DataAnnotations;

namespace KursModels.Models
{
    public class MMMaterialTask
    {
        public int Id { get; set; }

        [Required]
        public int MaterialId { get; set; }

        [Required]
        public int? TaskId { get; set; }

        [Required]
        public int Count { get; set; }

        //Connection
        public virtual Material Material { get; set; }

        public virtual Task Task { get; set; }
    }
}
