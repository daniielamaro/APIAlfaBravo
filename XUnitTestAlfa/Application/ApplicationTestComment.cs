using Application.BusinessRules;
using Application.Entity;
using Domain;
using Infrastructure.Repository;
using Infrastructure.Repository.CommentDB;
using Infrastructure.Repository.PublicationDB;
using Infrastructure.Repository.TopicDB;
using Infrastructure.Repository.UserDB;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestAlfa.Application
{
    public class ApplicationTestComment
    {
        [Fact]
        public void TestEntityCreate()
        {
            var comment = CommentBuilder.New().Build();

            var mockTeste = new Mock<ICreateDB<Comment>>();

            var commentRepository = new CommentRepository(mockTeste.Object);

            commentRepository.Create(comment);

            mockTeste.Verify(x => x.CreateNewRegister(It.IsAny<Comment>()));
        }

        [Fact]
        public void TestEntityGetAll()
        {
            var mockTeste = new Mock<IGetDB<Comment>>();

            var commentRepository = new CommentRepository(mockTeste.Object);

            commentRepository.GetAll();

            mockTeste.Verify(x => x.GetAllRegister());
        }

        [Fact]
        public void TestEntityGetById()
        {
            var mockTeste = new Mock<IGetDB<Comment>>();

            var commentRepository = new CommentRepository(mockTeste.Object);

            commentRepository.GetById(Guid.NewGuid());

            mockTeste.Verify(x => x.GetRegisterById(It.IsAny<Guid>()));
        }

        [Fact]
        public void TestEntityUpdate()
        {
            var comment = CommentBuilder.New().Build();

            var mockTeste = new Mock<IUpdateDB<Comment>>();

            var commentRepository = new CommentRepository(mockTeste.Object);

            commentRepository.Update(comment);

            mockTeste.Verify(x => x.UpdateRegister(It.IsAny<Comment>()));
        }

        [Fact]
        public void TestEntityDelete()
        {
            var comment = CommentBuilder.New().Build();

            var mockTeste = new Mock<IDeleteDB<Comment>>();

            var commentRepository = new CommentRepository(mockTeste.Object);

            commentRepository.Delete(comment);

            mockTeste.Verify(x => x.DeleteRegister(It.IsAny<Comment>()));
        }

        [Fact]
        public void TestValidationCommentWithValidResult()
        {
            var okUser = UserBuilder.New().Build();
            new UserRepository().Create(okUser);

            var okComment = CommentBuilder.New().Build();

            var resultValidation1 = new CommentValidator().Validate(okComment);

            Assert.True(resultValidation1.IsValid);

        }
        
        [Fact]
        public void TestValidationCommentWithInvalidTopic()
        {
            var okUser = UserBuilder.New().Build();
            new UserRepository().Create(okUser);

            var badComment1 = CommentBuilder.New().WithContent("  ").Build();
            
            var resultValidation2 = new CommentValidator().Validate(badComment1);
            
            Assert.False(resultValidation2.IsValid);

        }

        [Fact]
        public void TestValidationCommentWithInvalidPublicationId()
        {
            var okUser = UserBuilder.New().Build();
            new UserRepository().Create(okUser);

            var badComment1 = CommentBuilder.New().WithPublicationId(Guid.Parse("00000000-0000-0000-0000-000000000000")).Build();
            
            var resultValidation2 = new CommentValidator().Validate(badComment1);
            
            Assert.False(resultValidation2.IsValid);

        }

        [Fact]
        public void TestValidationCommentExist()
        {
            var okComment = CommentBuilder.New().Build();
            new CreateComment().CreateNewRegister(okComment);

            var badComment = CommentBuilder.New().WithContent("SomeRandomContent").Build();
          
            var resultValidation1 = new CommentExistValidator().Validate(okComment.Id);
            var resultValidation2 = new CommentExistValidator().Validate(badComment.Id);

            Assert.True(resultValidation1.IsValid);
            Assert.False(resultValidation2.IsValid);
        }
    }
}
