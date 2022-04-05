using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KursModels.Models
{
    public class Class
    {
        public int Id { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public string Theme { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public int TeacherId { get; set; }

        //Connection
        public virtual Teacher Teacher { get; set; }

        [ForeignKey("ClassId")]
        public virtual List<MMClassProduct> ClassProducts { get; set; }

        [ForeignKey("ClassId")]
        public virtual List<MMMaterialClass> MaterialClasses { get; set; }
    }
}
