using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace WebApplication4.Models
{
    [Table("academicBuilding")]
    public class AcademicBuilding
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Название учебного корпуса")]
        public string NameAcademicBuilding { get; set; }

        [Display(Name = "Адресс учебного корпуса")]
        public string AdressAcademicBuilding { get; set; }
    }
}

