using AutoMapper;
using Pebolim.Domain.Entities;
using Pebolim.Domain.Interfaces;

namespace Pebolim.Service.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(
            IUserRepository userRepository,
            IMapper mapper
        ) : base(userRepository, mapper)
        {
        }
    }
}
