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

        [Fact]
        public void TestValidationTopic()
        {
            var okTopic = new Topic("Nome");
            var badTopic1 = new Topic("");
            var badTopic2 = new Topic("  ");
            var badTopic3 = new Topic("Nome");

            new TopicRepository().Create(okTopic);

            var resultValidation1 = new TopicValidator().Validate(okTopic);
            var resultValidation2 = new TopicValidator().Validate(badTopic1);
            var resultValidation3 = new TopicValidator().Validate(badTopic2);
            var resultValidation4 = new TopicValidator().Validate(badTopic3);

            Assert.True(resultValidation1.IsValid);
            Assert.False(resultValidation2.IsValid);
            Assert.False(resultValidation3.IsValid);
            Assert.False(resultValidation4.IsValid);
        }

        [Fact]
        public void TestValidationTopicExist()
        {
            var topic1 = new Topic("Nome teste 1");
            var topic2 = new Topic("Nome teste 2");

            new TopicRepository().Create(topic1);

            var resultValidation1 = new TopicExistValidator().Validate(topic1.Id);
            var resultValidation2 = new TopicExistValidator().Validate(topic2.Id);

            Assert.True(resultValidation1.IsValid);
            Assert.False(resultValidation2.IsValid);
        }
    }
}
