using Infrastructure.Repository.CommentDB;
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
    public class WebApiTestComment
    {
        private readonly CommentsController controller;
        private readonly CreateComment creator;

        public WebApiTestComment()
        {
            creator = new CreateComment();
            controller = new CommentsController();
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
            var comment = CommentBuilder.New().Build();

            creator.CreateNewRegister(comment);

            var result = controller.Get();

            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetByIdReturnsBadRequest()
        {
            var comment = CommentBuilder.New().Build();

            var result = controller.Get(comment.Id);

            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public void GetByIdReturnsOk()
        {
            var comment = CommentBuilder.New().Build();

            creator.CreateNewRegister(comment);

            var result = controller.Get(comment.Id);

            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void PostReturnsBadRequest_UserNotExist()
        {
            var topic = TopicBuilder.New().Build();
            new CreateTopic().CreateNewRegister(topic);

            var result = controller.Post(Guid.NewGuid(), "Conteudo", topic.Id);

            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        public void PostReturnsBadRequest_PublicationNotExist()
        {
            var user = UserBuilder.New().Build();
            new CreateUser().CreateNewRegister(user);

            var result = controller.Post(user.Id, "Conteudo", Guid.NewGuid());

            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        public void PostReturnsBadRequest_CommentInvalid()
        {
            var user = UserBuilder.New().Build();
            new CreateUser().CreateNewRegister(user);

            var publication = PublicationBuilder.New().Build();
            new CreatePublication().CreateNewRegister(publication);

            var result = controller.Post(user.Id, "", publication.Id);

            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public void PostReturnsOk()
        {
            var user = UserBuilder.New().Build();
            new CreateUser().CreateNewRegister(user);

            var publication = PublicationBuilder.New().Build();
            new CreatePublication().CreateNewRegister(publication);

            var result = controller.Post(user.Id, "Conteudo", publication.Id);

            Assert.IsType<CreatedAtActionResult>(result.Result);
        }

        [Fact]
        public void PutReturnsBadRequest_CommentNotExistOnDatabase()
        {
            var comment = CommentBuilder.New().Build();
            new CreateComment().CreateNewRegister(comment);

            var result = controller.Put(Guid.NewGuid(), "Conteudo");

            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public void PutReturnsBadRequest_CommentInvalid()
        {
            var comment = CommentBuilder.New().Build();
            creator.CreateNewRegister(comment);

            var result = controller.Put(comment.Id, "");

            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public void PutReturnsOk()
        {
            var comment = CommentBuilder.New().Build();
            creator.CreateNewRegister(comment);

            var result = controller.Put(comment.Id, "Nome Put");

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
            var comment = CommentBuilder.New().Build();
            creator.CreateNewRegister(comment);

            var result = controller.Delete(comment.Id);

            Assert.IsType<OkObjectResult>(result.Result);
        }
    }
}
