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
    public class TestAddProfile
    {
        private static Mapper ConfigureMapper()
        {
            var userMapProfile = new UserMapProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(userMapProfile));
            return new Mapper(configuration);
        }

        [Theory]
        [AutoDomainData]
        public async Task AddUser_OnSucess_ReturnsGetUserModel(
            [Frozen] Mock<IProfileRegisterRepository> mockUserRepository)
        {
            IMapper mapper = ConfigureMapper();
            User insertUser = UserFixture.GenerateUser();
            CreateUserModel newUser = new(insertUser.Username, insertUser.PasswordHash);
            mockUserRepository
                .Setup(repo => repo.Insert(insertUser))
                .ReturnsAsync(true);
            var sut = new ProfileRegisterService(
                mockUserRepository.Object,
                mapper);

            var result = await sut.Add<CreateUserModel, GetUserModel, UserValidator>(newUser);

            result.Should().BeOfType<GetUserModel>();
        }
    }
}
