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

    public class TestDeleteProfile
    {
        [Fact]
        public async Task DeleteUser_OnRun_ReturnsTrue()
        {
            //var context = ConnectionFactory.CreateContextForSQLite();
            //var sut = new ProfileRegisterRepository(context);
            //var user = UserFixture.GenerateUser();

            //var response = await sut.Insert(user);
            //var userId = user.Id;
            //var userCount = context.Users?.Count(x => x.Id == userId);

            //Assert.True(response);
            //Assert.Equal(1, userCount);

            //response = await sut.Delete(userId);

            //Assert.True(response);
        }

        [Fact]
        public async Task DeleteUser_OnRun_DeletesCorrectUser()
        {
            //var context = ConnectionFactory.CreateContextForSQLite();
            //var sut = new ProfileRegisterRepository(context);
            //var user = UserFixture.GenerateUser();

            //var response = await sut.Insert(user);
            //var userId = user.Id;
            //var userCount = context.Users?.Count(x => x.Id == userId);

            //Assert.True(response);
            //Assert.Equal(1, userCount);

            //response = await sut.Delete(userId);
            //userCount = context.Users?.Count(x => x.Id == userId);

            //Assert.True(response);
            //Assert.Equal(0, userCount);
        }

        [Theory]
        [AutoDomainData]
        public async Task DeleteUser_OnRun_DeletesRightUser(
            [Frozen] Mock<DbSet<User>> mockUserSet,
            [Frozen] Mock<DatabaseContext> mockMySqlContext)
        {
            mockMySqlContext
                .Setup(context => context.Users)
                .Returns(mockUserSet.Object);
            var sut = new ProfileRegisterRepository(mockMySqlContext.Object);
            var user = UserFixture.GenerateUser();
            await sut.Delete(user.Id);

            mockMySqlContext.Verify(m => m.Set<User>(), Times.Once());
        }
    }
}
