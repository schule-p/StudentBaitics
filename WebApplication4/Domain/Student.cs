using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Domain
{
    [Table("students")]
    public class Student
    {
        
            [Key, Required]
            public int Id { get; set; }
            [Required]
            [Display(Name ="Имя студента")]    
            public string StudentName { get; set; }
            [Display(Name = "Баллы")]
            public ushort Points { get; set; }
            [Display(Name = "Последнее обновление")]
            public DateTime LastDateUpdatePoints { get; set; }
        
    }
}
