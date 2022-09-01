using AutoFixture.Xunit2;
using Microsoft.EntityFrameworkCore;
using Moq;
using Pebolim.Data.Context;
using Pebolim.Data.Repositories;
using Pebolim.Domain.Entities;
using Pebolim.UnitTest.Fixtures;
using Xunit;

namespace Pebolim.UnitTest.Systems.Repositories
{
    public class TestInsertProfile
    {

        [Fact]
        public async Task InsertUser_OnSucess_ShouldReturnTrue()
        {
            var context = ConnectionFactory.CreateContextForSQLite();
            var sut = new ProfileRegisterRepository(context);
            var user = UserFixture.GenerateUser();

            var response = await sut.Insert(user);
            var userId = user.Id;

            Assert.NotEqual(0, userId);

            var userCount = context.Users?.Count(x => x.Id == userId);

            Assert.True(response);
            Assert.Equal(1, userCount);
        }

        [Theory]
        [AutoDomainData]
        public async Task InsertUser_OnRun_InvokeSetOnce(
            [Frozen] Mock<DbSet<User>> mockUserSet,
            [Frozen] Mock<DatabaseContext> mockMySqlContext)
        {
            mockMySqlContext
                .Setup(context => context.Users)
                .Returns(mockUserSet.Object);
            var sut = new ProfileRegisterRepository(mockMySqlContext.Object);
            var user = UserFixture.GenerateUser();

            await sut.Insert(user);

            mockMySqlContext.Verify(m => m.Set<User>(), Times.Once());
        }

        [Fact]
        public async Task InsertUser_OnSucess_ShouldUpdateUserId()
        {
            var context = ConnectionFactory.CreateContextForSQLite();
            var sut = new ProfileRegisterRepository(context);
            var user = UserFixture.GenerateUser();

            await sut.Insert(user);
            var userId = user.Id;

            Assert.NotEqual(0, userId);
        }

    }
}
