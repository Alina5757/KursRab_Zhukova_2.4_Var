using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KursModels.Models
{
    public class Material
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string GroupMaterials { get; set; }

        //Connection
        [ForeignKey("MaterialId")]
        public List<MMMaterialTask> MaterialTasks { get; set; }

        [ForeignKey("MaterialId")]
        public List<MMMaterialClass> MaterialClasses { get; set; }
    }
}
