using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace WebApplication4.Models
{
    [Table("products_storage")]
    public class Products_storage
    {
        [Key, Required]
        public int Id { get; set; }


        [ForeignKey("IdProducts")]
        public int IdProducts { get; set; }
        public Products? Products { get; set; }

        [ForeignKey("IdStorage")]
        public int IdStorage { get; set; }
        public Storage? Storage { get; set; }

        [Required]
        [Display(Name = "Количество")]
        public string ProductsCount { get; set; }


    }
}

