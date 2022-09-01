using AutoFixture.Xunit2;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Pebolim.API.Controllers;
using Pebolim.API.Models;
using Pebolim.Domain.Interfaces;
using Pebolim.Service.Validators;
using Pebolim.UnitTest.Fixtures;
using Xunit;

namespace Pebolim.UnitTest.Systems.Controllers
{
    public class TestUpdateProfile
    {
        [Theory]
        [AutoDomainData]
        public async Task UpdateUser_OnSucess_ReturnsStatusCode200Async(
            [Frozen] Mock<IProfileRegisterService> mockUserService,
            UpdateUserModel toUpdateUser,
            GetUserModel updatedUser)
        {
            mockUserService
                .Setup(service =>
                    service.Update<UpdateUserModel, GetUserModel, UserValidator>(toUpdateUser))
                .ReturnsAsync(updatedUser);
            var sut = new ProfileRegisterController(mockUserService.Object);

            var result = await sut.Update(toUpdateUser) as ObjectResult;

            result?.StatusCode.Should().Be(200);
        }

        [Theory]
        [AutoDomainData]
        public async Task UpdateUser_OnSucess_InvokesUserServiceOnce(
            [Frozen] Mock<IProfileRegisterService> mockUserService,
            UpdateUserModel toUpdateUser,
            GetUserModel updatedUser)
        {
            mockUserService
                .Setup(service => service.Update<UpdateUserModel, GetUserModel, UserValidator>(toUpdateUser))
                .ReturnsAsync(updatedUser);
            var sut = new ProfileRegisterController(mockUserService.Object);

            await sut.Update(toUpdateUser);

            mockUserService.Verify(
                service => service.Update<UpdateUserModel, GetUserModel, UserValidator>(toUpdateUser), Times.Once());
        }

        [Theory]
        [AutoDomainData]
        public async Task UpdateUser_OnSucess_ReturnUserModel(
            [Frozen] Mock<IProfileRegisterService> mockUserService,
            UpdateUserModel toUpdateUser,
            GetUserModel updatedUser)
        {
            mockUserService
                .Setup(service => service.Update<UpdateUserModel, GetUserModel, UserValidator>(toUpdateUser))
                .ReturnsAsync(updatedUser);
            var sut = new ProfileRegisterController(mockUserService.Object);

            var result = await sut.Update(toUpdateUser);

            result.Should().BeOfType<OkObjectResult>();
            var objectResult = result as ObjectResult;
            objectResult?.Value.Should().BeOfType<GetUserModel>();
        }

        [Theory]
        [AutoDomainData]
        public async Task UpdateUser_OnNullInput_Return400(
            [Frozen] Mock<IProfileRegisterService> mockUserService)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            UpdateUserModel toUpdateUser = null;
            GetUserModel updatedUser = null;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8604 // Possible null reference argument.
            mockUserService
                .Setup(service => service.Update<UpdateUserModel, GetUserModel, UserValidator>(toUpdateUser))
                .ReturnsAsync(updatedUser);
#pragma warning restore CS8604 // Possible null reference argument.
            var sut = new ProfileRegisterController(mockUserService.Object);

#pragma warning disable CS8604 // Possible null reference argument.
            var result = await sut.Update(toUpdateUser);
#pragma warning restore CS8604 // Possible null reference argument.

            result.Should().BeOfType<BadRequestObjectResult>();
            var objectResult = result as BadRequestObjectResult;
            objectResult?.StatusCode.Should().Be(400);
        }

        [Theory]
        [AutoDomainData]
        public async Task UpdateUser_OnInvalidContent_Return409(
            [Frozen] Mock<IProfileRegisterService> mockUserService,
            UpdateUserModel toUpdateUser)
        {
            toUpdateUser.PasswordHash = "";
            GetUserModel? updatedUser = null;
            mockUserService
                .Setup(service => service.Update<UpdateUserModel, GetUserModel, UserValidator>(toUpdateUser))
                .ReturnsAsync(updatedUser);
            var sut = new ProfileRegisterController(mockUserService.Object);

            var result = await sut.Update(toUpdateUser);

            result.Should().BeOfType<ConflictObjectResult>();
            var objectResult = result as ConflictObjectResult;
            objectResult?.StatusCode.Should().Be(409);
        }
    }
}
