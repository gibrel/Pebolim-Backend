using AutoFixture.Xunit2;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using Pebolim.Data.Context;
using Pebolim.Data.Repositories;
using Pebolim.Domain.Entities;
using Pebolim.UnitTest.Fixtures;
using Xunit;

namespace Pebolim.UnitTest.Systems.Repositories
{
    public class TestInsertUser
    {

        [Theory]
        [AutoDomainData]
        public async Task InsertUser_OnSucess_ShouldReturnTrue(
            [Frozen] Mock<DbSet<User>> mockUserSet,
            [Frozen] Mock<MySqlContext> mockMySqlContext)
        {
            mockMySqlContext
                .Setup(context => context.Users)
                .Returns(mockUserSet.Object);
            var sut = new UserRepository(mockMySqlContext.Object);
            var user = UserFixture.GenerateUser();

            var result = await sut.Insert(user);

            result.Should().BeTrue();
        }

        [Theory]
        [AutoDomainData]
        public async Task InsertUser_OnRun_InvokeSaveChangesOnce(
            [Frozen] Mock<DbSet<User>> mockUserSet,
            [Frozen] Mock<MySqlContext> mockMySqlContext)
        {
            mockMySqlContext
                .Setup(context => context.Users)
                .Returns(mockUserSet.Object);
            var sut = new UserRepository(mockMySqlContext.Object);
            var user = UserFixture.GenerateUser();

            await sut.Insert(user);

            mockMySqlContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Theory]
        [AutoDomainData]
        public async Task InsertUser_OnRun_InvokeSetOnce(
            [Frozen] Mock<DbSet<User>> mockUserSet,
            [Frozen] Mock<MySqlContext> mockMySqlContext)
        {
            mockMySqlContext
                .Setup(context => context.Users)
                .Returns(mockUserSet.Object);
            var sut = new UserRepository(mockMySqlContext.Object);
            var user = UserFixture.GenerateUser();

            await sut.Insert(user);

            mockMySqlContext.Verify(m => m.Set<User>(), Times.Once());
        }

        [Theory]
        [AutoDomainData]
        public async Task InsertUser_OnSucess_ShouldUpdateUserId(
            [Frozen] Mock<DbSet<User>> mockUserSet,
            [Frozen] Mock<MySqlContext> mockMySqlContext)
        {
            mockMySqlContext
                .Setup(context => context.Users)
                .Returns(mockUserSet.Object);
            var sut = new UserRepository(mockMySqlContext.Object);
            var user = UserFixture.GenerateUser();

            await sut.Insert(user);

            user.Id.Should().NotBe(0);
        }

    }
}
