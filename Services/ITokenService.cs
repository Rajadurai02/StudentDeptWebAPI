using StudentDeptWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDeptWebAPI.Services
{
    public interface ITokenService
    {
        public string CreateUserToken(UserDTO userDTO);
    }
}
