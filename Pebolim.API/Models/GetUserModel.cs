using System.ComponentModel.DataAnnotations;

namespace Pebolim.API.Models
{
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
}
