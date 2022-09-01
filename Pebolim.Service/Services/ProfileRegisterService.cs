using AutoMapper;
using FluentValidation;
using Pebolim.Domain.Entities;
using Pebolim.Domain.Interfaces;

namespace Pebolim.Service.Services
{
    public class ProfileRegisterService : BaseService<UserProfile>, IProfileRegisterService
    {
        public ProfileRegisterService(
            IProfileRegisterRepository profileRegisterRepository,
            IMapper mapper
        ) : base(profileRegisterRepository, mapper)
        {
        }

        public Task<TOutputModel> Add<TInputModel, TOutputModel, TValidator>(TInputModel newProfile, int userId)
            where TInputModel : class
            where TOutputModel : class
            where TValidator : AbstractValidator<UserProfile>
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int profileId, int userId)
        {
            throw new NotImplementedException();
        }

        public Task<TOutputModel> Get<TOutputModel>(int profileId, int userId) where TOutputModel : class
        {
            throw new NotImplementedException();
        }

        public Task<List<TOutputModel>> GetAll<TOutputModel>(int userId) where TOutputModel : class
        {
            throw new NotImplementedException();
        }

        public Task<TOutputModel> Update<TInputModel, TOutputModel, TValidator>(TInputModel profileToUpdate, int userId)
            where TInputModel : class
            where TOutputModel : class
            where TValidator : AbstractValidator<UserProfile>
        {
            throw new NotImplementedException();
        }
    }
}
