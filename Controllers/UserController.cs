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
    public class UserController : ControllerBase
    {
        private readonly UserService _service;
        public UserController(UserService service)
        {
            _service = service;
        }
        
        [Route("Register")]
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Register([FromBody] UserDTO user)
        {
            UserDTO registeredUser = _service.Register(user);
            if(registeredUser != null)
            {
                return registeredUser;
            }
            else
            {
                return BadRequest("Registration Failed");
            }
        }

        [Route("Login")]
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Login([FromBody] UserDTO user)
        {
            UserDTO registeredUser = _service.Login(user);
            if (registeredUser != null)
            {
                return registeredUser;
            }
            else
            {
                return BadRequest("Login Failed");
            }
        }

    }
}
