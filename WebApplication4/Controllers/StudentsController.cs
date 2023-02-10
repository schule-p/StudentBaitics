using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using NpgsqlTypes;
using System.Collections;
using System.Data.Entity;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("/api/Student")]
    public class StudentsController : Controller
    {
        
        private readonly AppDbContext _context;
        public StudentsController(AppDbContext context)
            
        {
            this._context = context;
        }

        //Генерация уникального Id
        private int NextUniId => _context.Students.Count() == 0 ? 1 : _context.Students.Max(p => p.Id) + 1;

        [HttpGet("GetStudents")]
        public IActionResult GetStudents()
        {
            var x = _context.Students.ToList();
            var y = _context.Students;

            return Ok(x);
        }

        

        [HttpGet("{Id}")]
        public IActionResult GetStudents(int Id)
        {
            var student = _context.Students.FirstOrDefault(x => x.Id == Id);
            if (student == null)
                return NotFound();
            
            return Ok(student);
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
        [Route("/api/Student/UpdateStudent/{Id}")]
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


        [HttpPut("Plus10PointsStudent")]
        
        public async Task<IActionResult> Plus10PointsStudent(int Id, Models.Student studentRequest)
        {
            var student = _context.Students.FirstOrDefault(x => x.Id == Id);

            if (student != null)
            {

                var x = student.Points;
                student.Points = Convert.ToUInt16(x + 10);


                await _context.SaveChangesAsync();

                return Ok(student);
            }
            return NotFound();
        }


        [HttpPut("Minus10PointsStudent")]
        
        public async Task<IActionResult> Minus10PointsStudent(int Id, Models.Student studentRequest)
        {
            var student = _context.Students.FirstOrDefault(x => x.Id == Id);

            if (student != null)
            {

                var x = student.Points;
                student.Points = Convert.ToUInt16(x - 10);


                await _context.SaveChangesAsync();

                return Ok(student);
            }
            return NotFound();
        }



    }


}
