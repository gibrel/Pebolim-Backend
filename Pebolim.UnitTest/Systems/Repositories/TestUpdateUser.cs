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
    public class TestUpdateUser
    {

        [Fact]
        public async Task UpdateUser_OnSucess_ShouldReturnTrue()
        {
            var context = ConnectionFactory.CreateContextForSQLite();
            var sut = new UserRepository(context);
            var user = UserFixture.GenerateUser();
            await sut.Insert(user);

            user = UserFixture.MakeChanges(user);
            var result = await sut.Update(user);

            result.Should().BeTrue();
        }

        [Theory]
        [AutoDomainData]
        public async Task UpdateUser_OnRun_InvokeSetOnce(
            [Frozen] Mock<DbSet<User>> mockUserSet,
            [Frozen] Mock<PebolimDbContext> mockMySqlContext)
        {
            mockMySqlContext
                .Setup(context => context.Users)
                .Returns(mockUserSet.Object);
            var sut = new UserRepository(mockMySqlContext.Object);
            var user = UserFixture.GenerateUser();
            await sut.Insert(user);

            user = UserFixture.MakeChanges(user);
            await sut.Update(user);

            mockMySqlContext.Verify(m => m.Set<User>(), Times.Once());
        }
    }
}
