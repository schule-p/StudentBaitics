using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Data.Entity;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : Controller
    {
        
        private readonly AppDbContext _context;
        public StudentsController(AppDbContext context)
            
        {
            this._context = context;
        }

        //Генерация уникального Id
        private int NextUniId => _context.Students.Count() == 0 ? 1 : _context.Students.Max(p => p.Id) + 1;

        [HttpGet]
        public IActionResult GetStudents()
        {
            var x = _context.Students.ToList();

            return Ok(x);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(Models.Student studentRequest)
        {
            var student = new Models.Student()
            {
                //Id = Guid.NewGuid(),
                Id = NextUniId,
                StudentName = studentRequest.StudentName,
                Points = studentRequest.Points,
                LastDateUpdatePoints = studentRequest.LastDateUpdatePoints

            };
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return Ok(student);
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> DeleteStudent(int Id)
        {
            var student = await _context.Students.FindAsync(Id);
            if (student != null) 
            {
                _context.Remove(student);
                await _context.SaveChangesAsync();
                return Ok(student);
            }
            return NotFound();
        }

        [HttpPut]
        [Route("{Id}")]

        public async Task<IActionResult> UpdateStudent(int Id, Models.Student studentRequest)
        {
            var student = await _context.Students.FindAsync(Id);

            if (student != null)
            {

                student.StudentName = studentRequest.StudentName;
                student.Points = studentRequest.Points;
                student.LastDateUpdatePoints = studentRequest.LastDateUpdatePoints;

                await _context.SaveChangesAsync();

                return Ok(student);
            }
            return NotFound();
        }


    }


}
