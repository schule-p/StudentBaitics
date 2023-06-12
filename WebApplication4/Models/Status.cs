using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace WebApplication4.Models
{
    [Table("status")]
    public class Status
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Должность")]
        public string StatusName { get; set; }

        
    }
}

