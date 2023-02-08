using Microsoft.AspNetCore.Mvc.Infrastructure;
using WebApplication4.Data;
using WebApplication4.Models;
namespace WebApplication4.Domain
{
    public class StudentRepository
    {
        private readonly AppDbContext context;
        //private AppDbContext context;

        public StudentRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable <Student> GetStudents()
        {
            return (IQueryable<Student>)context.students.OrderBy(keySelector: x => x.StudentName);
        }

    }
}
