using Pebolim.Data.Context;
using Pebolim.Domain.Entities;
using Pebolim.Domain.Interfaces;

namespace Pebolim.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(PebolimDbContext pebolimDbContext) : base(pebolimDbContext)
        {

        }
    }
}
