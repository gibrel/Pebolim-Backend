using System.ComponentModel.DataAnnotations;

namespace Pebolim.Domain.Entities
{
    public class UserProfile : BaseEntity
    {
        [Required]
        public User User { get; set; }
        [Required]
        public string Name { get; set; }
        public Team? Team { get; set; }

        protected UserProfile() { }

        public UserProfile(User user, string name, Team? team = null)
        {
            User = user;
            Name = name;
            Team = team;
        }
    }
}
