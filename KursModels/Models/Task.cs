using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KursModels.Models
{
    public class Task
    {
        public int Id { get; set; }

        [Required]
        public DateTime DateCreate { get; set; }

        [Required]
        public DateTime DateComplete { get; set; }

        [Required]
        public string Name { get; set; }

        public int TeacherId { get; set; }

        //Connection
        public virtual Teacher Teacher { get; set; }

        [ForeignKey("TaskId")]
        public List<MMMaterialTask> MaterialTasks { get; set; }

        [ForeignKey("TaskId")]
        public List<CraftD> Crafts { get; set; }
    }
}
