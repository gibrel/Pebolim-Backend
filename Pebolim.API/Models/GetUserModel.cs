using System.ComponentModel.DataAnnotations;

namespace Pebolim.API.Models
{
    public class GetUserModel : CreateUserModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
    }
}
