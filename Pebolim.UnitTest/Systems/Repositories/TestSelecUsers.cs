using AutoFixture.Xunit2;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using Pebolim.Data.Context;
using Pebolim.Data.Repositories;
using Pebolim.Domain.Entities;
using Pebolim.UnitTest.Fixtures;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace Pebolim.UnitTest.Systems.Repositories
{
    public class TestSelecUsers
    {
        [Theory]
        [AutoDomainData]
        public async Task SelectUsers_OnRun_InvokeSaveChanges(
            [Frozen] Mock<DbSet<User>> mockUserSet,
            [Frozen] Mock<MySqlContext> mockMySqlContext,
            [Range(3, 6)] int numberOfUsers)
        {
            mockMySqlContext
                .Setup(context => context.Users)
                .Returns(mockUserSet.Object);
            var sut = new UserRepository(mockMySqlContext.Object);

            List<User> insertedUsers = new();
            for (int i = 0; i < numberOfUsers; i++)
            {
                var user = UserFixture.GenerateUser();
                await sut.Insert(user);
                insertedUsers.Add(user);
            }
            await sut.Select();

            mockMySqlContext.Verify(m => m.Set<User>(), Times.AtMost(numberOfUsers + 1));
        }

        [Theory]
        [AutoDomainData]
        public async Task SelectUsers_OnSucess_ShouldReturnListOfUsers(
            [Frozen] Mock<DbSet<User>> mockUserSet,
            [Frozen] Mock<MySqlContext> mockMySqlContext,
            [Range(3, 6)] int numberOfUsers)
        {
            mockMySqlContext
                .Setup(context => context.Users)
                .Returns(mockUserSet.Object);
            var sut = new UserRepository(mockMySqlContext.Object);

            List<User> insertedUsers = new();
            for (int i = 0; i < numberOfUsers; i++)
            {
                var user = UserFixture.GenerateUser();
                await sut.Insert(user);
                insertedUsers.Add(user);
            }
            var result = await sut.Select();

            result.Should().BeOfType<List<User>>();
        }

        [Theory]
        [AutoDomainData]
        public async Task SelectUsers_OnSucess_ShouldHaveExpectedSize(
            [Frozen] Mock<DbSet<User>> mockUserSet,
            [Frozen] Mock<MySqlContext> mockMySqlContext,
            [Range(3, 6)] int numberOfUsers)
        {
            mockMySqlContext
                .Setup(context => context.Users)
                .Returns(mockUserSet.Object);
            var sut = new UserRepository(mockMySqlContext.Object);

            List<User> insertedUsers = new();
            for (int i = 0; i < numberOfUsers; i++)
            {
                var user = UserFixture.GenerateUser();
                await sut.Insert(user);
                insertedUsers.Add(user);
            }
            var result = await sut.Select();

            result.Count.Should().BeGreaterThanOrEqualTo(insertedUsers.Count);
        }
    }
}
