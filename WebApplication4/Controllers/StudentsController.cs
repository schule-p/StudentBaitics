using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using WebApplication4.Data;
using WebApplication4.Domain;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [Route("/api/Students")]
    public class StudentsController : Controller
    {
        //private readonly DBHelper _db;
        private readonly StudentRepository studentRepository;
        public StudentsController(StudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(studentRepository.GetStudents());
        }



    }

        
}
