using AutoFixture.Xunit2;
using AutoMapper;
using FluentAssertions;
using Moq;
using Pebolim.API.Configurations;
using Pebolim.API.Models;
using Pebolim.Domain.Entities;
using Pebolim.Domain.Interfaces;
using Pebolim.Service.Services;
using Pebolim.Service.Validators;
using Pebolim.UnitTest.Fixtures;
using Xunit;

namespace Pebolim.UnitTest.Systems.Services
{
    public class TestUpdateProfile
    {
        private static Mapper ConfigureMapper()
        {
            var userMapProfile = new UserMapProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(userMapProfile));
            return new Mapper(configuration);
        }

        [Theory]
        [AutoDomainData]
        public async Task UpdateUser_OnSucess_ReturnsGetUserModel(
            [Frozen] Mock<IRegisterRepository> mockUserRepository)
        {
            IMapper mapper = ConfigureMapper();
            User user = UserFixture.GenerateUser();
            UpdateUserModel updateUser = new(
                    id: user.Id,
                    username: user.Username,
                    passwordHash: user.PasswordHash
                );
            mockUserRepository
                .Setup(repo => repo.Update(user))
                .ReturnsAsync(true);
            var sut = new RegisterService(
                mockUserRepository.Object,
                mapper);

            var result = await sut.Update<UpdateUserModel, GetUserModel, UserValidator>(updateUser);

            result.Should().BeOfType<GetUserModel>();
        }

    }
}
