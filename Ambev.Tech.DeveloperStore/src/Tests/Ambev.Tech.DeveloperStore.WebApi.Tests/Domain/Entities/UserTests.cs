using Ambev.Tech.DeveloperStore.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Tech.DeveloperStore.WebApi.Tests.Domain.Entities
{
    public class UserTests
    {
        [Fact]
        public void Should_Create_Valid_User()
        {
            var user = new User("joao@ambev.com", "João", "123");

            user.Email.Should().Be("joao@ambev.com");
            user.Username.Should().Be("João");
        }
    }
}
