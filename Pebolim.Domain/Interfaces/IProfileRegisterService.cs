using FluentValidation;
using Pebolim.Domain.Entities;

namespace Pebolim.Domain.Interfaces
{
    public interface IProfileRegisterService : IBaseService<UserProfile>
    {
        public Task<TOutputModel> Add<TInputModel, TOutputModel, TValidator>(TInputModel newProfile, int userId)
            where TValidator : AbstractValidator<UserProfile>
            where TInputModel : class
            where TOutputModel : class;
        public Task<List<TOutputModel>> GetAll<TOutputModel>(int userId)
            where TOutputModel : class;
        public Task<TOutputModel> Get<TOutputModel>(int profileId, int userId)
            where TOutputModel : class;
        public Task<TOutputModel> Update<TInputModel, TOutputModel, TValidator>(TInputModel profileToUpdate, int userId)
            where TValidator : AbstractValidator<UserProfile>
            where TInputModel : class
            where TOutputModel : class;
        public Task<bool> Delete(int profileId, int userId);
    }
}
