using Infrastructure.Repository.PublicationDB;
using Infrastructure.Repository.TopicDB;
using Infrastructure.Repository.UserDB;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Controllers;
using Xunit;

namespace XUnitTestAlfa.WebApi
{
    public class WebApiTestPublication
    {
        private readonly PublicationsController controller;
        private readonly CreatePublication creator;

        public WebApiTestPublication()
        {
            creator = new CreatePublication();
            controller = new PublicationsController();
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
            var publication = PublicationBuilder.New().Build();

            creator.CreateNewRegister(publication);

            var result = controller.Get();

            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetByIdReturnsBadRequest()
        {
            var publication = PublicationBuilder.New().Build();

            var result = controller.Get(publication.Id);

            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public void GetByIdReturnsOk()
        {
            var publication = PublicationBuilder.New().Build();

            creator.CreateNewRegister(publication);

            var result = controller.Get(publication.Id);

            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void PostReturnsBadRequest_UserInvalid()
        {
            var topic = TopicBuilder.New().Build();
            new CreateTopic().CreateNewRegister(topic);

            var result = controller.Post(Guid.NewGuid(), "Titulo", "Conteudo", topic.Id);

            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        public void PostReturnsBadRequest_TopicInvalid()
        {
            var user = UserBuilder.New().Build();
            new CreateUser().CreateNewRegister(user);

            var result = controller.Post(user.Id, "Titulo", "Conteudo", Guid.NewGuid());

            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        public void PostReturnsBadRequest_PublicationInvalid()
        {
            var user = UserBuilder.New().Build();
            new CreateUser().CreateNewRegister(user);

            var topic = TopicBuilder.New().Build();
            new CreateTopic().CreateNewRegister(topic);

            var result = controller.Post(user.Id, "", "Conteudo", topic.Id);

            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public void PostReturnsOk()
        {
            var user = UserBuilder.New().Build();
            new CreateUser().CreateNewRegister(user);

            var topic = TopicBuilder.New().Build();
            new CreateTopic().CreateNewRegister(topic);

            var result = controller.Post(user.Id, "Titulo", "Conteudo", topic.Id);

            Assert.IsType<CreatedAtActionResult>(result.Result);
        }

        [Fact]
        public void PutReturnsBadRequest_PublicationNotExistOnDatabase()
        {
            var topic = TopicBuilder.New().Build();
            new CreateTopic().CreateNewRegister(topic);

            var result = controller.Put(Guid.NewGuid(), "Nome put", "Conteudo", topic.Id);

            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public void PutReturnsBadRequest_TopicNotValid()
        {
            var topic = TopicBuilder.New().Build();
            creator.CreateNewRegister(topic);

            var result = controller.Put(topic.Id, "  ");

            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public void PutReturnsOk()
        {
            var topic = TopicBuilder.New().Build();
            creator.CreateNewRegister(topic);

            var result = controller.Put(topic.Id, "Nome Put");

            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void DeleteReturnsBadRequest()
        {
            var result = controller.Delete(Guid.NewGuid());

            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public void DeleteReturnsOk()
        {
            var topic = TopicBuilder.New().Build();

            creator.CreateNewRegister(topic);

            var result = controller.Delete(topic.Id);

            Assert.IsType<OkObjectResult>(result.Result);
        }
    }
}
