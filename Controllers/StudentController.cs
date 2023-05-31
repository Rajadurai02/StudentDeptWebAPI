using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using StudentDeptWebAPI.Models;
using StudentDeptWebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentDeptWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("Policy")]
    //[Authorize]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _service;

        public StudentController(StudentService service)
        {
            _service = service;
        }
        // GET: api/<StudentController>
        [HttpGet]
        public async Task<IEnumerable<Student>> Get()
        {
            return _service.GetAllStudents();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public async Task<Student> Get(int id)
        {
           return _service.GetStudentByID(id);
        }

        // POST api/<StudentController>
        [HttpPost]
        public async Task<Student> Post([FromBody] Student student)
        {
            return _service.AddStudent(student);
        }

        // PUT api/<StudentController>/5
        [HttpPut]
        public async Task<Student> Put([FromBody] Student student)
        {
            return _service.EditStudent(student);
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public async Task<Student> Delete(int id)
        {
            return _service.RemoveStudent(id);
        }
    }
}
