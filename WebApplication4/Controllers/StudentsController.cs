using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Data.Entity;
using WebApplication4.Data;
using WebApplication4.Domain;
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
        
        [HttpGet]
        public IActionResult GetStudents()
        {
            var x = _context.Students.ToList();

            return Ok(x);
        }

    }

        
}
