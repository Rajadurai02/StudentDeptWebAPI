using System.ComponentModel.DataAnnotations;

namespace StudentDeptWebAPI.Models
{
    public class User
    {
        [Key]
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Name { get; set; }
    }
}
