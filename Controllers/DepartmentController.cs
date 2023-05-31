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
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentService _service;
        public DepartmentController(DepartmentService service)
        {
            _service = service;
        }
        // GET: api/<DepartmentController>
        [HttpGet]
        public async Task<IEnumerable<Department>> Get()
        {
            return _service.GetAllDepartments();
        }

        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        public async Task<Department> Get(int id)
        {
            return _service.GetDepartmentByID(id);
        }

        // POST api/<DepartmentController>
        [HttpPost]
        public async Task<Department> Post([FromBody] Department department)
        {
            return _service.AddDepartment(department);
        }

        // PUT api/<DepartmentController>/5
        [HttpPut]
        public async Task<Department> Put([FromBody] Department department)
        {
            return _service.EditDepartment(department);
        }

        // DELETE api/<DepartmentController>/5
        [HttpDelete("{id}")]
        public async Task<Department> Delete(int id)
        {
            return _service.RemoveDepartment(id);
        }
    }
}
