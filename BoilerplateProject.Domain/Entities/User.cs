using System.ComponentModel.DataAnnotations;

namespace Pebolim.Domain.Entities
{
    public class User : BaseEntity
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string Salt { get; set; }
    }
}
