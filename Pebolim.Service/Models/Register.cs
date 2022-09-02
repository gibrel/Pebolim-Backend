using System.ComponentModel.DataAnnotations;

namespace Pebolim.Service.Models
{
    public class CreateProfileRequest
    {
        [Required]
        public string Name { get; set; }

        public CreateProfileRequest(string profileName)
        {
            Name = profileName;
        }
    }

    public class GetProfileResponse : CreateProfileRequest
    {

        [Key]
        [Required]
        public int Id { get; set; }

        public GetProfileResponse(int id, string profileName) : base(profileName)
        {
            Id = id;
        }
    }

    public class UpdateProfileRequest : GetProfileResponse
    {
        public UpdateProfileRequest(int id, string profileName) : base(id, profileName)
        {
        }
    }
}
