using StudentDeptWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StudentDeptWebAPI.Services
{
    public class UserService
    {
        private readonly StudentDeptContext _context;
        private readonly ITokenService _tokenService;

        public UserService(StudentDeptContext context,ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public UserDTO Register(UserDTO userDTO)
        {
            try
            {
                if (string.IsNullOrEmpty(userDTO.Email))
                {
                    return null;
                }
                else
                {
                    using var hmac = new HMACSHA512();
                    var user = new User()
                    {
                        Email = userDTO.Email,
                        Name = userDTO.Name,
                        PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password)),
                        PasswordSalt = hmac.Key

                    };

                    _context.Users.Add(user);
                    _context.SaveChanges();
                    userDTO.JwtToken = _tokenService.CreateUserToken(userDTO);
                    userDTO.Password = "";
                    return userDTO;
                }                
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return null;
        }
        public UserDTO Login(UserDTO userDTO)
        {
            try
            {
                var myUser = _context.Users.SingleOrDefault(u => u.Email == userDTO.Email);
                if (myUser != null)
                {
                    using var hmac = new HMACSHA512(myUser.PasswordSalt);
                    var userPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));

                    for (int i = 0; i < userPassword.Length; i++)
                    {
                        if (userPassword[i] != myUser.PasswordHash[i])
                            return null;
                    }
                    userDTO.JwtToken = _tokenService.CreateUserToken(userDTO);
                    userDTO.Password = "";
                    userDTO.Name = myUser.Name;
                    return userDTO;
                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return null;
        }
    }
}
