using Pebolim.Domain.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace Pebolim.Domain.Entities
{
    public class Team : BaseEntity
    {
        [Required]
        public string TeamName { get; set; }
        [Required]
        public string Base64Flag { get; set; }
        [Required]
        public string PrimaryColour { get; set; }
        [Required]
        public string SecondaryColour { get; set; }
        public Formation Formation { get; set; } = Formation.Formation_3_4_3;
        public UserProfile? UserProfile { get; set; }
        public int? UserProfileId { get; set; }

        public Team(string teamName, string base64Flag, string primaryColour, string secondaryColour)
        {
            TeamName = teamName;
            Base64Flag = base64Flag;
            PrimaryColour = primaryColour;
            SecondaryColour = secondaryColour;
        }
    }
}
