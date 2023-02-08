using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebApplication4.Models
{
    public class AddStudentRequest
    {
        
        
        public string StudentName { get; set; }
       
        public ushort Points { get; set; }
        
        public DateTime LastDateUpdatePoints { get; set; }
    }
}
