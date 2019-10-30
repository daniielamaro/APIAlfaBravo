using Application.BusinessRules;
using Application.Entity;
using Domain;
using Infrastructure.Repository;
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
            var comment = new Comment(
                new User("nome", "email@email.com", "password"),
                "Conteudo",
                Guid.NewGuid()
            );

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
            var comment = new Comment(
                new User("nome", "email@email.com", "password"),
                "Conteudo",
                Guid.NewGuid()
            );

            var mockTeste = new Mock<IUpdateDB<Comment>>();

            var commentRepository = new CommentRepository(mockTeste.Object);

            commentRepository.Update(comment);

            mockTeste.Verify(x => x.UpdateRegister(It.IsAny<Comment>()));
        }

        [Fact]
        public void TestEntityDelete()
        {
            var comment = new Comment(
                new User("nome", "email@email.com", "password"),
                "Conteudo",
                Guid.NewGuid()
            );

            var mockTeste = new Mock<IDeleteDB<Comment>>();

            var commentRepository = new CommentRepository(mockTeste.Object);

            commentRepository.Delete(comment);

            mockTeste.Verify(x => x.DeleteRegister(It.IsAny<Comment>()));
        }

        [Fact]
        public void TestValidationComment()
        {
            var okUser = new User("Nome teste", "email123@email.com", "123456789");
            new UserRepository().Create(okUser);

            var badUser = new User("Nome teste", "", "12345");

            var topic = new Topic("topico");
            new TopicRepository().Create(topic);

            var okPublication = new Publication(
                okUser,
                "Titulo",
                "Conteudo",
                topic
            );
            new PublicationRepository().Create(okPublication);

            var badPublication = new Publication(
                badUser,
                "Titulo",
                "Conteudo",
                topic
            );

            var okComment = new Comment(
                okUser,
                "Conteudo",
                okPublication.Id
            );

            var badComment1 = new Comment(
                badUser,
                "Conteudo",
                okPublication.Id
            );

            var badComment2 = new Comment(
                okUser,
                "   ",
                okPublication.Id
            );

            var badComment3 = new Comment(
                okUser,
                "Conteudo",
                badPublication.Id
            );

            var resultValidation1 = new CommentValidator().Validate(okComment);
            var resultValidation2 = new CommentValidator().Validate(badComment1);
            var resultValidation3 = new CommentValidator().Validate(badComment2);
            var resultValidation4 = new CommentValidator().Validate(badComment3);

            Assert.True(resultValidation1.IsValid);
            Assert.False(resultValidation2.IsValid);
            Assert.False(resultValidation3.IsValid);
            Assert.False(resultValidation4.IsValid);
        }

        [Fact]
        public void TestValidationCommentExist()
        {
            var user = new User("Nome teste", "email123@email.com", "123456789");
            new UserRepository().Create(user);

            var topic = new Topic("topico");
            new TopicRepository().Create(topic);

            var publication = new Publication(
                user,
                "Titulo",
                "Conteudo",
                topic
            );
            new PublicationRepository().Create(publication);

            var okComment = new Comment(
                user,
                "Conteudo",
                publication.Id
            );
            new CommentRepository().Create(okComment);

            var badComment = new Comment(
                user,
                "Conteudo",
                publication.Id
            );

            var resultValidation1 = new CommentExistValidator().Validate(okComment.Id);
            var resultValidation2 = new CommentExistValidator().Validate(badComment.Id);

            Assert.True(resultValidation1.IsValid);
            Assert.False(resultValidation2.IsValid);
        }
    }
}
