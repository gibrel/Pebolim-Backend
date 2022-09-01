using System.ComponentModel.DataAnnotations;

namespace Pebolim.Service.Models
{
    public class CreateTeamRequest
    {
        [Required]
        public string TeamName { get; set; }
        [Required]
        public string Base64Flag { get; set; }
        [Required]
        public string PrimaryColour { get; set; }
        [Required]
        public string SecondaryColour { get; set; }

        public CreateTeamRequest(string teamName, string flag, string primaryColour, string secondaryColour)
        {
            TeamName = teamName;
            Base64Flag = flag;
            PrimaryColour = primaryColour;
            SecondaryColour = secondaryColour;
        }
    }

    public class GetTeamResponse : CreateTeamRequest
    {

        [Key]
        [Required]
        public int Id { get; set; }

        public GetTeamResponse(int id, string teamName, string flag, string primaryColour, string secondaryColour) : base(teamName, flag, primaryColour, secondaryColour)
        {
            Id = id;
        }
    }

    public class UpdateTeamRequest : GetTeamResponse
    {
        public UpdateTeamRequest(int id, string teamName, string flag, string primaryColour, string secondaryColour) : base(id, teamName, flag, primaryColour, secondaryColour)
        {
        }
    }
}
