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
            [Frozen] Mock<PebolimDbContext> mockMySqlContext)
        {
            mockMySqlContext
                .Setup(context => context.Users)
                .Returns(mockUserSet.Object);
            var sut = new UserRepository(mockMySqlContext.Object);
            var user = UserFixture.GenerateUser();

            await sut.Select(user.Id);

            mockMySqlContext.Verify(m => m.Set<User>(), Times.Once());
        }

        [Fact]
        public async Task SelectByIdUser_OnSucess_ShouldReturnUser()
        {
            var context = ConnectionFactory.CreateContextForSQLite();
            var sut = new UserRepository(context);
            var user = UserFixture.GenerateUser();

            var response = await sut.Insert(user);
            var userId = user.Id;
            var userCount = context.Users?.Count(x => x.Id == userId);

            Assert.True(response);
            Assert.Equal(1, userCount);

            var retunedUser = await sut.Select(userId);

            retunedUser.Should().BeOfType<User>();
        }

        [Theory]
        [AutoDomainData]
        public async Task SelectByIdUser_OnSucess_ShouldHaveSameId(
            [Frozen] Mock<DbSet<User>> mockUserSet,
            [Frozen] Mock<PebolimDbContext> mockMySqlContext)
        {
            mockMySqlContext
                .Setup(context => context.Users)
                .Returns(mockUserSet.Object);
            var sut = new UserRepository(mockMySqlContext.Object);
            var user = UserFixture.GenerateUser();

            await sut.Insert(user);
            var returnedUser = await sut.Select(user.Id);

            returnedUser?.Id.Should().Be(user.Id);
        }
    }
}
