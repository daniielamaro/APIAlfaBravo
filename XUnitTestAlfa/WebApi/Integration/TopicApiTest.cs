using Domain;
using System;
using WebApi;
using Xunit;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System.Text;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Collections.Generic;
using System.Net.Http.Formatting;
using Microsoft.AspNetCore.Mvc;

namespace XUnitTestAlfa.WebApi
{

    public class TopicApiTest : IClassFixture<WebApplicationFactory<Startup>> 
    {

        private readonly WebApplicationFactory<Startup> _factory;

        public TopicApiTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/api/Topic")]
        public async Task GetAllTopics(string url)
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

        }

/*        [Theory]
        [InlineData("/api/Topic")]
        public async Task PostTopic(string url)
        {
            var client = _factory.CreateClient();

            Topic topic = new Topic("Cinema");

            var serialized = JsonConvert.SerializeObject(topic);

            var content = new StringContent(serialized, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, content);

            response.EnsureSuccessStatusCode();

            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }*/

    }

}

