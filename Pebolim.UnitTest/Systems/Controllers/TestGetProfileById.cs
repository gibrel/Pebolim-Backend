using AutoFixture.Xunit2;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Pebolim.API.Controllers;
using Pebolim.API.Models;
using Pebolim.Domain.Interfaces;
using Pebolim.UnitTest.Fixtures;
using Xunit;

namespace Pebolim.UnitTest.Systems.Controllers
{
    public class TestGetProfileById
    {
        [Theory]
        [AutoDomainData]
        public async Task GetUserById_OnSucess_ReturnsStatusCode200Async(
            [Frozen] Mock<IRegisterService> mockUserService,
            GetUserModel user)
        {
            mockUserService
                .Setup(service => service.GetById<GetUserModel>(user.Id))
                .ReturnsAsync(user);
            var sut = new RegisterController(mockUserService.Object);

            var result = await sut.Get(user.Id) as ObjectResult;

            result?.StatusCode.Should().Be(200);
        }

        [Theory]
        [AutoDomainData]
        public async Task GetUserById_OnSucess_InvokesUserServiceOnce(
            [Frozen] Mock<IRegisterService> mockUserService,
            GetUserModel user)
        {
            mockUserService
                .Setup(service => service.GetById<GetUserModel>(user.Id))
                .ReturnsAsync(user);
            var sut = new RegisterController(mockUserService.Object);

            await sut.Get(user.Id);

            mockUserService.Verify(
                service => service.GetById<GetUserModel>(user.Id), Times.Once());
        }

        [Theory]
        [AutoDomainData]
        public async Task GetUserById_OnSucess_ReturnUserModel(
            [Frozen] Mock<IRegisterService> mockUserService,
            GetUserModel user)
        {
            mockUserService
                .Setup(service => service.GetById<GetUserModel>(user.Id))
                .ReturnsAsync(user);
            var sut = new RegisterController(mockUserService.Object);

            var result = await sut.Get(user.Id);

            result.Should().BeOfType<OkObjectResult>();
            var objectResult = result as ObjectResult;
            objectResult?.Value.Should().BeOfType<GetUserModel>();
        }

        [Theory]
        [InlineAutoData(0)]
        [InlineAutoData(-1)]
        public async Task GetUserById_OnInvalidInput_Return400(
            int userId,
            [Frozen] Mock<IRegisterService> mockUserService)
        {
            GetUserModel? user = null;
            mockUserService
                .Setup(service => service.GetById<GetUserModel>(userId))
                .ReturnsAsync(user);
            var sut = new RegisterController(mockUserService.Object);

            var result = await sut.Get(userId);

            result.Should().BeOfType<BadRequestObjectResult>();
            var objectResult = result as BadRequestObjectResult;
            objectResult?.StatusCode.Should().Be(400);
        }

        [Theory]
        [AutoDomainData]
        public async Task GetUserById_OnNoUserFound_Return404(
            [Frozen] Mock<IRegisterService> mockUserService,
            int userId)
        {
            GetUserModel? user = null;
            mockUserService
                .Setup(service => service.GetById<GetUserModel>(userId))
                .ReturnsAsync(user);
            var sut = new RegisterController(mockUserService.Object);

            var result = await sut.Get(userId);

            result.Should().BeOfType<NotFoundObjectResult>();
            var objectResult = result as NotFoundObjectResult;
            objectResult?.StatusCode.Should().Be(404);
        }
    }
}