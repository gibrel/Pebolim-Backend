using AutoFixture.Xunit2;
using AutoMapper;
using FluentAssertions;
using Moq;
using Pebolim.API.Configurations;
using Pebolim.API.Models;
using Pebolim.Domain.Entities;
using Pebolim.Domain.Interfaces;
using Pebolim.Service.Services;
using Pebolim.UnitTest.Fixtures;
using Xunit;

namespace Pebolim.UnitTest.Systems.Services
{
    public class TestGetByIdUser
    {
        private static Mapper ConfigureMapper()
        {
            var userMapProfile = new UserMapProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(userMapProfile));
            return new Mapper(configuration);
        }

        [Theory]
        [AutoDomainData]
        public async Task GetUserById_OnSucess_ReturnsGetUserModel(
            [Frozen] Mock<IUserRepository> mockUserRepository,
            User user)
        {
            IMapper mapper = ConfigureMapper();
            mockUserRepository
                .Setup(repo => repo.Select(user.Id))
                .ReturnsAsync(user);
            var sut = new UserService(
                mockUserRepository.Object,
                mapper);

            var result = await sut.GetById<GetUserModel>(user.Id);

            result.Should().BeOfType<GetUserModel>();
        }

    }
}
