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

    public class PublicationApiTest : IClassFixture<WebApplicationFactory<Startup>>
    {

        private readonly WebApplicationFactory<Startup> _factory;

        public PublicationApiTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/api/Publications")]
        public async Task GetAllPublications(string url)
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

        }

/*        [Theory]
        [InlineData("/api/Publications")]
        public async Task PostPublication(string url)
        {
            var client = _factory.CreateClient();

            User user = new User("mozart", "mozart@mail.com", "123456789");

            Topic topic = new Topic("politica");
            
            List<Comment> comments = new List<Comment>(new Comment[] { });

            Publication pub = new Publication(user, "Introdução", "Olá, mundo!", topic);

            var serialized = JsonConvert.SerializeObject(pub);

            var content = new StringContent(serialized, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, content);

            response.EnsureSuccessStatusCode();

            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }*/
    }

}

