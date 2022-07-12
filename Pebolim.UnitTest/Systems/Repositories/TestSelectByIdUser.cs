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
    public class TestSelectByIdUser
    {

        [Theory]
        [AutoDomainData]
        public async Task SelectByIdUser_OnRun_InvokeSaveChangesOnce(
            [Frozen] Mock<DbSet<User>> mockUserSet,
            [Frozen] Mock<MySqlContext> mockMySqlContext)
        {
            mockMySqlContext
                .Setup(context => context.Users)
                .Returns(mockUserSet.Object);
            var sut = new UserRepository(mockMySqlContext.Object);
            var user = UserFixture.GenerateUser();

            await sut.Insert(user);
            await sut.Select(user.Id);

            mockMySqlContext.Verify(m => m.Set<User>(), Times.Exactly(2));
        }

        [Theory]
        [AutoDomainData]
        public async Task SelectByIdUser_OnSucess_ShouldReturnUser(
            [Frozen] Mock<DbSet<User>> mockUserSet,
            [Frozen] Mock<MySqlContext> mockMySqlContext)
        {
            mockMySqlContext
                .Setup(context => context.Users)
                .Returns(mockUserSet.Object);
            var sut = new UserRepository(mockMySqlContext.Object);
            var user = UserFixture.GenerateUser();

            await sut.Insert(user);
            var result = await sut.Select(user.Id);

            result.Should().BeOfType<User>();
        }

        [Theory]
        [AutoDomainData]
        public async Task SelectByIdUser_OnSucess_ShouldHaveSameId(
            [Frozen] Mock<DbSet<User>> mockUserSet,
            [Frozen] Mock<MySqlContext> mockMySqlContext)
        {
            mockMySqlContext
                .Setup(context => context.Users)
                .Returns(mockUserSet.Object);
            var sut = new UserRepository(mockMySqlContext.Object);
            var user = UserFixture.GenerateUser();

            await sut.Insert(user);
            var result = await sut.Select(user.Id);

            result?.Id.Should().Be(user.Id);
        }
    }
}
