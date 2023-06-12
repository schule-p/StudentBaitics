using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace WebApplication4.Models
{
    [Table("storage")]
    public class Storage
    {
        [Key, Required]
        public int Id { get; set; }

        
        [Display(Name = "Имя склада")]
        public string StorageName { get; set; }

        [Required]
        [Display(Name = "Адресс склада")]
        public string StorageAdress { get; set; }


    }
}

