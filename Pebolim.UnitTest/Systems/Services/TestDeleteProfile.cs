using AutoFixture.Xunit2;
using AutoMapper;
using FluentAssertions;
using Moq;
using Pebolim.API.Configurations;
using Pebolim.Domain.Entities;
using Pebolim.Domain.Interfaces;
using Pebolim.Service.Services;
using Pebolim.UnitTest.Fixtures;
using Xunit;

namespace Pebolim.UnitTest.Systems.Services
{
    public class TestDeleteProfile
    {
        private static Mapper ConfigureMapper()
        {
            var userMapProfile = new UserMapProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(userMapProfile));
            return new Mapper(configuration);
        }

        [Theory]
        [AutoDomainData]
        public async Task DeleteUser_OnSucess_ReturnsTrue(
            [Frozen] Mock<IProfileRegisterRepository> mockUserRepository,
            User toBeDeletedUser)
        {
            IMapper mapper = ConfigureMapper();
            mockUserRepository
                .Setup(repo => repo.Delete(toBeDeletedUser.Id))
                .ReturnsAsync(true);
            var sut = new ProfileRegisterService(
                mockUserRepository.Object,
                mapper);

            var result = await sut.Delete(toBeDeletedUser.Id);

            result.Should().BeTrue();
        }

        [Theory]
        [AutoDomainData]
        public async Task DeleteUser_Failure_ReturnsFalse(
            [Frozen] Mock<IProfileRegisterRepository> mockUserRepository,
            User toBeDeletedUser)
        {
            toBeDeletedUser.Id = 0;
            IMapper mapper = ConfigureMapper();
            mockUserRepository
                .Setup(repo => repo.Delete(toBeDeletedUser.Id))
                .ReturnsAsync(false);
            var sut = new ProfileRegisterService(
                mockUserRepository.Object,
                mapper);

            var result = await sut.Delete(toBeDeletedUser.Id);

            result.Should().BeFalse();
        }
    }
}
