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
using Newtonsoft.Json;

namespace XUnitTestAlfa.WebApi
{

    public class CommentApiTest : IClassFixture<WebApplicationFactory<Startup>>
    {

        private readonly WebApplicationFactory<Startup> _factory;

        public CommentApiTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/api/Comments")]
        public async Task GetAllComments(string url)
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

        }
/*
        [Theory]
        [InlineData("/api/Comments")]
        public async Task PostComment(string url)
        {
            var client = _factory.CreateClient();

            User user = new User("mozart", "mozart@mail.com", "123456789");
            User userR = new User("raul", "raul@mail.com", "987654321");

            Topic topic = new Topic("politica");

            List<Comment> comments = new List<Comment>(new Comment[] { });

            Publication pub = new Publication(user, "Introdução", "Olá, mundo!", topic);

            Comment cmmnt = new Comment(userR, "muito bom!!", pub.Id);

            var serialized = JsonConvert.SerializeObject(pub);

            var content = new StringContent(serialized, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, content);

            response.EnsureSuccessStatusCode();

            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }*/
    }

}

