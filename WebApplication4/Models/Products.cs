using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace WebApplication4.Models
{
    [Table("products")]
    public class Products
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Название товара")]
        public string ProductName { get; set; }
        [Display(Name = "Изображение")]
        public string Img { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }

        

    }
}
