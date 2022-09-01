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
    public class TestGetAllProfiles
    {
        private static Mapper ConfigureMapper()
        {
            var userMapProfile = new UserMapProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(userMapProfile));
            return new Mapper(configuration);
        }

        [Theory]
        [AutoDomainData]
        public async Task GetAllUsers_OnSucess_ReturnsListOfGetUserModel(
            [Frozen] Mock<IProfileRegisterRepository> mockUserRepository,
            List<User> getListUserModel)
        {
            IMapper mapper = ConfigureMapper();
            mockUserRepository
                .Setup(repo => repo.Select())
                .ReturnsAsync(getListUserModel);
            var sut = new ProfileRegisterService(
                mockUserRepository.Object,
                mapper);

            var result = await sut.GetAll<GetUserModel>();

            result.Should().BeOfType<List<GetUserModel>>();
        }

    }
}
