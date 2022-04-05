using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KursModels.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string FIO { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Email { get; set; }

        //Connection
        [ForeignKey("TeacherId")]
        public virtual List<Class> Classes { get; set; }

        [ForeignKey("TeacherId")]
        public virtual List<Task> Tasks { get; set; }
    }
}
