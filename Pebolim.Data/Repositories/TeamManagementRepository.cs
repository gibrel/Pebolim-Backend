using Pebolim.Data.Context;
using Pebolim.Domain.Entities;
using Pebolim.Domain.Interfaces;

namespace Pebolim.Data.Repositories
{
    public class TeamManagementRepository : BaseRepository<Team>, ITeamManagementRepository
    {
        public TeamManagementRepository(DatabaseContext pebolimDbContext) : base(pebolimDbContext)
        {

        }
    }
}
