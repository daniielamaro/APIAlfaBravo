using Domain;
using System;
using WebApi;
using Xunit;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Text;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Collections.Generic;
using Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using WebApi.Controllers;
using Newtonsoft.Json;

namespace XUnitTestAlfa.WebApi
{

    public class UserApiTest : IClassFixture<WebApplicationFactory<Startup>>
    {

        private readonly WebApplicationFactory<Startup> _factory;

        public UserApiTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        /*        [Theory]
                [InlineData("/")]
                public async Task GetHttpRequest(string url)
                {
                    var client = _factory.CreateClient();

                    var response = await client.GetAsync(url);

                    response.EnsureSuccessStatusCode();

                    Assert.Equal("text/html", response.Content.Headers.ContentType.ToString());

                }*/

        [Theory]
        [InlineData("/api/Users")]
        public async Task GetAllUsers(string url)
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

        }

        /*        [Theory]
                [InlineData("/api/Users")]
                public async Task PostUser(string url)
                {
                    //Arrange
                    var client = _factory.CreateClient();
                    var user = new User("mozart", "mozart@mail.com", "123456789");
                    var serialized = JsonConvert.SerializeObject(user);
                    StringContent content = new StringContent(serialized, Encoding.UTF8, "application/json");

                    //Act
                    var response = await client.PostAsync(url, content);

                    // Assert
                    response.EnsureSuccessStatusCode();
                    response.StatusCode.Should().Be(HttpStatusCode.Created);
                }

                [Theory]
                [InlineData("/api/Users")]
                public async Task InvalidPassword(string url)
                {
                    //Arrange
                    var client = _factory.CreateClient();

                    var user = new User("mozart", "mozart@mail.com","1234");

                    var serialized = JsonConvert.SerializeObject(user);
                    var content = new StringContent(serialized, Encoding.UTF8, "application/json");

                    //Act
                    var response = await client.PostAsync(url, content);

                    // Assert
                    response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
                }
            }*/

    }
}

