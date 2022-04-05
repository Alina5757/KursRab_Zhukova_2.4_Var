using System.ComponentModel.DataAnnotations;

namespace KursModels.Models
{
    public class MMClassProduct
    {
        public int Id { get; set; }

        [Required]
        public int ClassId { get; set; }

        [Required]
        public int ProductId { get; set; }

        //Connection
        public virtual Class Class { get; set; }

        public virtual ProductD Product { get; set; }
    }
}
