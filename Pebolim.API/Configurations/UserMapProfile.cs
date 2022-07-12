using AutoMapper;
using Pebolim.API.Models;
using Pebolim.Domain.Entities;

namespace Pebolim.API.Configurations
{
    public class UserMapProfile : Profile
    {
        public UserMapProfile()
        {
            CreateMap<CreateUserModel, User>()
                .ConstructUsing(obj => new User(obj.Username, obj.PasswordHash, ""));
            CreateMap<UpdateUserModel, User>()
                .ConstructUsing(obj => new User(obj.Username, obj.PasswordHash, "") { Id = obj.Id });
            CreateMap<GetUserModel, User>()
                .ConstructUsing(obj => new User(obj.Username, obj.PasswordHash, "") { Id = obj.Id });
            CreateMap<User, GetUserModel>()
                .ConstructUsing(obj => new GetUserModel(obj.Id, obj.Username, obj.PasswordHash));
        }
    }
}
