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
    }
}
