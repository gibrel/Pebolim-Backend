using Pebolim.Data.Context;
using Pebolim.Domain.Entities;
using Pebolim.Domain.Interfaces;

namespace Pebolim.Data.Repositories
{
    public class ProfileRegisterRepository : BaseRepository<UserProfile>, IProfileRegisterRepository
    {
        public ProfileRegisterRepository(DatabaseContext pebolimDbContext) : base(pebolimDbContext)
        {

        }
    }
}
