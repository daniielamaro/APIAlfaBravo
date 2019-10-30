using Infrastructure.Repository.TopicDB;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Controllers;
using Xunit;

namespace XUnitTestAlfa.WebApi
{
    public class WebApiTestTopic
    {
        private readonly TopicController controller;
        private readonly CreateTopic creator;

        public WebApiTestTopic()
        {
            creator = new CreateTopic();
            controller = new TopicController();
        }

        [Fact]
        public void GetReturnsNoContent()
        {
            var result = controller.Get();

            Assert.IsType<NoContentResult>(result.Result);
        }

        [Fact]
        public void GetReturnsOk()
        {
            var user = UserBuilder.New().Build();

            creator.CreateNewRegister(user);

            var result = controller.Get();

            Assert.IsType<OkObjectResult>(result.Result);
        }
    }
}
