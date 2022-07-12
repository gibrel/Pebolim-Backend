using AutoFixture.Xunit2;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Pebolim.API.Controllers;
using Pebolim.Domain.Interfaces;
using Pebolim.UnitTest.Fixtures;
using Xunit;

namespace Pebolim.UnitTest.Systems.Controllers
{
    public class TestDeleteUser
    {
        [Theory]
        [AutoDomainData]
        public async Task DeleteUser_OnSucess_ReturnsStatusCode200Async(
            [Frozen] Mock<IUserService> mockUserService,
            int userId)
        {
            mockUserService
                .Setup(service => service.Delete(userId))
                .ReturnsAsync(true);
            var sut = new UserController(mockUserService.Object);

            var result = await sut.Delete(userId) as ObjectResult;

            result?.StatusCode.Should().Be(200);
        }

        [Theory]
        [AutoDomainData]
        public async Task DeleteUser_OnSucess_InvokesUserServiceOnce(
            [Frozen] Mock<IUserService> mockUserService,
            int userId)
        {
            mockUserService
                .Setup(service => service.Delete(userId))
                .ReturnsAsync(true);
            var sut = new UserController(mockUserService.Object);

            await sut.Delete(userId);

            mockUserService.Verify(
                service => service.Delete(userId), Times.Once());
        }

        [Theory]
        [InlineAutoData(0)]
        [InlineAutoData(-1)]
        public async Task DeleteUser_OnInvalidInput_Return400(
            int userId,
            [Frozen] Mock<IUserService> mockUserService)
        {
            mockUserService
                .Setup(service => service.Delete(userId))
                .ReturnsAsync(false);
            var sut = new UserController(mockUserService.Object);

            var result = await sut.Delete(userId);

            result.Should().BeOfType<BadRequestObjectResult>();
            var objectResult = result as BadRequestObjectResult;
            objectResult?.StatusCode.Should().Be(400);
        }

        [Theory]
        [AutoDomainData]
        public async Task DeleteUser_OnNoUserFound_Return404(
            [Frozen] Mock<IUserService> mockUserService,
            int userId)
        {
            mockUserService
                .Setup(service => service.Delete(userId))
                .ReturnsAsync(false);
            var sut = new UserController(mockUserService.Object);

            var result = await sut.Delete(userId);

            result.Should().BeOfType<NotFoundObjectResult>();
            var objectResult = result as NotFoundObjectResult;
            objectResult?.StatusCode.Should().Be(404);
        }
    }
}
