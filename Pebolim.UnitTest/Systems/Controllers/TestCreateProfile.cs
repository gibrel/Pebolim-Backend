using AutoFixture.Xunit2;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Pebolim.WebAPI.Controllers;
using Pebolim.Domain.Interfaces;
using Pebolim.Service.Models;
using Pebolim.Service.Validators;
using Pebolim.UnitTest.Fixtures;
using Xunit;

namespace Pebolim.UnitTest.Systems.Controllers
{
    public class TestCreateProfile
    {
        [Theory]
        [AutoDomainData]
        public async Task CreateUser_OnSucess_ReturnsStatusCode200Async(
            [Frozen] Mock<IAuthenticationService> mockUserService,
            CreateUserModel newUser,
            GetUserModel user)
        {
            //mockUserService
            //    .Setup(service => service.Add<CreateUserModel, GetUserModel, UserValidator>(newUser))
            //    .ReturnsAsync(user);
            //var sut = new AuthenticationController(mockUserService.Object);

            //var result = await sut.Register(newUser) as ObjectResult;

            //result?.StatusCode.Should().Be(200);
        }

        [Theory]
        [AutoDomainData]
        public async Task CreateUser_OnSucess_InvokesUserServiceOnce(
            [Frozen] Mock<IProfileRegisterService> mockUserService,
            CreateUserModel newUser,
            GetUserModel user)
        {
            //mockUserService
            //    .Setup(service => service.Add<CreateUserModel, GetUserModel, UserValidator>(newUser))
            //    .ReturnsAsync(user);
            //var sut = new ProfileRegisterController(mockUserService.Object);

            //await sut.Create(newUser);

            //mockUserService.Verify(
            //    service => service.Add<CreateUserModel, GetUserModel, UserValidator>(newUser), Times.Once());
        }

        [Theory]
        [AutoDomainData]
        public async Task CreateUser_OnSucess_ReturnUserModel(
            [Frozen] Mock<IProfileRegisterService> mockUserService,
            CreateUserModel newUser,
            GetUserModel user)
        {
            //mockUserService
            //    .Setup(service => service.Add<CreateUserModel, GetUserModel, UserValidator>(newUser))
            //    .ReturnsAsync(user);
            //var sut = new ProfileRegisterController(mockUserService.Object);

            //var result = await sut.Create(newUser);

            //result.Should().BeOfType<OkObjectResult>();
            //var objectResult = result as ObjectResult;
            //objectResult?.Value.Should().BeOfType<GetUserModel>();
        }

        [Theory]
        [AutoDomainData]
        public async Task CreateUser_OnNullInput_Return400(
            [Frozen] Mock<IProfileRegisterService> mockUserService)
        {
//#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
//            CreateUserModel newUser = null;
//            GetUserModel user = null;
//#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
//#pragma warning disable CS8604 // Possible null reference argument.
//            mockUserService
//                .Setup(service => service.Add<CreateUserModel, GetUserModel, UserValidator>(newUser))
//                .ReturnsAsync(user);
//#pragma warning restore CS8604 // Possible null reference argument.
//            var sut = new ProfileRegisterController(mockUserService.Object);

//#pragma warning disable CS8604 // Possible null reference argument.
//            var result = await sut.Create(newUser);
//#pragma warning restore CS8604 // Possible null reference argument.

//            result.Should().BeOfType<BadRequestObjectResult>();
//            var objectResult = result as BadRequestObjectResult;
//            objectResult?.StatusCode.Should().Be(400);
        }

        [Theory]
        [AutoDomainData]
        public async Task CreateUser_OnInvalidContent_Return409(
            [Frozen] Mock<IProfileRegisterService> mockUserService,
            CreateUserModel newUser)
        {
            //newUser.PasswordHash = "";
            //GetUserModel? user = null;
            //mockUserService
            //    .Setup(service => service.Add<CreateUserModel, GetUserModel, UserValidator>(newUser))
            //    .ReturnsAsync(user);
            //var sut = new ProfileRegisterController(mockUserService.Object);

            //var result = await sut.Create(newUser);

            //result.Should().BeOfType<ConflictObjectResult>();
            //var objectResult = result as ConflictObjectResult;
            //objectResult?.StatusCode.Should().Be(409);
        }
    }
}