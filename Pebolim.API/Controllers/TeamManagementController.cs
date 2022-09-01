using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pebolim.Domain.Interfaces;
using Pebolim.Service.Models;
using Pebolim.Service.Validators;

namespace Pebolim.API.Controllers
{

    /// <summary>
    /// Class <c>TeamController</c> handles API requests for team management solution.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TeamManagementController : BaseController
    {
        private readonly ITeamManagementService _teamManagementService;

        /// <summary>
        /// Constructor for <c>TeamController</c> that uses <c>TeamService</c>
        /// for record management.
        /// </summary>
        /// <param name="teamManagementService"></param>
        public TeamManagementController(
            ITeamManagementService teamManagementService)
        {
            _teamManagementService = teamManagementService;
        }

        /// <summary>
        /// Endpoint responsible to create new teeam.
        /// </summary>
        /// /// <remarks>
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
        /// <param name="newTeam"><c>CreateTeamRequest</c> class object with management data.</param>
        /// <returns>Created <c>GetTeamModel</c> class object with data of the created management.</returns>
        [HttpPost("CreateTeam")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(GetTeamResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Create([FromBody] CreateTeamRequest newTeam)
        {
            if (newTeam == null)
                return BadRequest("Could not create management with invalid input.");

            var createdTeam =
                await _teamManagementService.Add<CreateTeamRequest, GetTeamResponse, TeamValidator>(newTeam);

            if (createdTeam != null)
            {
                return Created("[controller]/CreateTeam", createdTeam);
            }

            return Conflict("Could not create management, internal operation failure.");
        }

        /// <summary>
        /// Enpoint responsible to retrieve a list of all managements.
        /// </summary>
        /// <returns>List of <c>GetTeamModel</c> class objects of all found managements.</returns>
        [HttpGet("GetTeams")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetTeamResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var managements = await _teamManagementService.GetAll<GetTeamResponse>();

            if (managements.Any())
            {
                return Ok(managements);
            }

            return NotFound();
        }

        /// <summary>
        /// Enpoint responsible to retrieve management with corresponding id.
        /// </summary>
        /// <param name="id">Id of the management.</param>
        /// <returns><c>GetTeamModel</c> class object of the corresponding id.</returns>
        [HttpGet("GetTeamById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetTeamResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromBody] int id)
        {
            if (id <= 0)
                return BadRequest($"Invalid management id:'{id}'.");

            var management = await _teamManagementService.GetById<GetTeamResponse>(id);

            if (management != null)
            {
                return Ok(management);
            }

            return NotFound($"Could not find management with id:'{id}'.");
        }

        /// <summary>
        /// Enpoint responsible to update management with new values.
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
        /// <param name="managementToUpdate"><c>UpdateTeamRequest</c> class object with management data to be updated.</param>
        /// <returns>Updated <c>GetTeamModel</c> class object.</returns>
        [HttpPatch("UpdateTeam")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetTeamResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Update([FromBody] UpdateTeamRequest managementToUpdate)
        {
            if (managementToUpdate == null)
                return BadRequest("Could not update management with invalid input.");

            var updatedTeam =
                await _teamManagementService.Update<UpdateTeamRequest, GetTeamResponse, TeamValidator>(managementToUpdate);

            if (updatedTeam != null)
            {
                return Ok(updatedTeam);
            }

            return Conflict("Could not update management, internal operation failure.");
        }

        /// <summary>
        /// Enpoint responsible to delete management registry by its id.
        /// </summary>
        /// <param name="id">Id of the management to be purged.</param>
        /// <returns>String message with success or failure to delete register.</returns>
        [HttpDelete("DeleteTeam")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            if (id <= 0)
                return BadRequest($"Invalid management id:'{id}'.");

            var response = await _teamManagementService.Delete(id);

            if (response)
            {
                return Ok($"Sucessfully deleted register of management with id:'{id}'");
            }

            return NotFound($"Could not find management with id:'{id}'.");
        }
    }
}
