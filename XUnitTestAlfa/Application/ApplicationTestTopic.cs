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
            var okTopic = TopicBuilder.New().Build();

            var resultValidation1 = new TopicValidator().Validate(okTopic);
            
            Assert.True(resultValidation1.IsValid);    
        }

        [Fact]
        public void TestValidationBadTopicNameNull()
        {
            var badTopic = TopicBuilder.New().WithName(null).Build();

            var resultValidation = new TopicValidator().Validate(badTopic);

            Assert.False(resultValidation.IsValid);
        }

        [Fact]
        public void TestValidationBadTopic2()
        {
            var badTopic2 = TopicBuilder.New().WithName("  ").Build();

            var resultValidation = new TopicValidator().Validate(badTopic2);

            Assert.False(resultValidation.IsValid);
        }

        [Fact]
        public void TestValidationBadTopicNameExistsOnDatabase()
        {
            var topic = TopicBuilder.New().WithName("Nome").Build();

            new TopicRepository().Create(topic);

            var badTopic = new Topic("Nome");

            var resultValidation = new TopicValidator().Validate(badTopic);

            Assert.False(resultValidation.IsValid);
        }

        [Fact]
        public void TestValidationTopicExist()
        {
            var topic = TopicBuilder.New().WithName("Nome teste").Build();
           
            new TopicRepository().Create(topic);

            var resultValidation = new TopicExistValidator().Validate(topic.Id);
            
            Assert.True(resultValidation.IsValid);          
        }

        [Fact]
        public void TestValidationTopicNotExist()
        {
            var resultValidation = new TopicExistValidator().Validate(Guid.NewGuid());

            Assert.False(resultValidation.IsValid);
        }
    }
}
