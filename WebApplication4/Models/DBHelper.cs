using System.ComponentModel.DataAnnotations;
using WebApplication4.Data;

namespace WebApplication4.Models
{
    public class DBHelper
    {
        private AppDbContext _context;
        public DBHelper(AppDbContext context)
        {
            _context = context;
        }

        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            var DataList = _context.students.ToList();
            DataList.ForEach(row => students.Add(new Student()
            {
                Id = row.Id,
                StudentName = row.StudentName,
                Points = row.Points,
                LastDateUpdatePoints = row.LastDateUpdatePoints


            }));
            return students;
        }

        public void AddStudent (Student student)
        {
            Student dbTable = new Student();

            dbTable = _context.students.Where(d => d.Id.Equals(student.Id)).FirstOrDefault();
            
            dbTable.StudentName = student.StudentName;
            dbTable.Points = student.Points;
            dbTable.LastDateUpdatePoints = student.LastDateUpdatePoints;
            _context.students.Add(dbTable);
            _context.SaveChanges();
        }
        
    }
}
