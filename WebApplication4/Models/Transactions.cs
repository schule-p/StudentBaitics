using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace WebApplication4.Models
{
    [Table("transaсtions")]
    public class Transactions
    {
        [Key, Required]
        public int Id { get; set; }

        

        [Display(Name = "Сумма транзакции")]
        public int Sum { get; set; }

        [Display(Name = "Тип транзакции")]
        public Boolean TypeOfTransaction { get; set; }

        [Display(Name = "Время")]
        public DateTime DateTransartion { get; set; }


        [Display(Name = "Id Студента")]
        [ForeignKey("IdStudent")]
        public int IdStudent { get; set; }
        public Student? Student { get; set; }

    }
}
