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
    public class ApplicationTestTopic
    {
        [Fact]
        public void TestEntityCreate()
        {
            var topic = new Topic("Nome teste");

            var mockTeste = new Mock<ICreateDB<Topic>>();

            var topicRepository = new TopicRepository(mockTeste.Object);

            topicRepository.Create(topic);

            mockTeste.Verify(x => x.CreateNewRegister(It.IsAny<Topic>()));
        }

        [Fact]
        public void TestEntityGetAll()
        {
            var mockTeste = new Mock<IGetDB<Topic>>();

            var topicRepository = new TopicRepository(mockTeste.Object);

            topicRepository.GetAll();

            mockTeste.Verify(x => x.GetAllRegister());
        }

        [Fact]
        public void TestEntityGetById()
        {
            var mockTeste = new Mock<IGetDB<Topic>>();

            var topicRepository = new TopicRepository(mockTeste.Object);

            topicRepository.GetById(Guid.NewGuid());

            mockTeste.Verify(x => x.GetRegisterById(It.IsAny<Guid>()));
        }

        [Fact]
        public void TestEntityUpdate()
        {
            var topic = new Topic("Nome teste");

            var mockTeste = new Mock<IUpdateDB<Topic>>();

            var topicRepository = new TopicRepository(mockTeste.Object);

            topicRepository.Update(topic);

            mockTeste.Verify(x => x.UpdateRegister(It.IsAny<Topic>()));
        }

        [Fact]
        public void TestEntityDelete()
        {
            var topic = new Topic("Nome teste");

            var mockTeste = new Mock<IDeleteDB<Topic>>();

            var topicRepository = new TopicRepository(mockTeste.Object);

            topicRepository.Delete(topic);

            mockTeste.Verify(x => x.DeleteRegister(It.IsAny<Topic>()));
        }
    }
}
