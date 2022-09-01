using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pebolim.Domain.Interfaces;
using Pebolim.Service.Models;
using Pebolim.Service.Validators;

namespace Pebolim.API.Controllers
{
    /// <summary>
    /// Class <c>ProfileRegisterController</c> handles API requests for user profile.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ProfileRegisterController : BaseController
    {
        private readonly IProfileRegisterService _profileRegisterService;

        /// <summary>
        /// Constructor for <c>ProfileRegisterController</c> that uses <c>ProfileRegisterService</c>
        /// for user profile record management.
        /// </summary>
        /// <param name="profileRegisterService"></param>
        public ProfileRegisterController(
            IProfileRegisterService profileRegisterService)
        {
            _profileRegisterService = profileRegisterService;
        }

        /// <summary>
        /// Create new user profile.
        /// </summary>
        /// <remarks>
        /// 
        ///        Test
        ///        
        /// Sample request:
        ///
        ///     {
        ///         Sample
        ///     }
        ///
        /// </remarks>
        /// <param name="newProfile"><c>CreateProfileRequest</c> class object with user profile data.</param>
        /// <returns>Created <c>GetUserModel</c> class object with data of the created user.</returns>
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateProfileRequest))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Create([FromBody] CreateProfileRequest newProfile)
        {
            if (newProfile == null)
                return BadRequest("Could not create profile: invalid input.");

            if (UserId.Equals(0))
                return Forbid("User must be logged in to perform operation.");

            var createdProfile =
                await _profileRegisterService.Add<CreateProfileRequest, GetProfileResponse, ProfileValidator>(newProfile, UserId);

            if (createdProfile != null)
            {
                return Created("[controller]/create", createdProfile);
            }

            return Conflict("Could not create user profile, internal operation failure.");
        }

        /// <summary>
        /// Retrieve a list of all user profile of a certain user.
        /// </summary>
        /// <returns>List of <c>GetUserModel</c> class objects of all found users.</returns>
        [HttpGet("list")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetProfileResponse>))]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll()
        {
            if(UserId.Equals(0))
                return Forbid("User must be logged in to perform operation.");

            var profiles = await _profileRegisterService.GetAll<GetProfileResponse>(UserId);

            if (profiles.Any())
            {
                return Ok(profiles);
            }

            return NotFound("Could not find user profile for given user.");
        }

        /// <summary>
        /// Enpoint responsible to retrieve user with corresponding profileId.
        /// </summary>
        /// <param name="profileId">Id of the user.</param>
        /// <returns><c>GetUserModel</c> class object of the corresponding profileId.</returns>
        [HttpGet("get")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetProfileResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromBody] int profileId)
        {
            if (profileId <= 0)
                return BadRequest($"Invalid user profileId:'{profileId}'.");

            if (UserId.Equals(0))
                return Forbid("User must be logged in to perform operation.");

            var profile = await _profileRegisterService.Get<GetProfileResponse>(profileId, UserId);

            if (profile != null)
            {
                return Ok(profile);
            }

            return NotFound($"Could not find profileId:'{profileId}' for current user.");
        }

        /// <summary>
        /// Enpoint responsible to update user with new values.
        /// </summary>
        /// <remarks>
        /// 
        ///        Test
        ///        
        /// Sample request:
        ///
        ///     {
        ///        Sample
        ///     }
        ///
        /// </remarks>
        /// <param name="profileToUpdate"><c>UpdateUserModel</c> class object with user data to be updated.</param>
        /// <returns>Updated <c>GetUserModel</c> class object.</returns>
        [HttpPatch("update")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetProfileResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Update([FromBody] UpdateProfileRequest profileToUpdate)
        {
            if (profileToUpdate == null)
                return BadRequest("Could not update user with invalid input.");

            if (UserId.Equals(0))
                return Forbid("User must be logged in to perform operation.");

            var updatedProfile =
                await _profileRegisterService.Update<UpdateProfileRequest, GetProfileResponse, ProfileValidator>(profileToUpdate, UserId);

            if (updatedProfile != null)
            {
                return Ok(updatedProfile);
            }

            return Conflict("Could not update profile, internal operation failure.");
        }

        /// <summary>
        /// Enpoint responsible to delete user registry by its profileId.
        /// </summary>
        /// <param name="profileId">Id of the user to be purged.</param>
        /// <returns>String message with success or failure to delete register.</returns>
        [HttpDelete("remove")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromBody] int profileId)
        {
            if (profileId <= 0)
                return BadRequest($"Invalid user profileId:'{profileId}'.");

            if (UserId.Equals(0))
                return Forbid("User must be logged in to perform operation.");

            var response = await _profileRegisterService.Delete(profileId, UserId);

            if (response)
            {
                return Ok($"Sucessfully deleted register of user with profileId:'{profileId}'");
            }

            return NotFound($"Could not find user with profileId:'{profileId}'.");
        }
    }
}
