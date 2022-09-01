using FluentAssertions;
using Moq;
using Pebolim.Data.Repositories;
using Pebolim.Domain.Entities;
using Pebolim.UnitTest.Fixtures;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace Pebolim.UnitTest.Systems.Repositories
{
    public class TestSelectProfile
    {
        [Theory]
        [AutoDomainData]
        public async Task SelectUsers_OnSucess_ShouldReturnListOfUsers(
            [Range(3, 6)] int numberOfUsers)
        {
            var context = ConnectionFactory.CreateContextForSQLite();
            var sut = new ProfileRegisterRepository(context);

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
            [Range(3, 6)] int numberOfUsers)
        {
            var context = ConnectionFactory.CreateContextForSQLite();
            var sut = new ProfileRegisterRepository(context);

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
