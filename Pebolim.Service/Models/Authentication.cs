using System.ComponentModel.DataAnnotations;

namespace Pebolim.Service.Models
{
    public class AuthenticationRequest
    {
        [StringLength(100)]
        public string? Username { get; set; }

        [StringLength(64)]
        public string? Password { get; set; }
    }

    public class AuthenticationResponse
    {
        public string? Token { get; set; }
    }

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

    public class GetUserModel : CreateUserModel
    {

        [Key]
        [Required]
        public int Id { get; set; }
        public GetUserModel(int id, string username, string passwordHash) : base(username, passwordHash)
        {
            Id = id;
        }
    }

    public class UpdateUserModel : GetUserModel
    {
        public UpdateUserModel(int id, string username, string passwordHash) : base(id, username, passwordHash)
        {
        }
    }

}
