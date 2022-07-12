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
    public class TestDeleteUser
    {
        [Theory]
        [AutoDomainData]
        public async Task DeleteUser_OnRun_InvokeSaveChangesOnce(
            [Frozen] Mock<DbSet<User>> mockUserSet,
            [Frozen] Mock<MySqlContext> mockMySqlContext)
        {
            mockMySqlContext
                .Setup(context => context.Users)
                .Returns(mockUserSet.Object);
            var sut = new UserRepository(mockMySqlContext.Object);
            var user = UserFixture.GenerateUser();

            await sut.Insert(user);
            await sut.Delete(user.Id);

            mockMySqlContext.Verify(m => m.SaveChanges(), Times.Exactly(2));
        }

        [Theory]
        [AutoDomainData]
        public async Task DeleteUser_OnRun_InvokeSetOnce(
            [Frozen] Mock<DbSet<User>> mockUserSet,
            [Frozen] Mock<MySqlContext> mockMySqlContext)
        {
            mockMySqlContext
                .Setup(context => context.Users)
                .Returns(mockUserSet.Object);
            var sut = new UserRepository(mockMySqlContext.Object);
            var user = UserFixture.GenerateUser();

            await sut.Insert(user);
            await sut.Delete(user.Id);

            mockMySqlContext.Verify(m => m.Set<User>(), Times.Exactly(3));
        }
    }
}
