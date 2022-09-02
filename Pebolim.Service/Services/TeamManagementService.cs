using AutoMapper;
using Pebolim.Domain.Entities;
using Pebolim.Domain.Interfaces;

namespace Pebolim.Service.Services
{
    public class TeamManagementService : BaseService<Team>, ITeamManagementService
    {
        public TeamManagementService(
            ITeamManagementRepository teamManagementRepository,
            IMapper mapper
        ) : base(teamManagementRepository, mapper)
        {
        }
    }
}
