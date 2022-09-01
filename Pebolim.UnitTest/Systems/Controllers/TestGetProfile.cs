﻿using AutoFixture.Xunit2;
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
    public class TestGetProfile
    {
        [Theory]
        [AutoDomainData]
        public async Task GetUsers_OnSucess_ReturnsStatusCode200Async(
            [Frozen] Mock<IProfileRegisterService> mockUserService,
            List<GetUserModel> users)
        {
            mockUserService
                .Setup(service => service.GetAll<GetUserModel>())
                .ReturnsAsync(users);
            var sut = new ProfileRegisterController(mockUserService.Object);

            var result = await sut.Get() as ObjectResult;

            result?.StatusCode.Should().Be(200);
        }

        [Theory]
        [AutoDomainData]
        public async Task GetUsers_OnSucess_InvokesUserServiceOnce(
            [Frozen] Mock<IProfileRegisterService> mockUserService,
            List<GetUserModel> users)
        {
            mockUserService
                .Setup(service => service.GetAll<GetUserModel>())
                .ReturnsAsync(users);
            var sut = new ProfileRegisterController(mockUserService.Object);

            await sut.Get();

            mockUserService.Verify(
                service => service.GetAll<GetUserModel>(), Times.Once());
        }

        [Theory]
        [AutoDomainData]
        public async Task GetUsers_OnSucess_ReturnListOfUserModels(
            [Frozen] Mock<IProfileRegisterService> mockUserService,
            List<GetUserModel> users)
        {
            mockUserService
                .Setup(service => service.GetAll<GetUserModel>())
                .ReturnsAsync(users);
            var sut = new ProfileRegisterController(mockUserService.Object);

            var result = await sut.Get();

            result.Should().BeOfType<OkObjectResult>();
            var objectResult = result as ObjectResult;
            objectResult?.Value.Should().BeOfType<List<GetUserModel>>();
        }

        [Theory]
        [AutoDomainData]
        public async Task GetUsers_OnNoUsersFound_Return404(
            [Frozen] Mock<IProfileRegisterService> mockUserService)
        {
            mockUserService
                .Setup(service => service.GetAll<GetUserModel>())
                .ReturnsAsync(new List<GetUserModel>());
            var sut = new ProfileRegisterController(mockUserService.Object);

            var result = await sut.Get();

            result.Should().BeOfType<NotFoundResult>();
            var objectResult = result as NotFoundResult;
            objectResult?.StatusCode.Should().Be(404);
        }
    }
}