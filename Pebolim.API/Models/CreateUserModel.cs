using System.ComponentModel.DataAnnotations;

namespace Pebolim.API.Models
{
    public class CreateUserModel
    {
        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [Required]
        [StringLength(64)]
        public string PasswordHash { get; set; }

        public CreateUserModel(string username, string passwordHash)
        {
            Username = username;
            PasswordHash = passwordHash;
        }
    }
}
