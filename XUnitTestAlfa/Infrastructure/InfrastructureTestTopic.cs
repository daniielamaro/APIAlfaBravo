using Application.BusinessRules;
using Application.Entity;
using Application.Repository;
using Domain;
using System;
using System.Collections.Generic;
using Xunit;
using System.Runtime.Caching;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using Infrastructure.Repository.TopicDB;

namespace XUnitTestAlfa.Infrastructure
{
    public class InfrastructureTestTopic
    {        
        private MemoryCache memoryCache;

        public InfrastructureTestTopic()
        {            
            memoryCache = MemoryCache.Default;
        }

        [Fact]
        public void TestCreate()
        {
            Topic topic = new Topic("Skate");
            var resultValidation = new TopicValidator().Validate(topic);
            if (resultValidation.IsValid)
            {
                // Conhecimento MemoryCache
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(60);
                Assert.IsTrue(memoryCache.Add("topic", topic, policy));

                // Produção através dos métodos
                new CreateTopic().CreateNewRegister(topic);
                var idGet = new GetTopic().GetRegisterById(topic.Id);
                Assert.IsNotNull(idGet);
            }
        }

        [Fact]
        public void TestDelete()
        {
            Topic topic = new Topic("Skate");
            var resultValidation = new TopicValidator().Validate(topic);
            if (resultValidation.IsValid)
            {
                // Conhecimento MemoryCache                
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(120);
                memoryCache.Add("topicRevome", topic, policy);
                Topic topicGet = (Topic)memoryCache["topicRevome"];
                Assert.AreEqual(topic.ToString(), topicGet.ToString());
                memoryCache.Remove("topicRevome");
                topicGet = (Topic)memoryCache["topicRevome"];
                Assert.IsNull(topicGet);

                // Produção através dos métodos
                new CreateTopic().CreateNewRegister(topic);
                new DeleteTopic().DeleteRegister(topic);
                var idGet = new GetTopic().GetRegisterById(topic.Id);                
                Assert.IsNull(idGet);
            }
        }

        [Fact]
        public void TestGetById()
        {
            Topic topic = new Topic(Guid.Parse("fea77e83-001a-4cb7-b7ed-eedb6deff57a"), "Skate");
            var resultValidation = new TopicValidator().Validate(topic);
            if (resultValidation.IsValid)
            {
                // Conhecimento MemoryCache
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(60);
                memoryCache.Add("topicGetId", topic, policy);
                Topic topicGet = (Topic)memoryCache["topicGetId"];                
                Assert.IsTrue(Guid.Parse("fea77e83-001a-4cb7-b7ed-eedb6deff57a") == topicGet.Id);

                // Produção através dos métodos
                new CreateTopic().CreateNewRegister(topic);
                var idGet = new GetTopic().GetRegisterById(topic.Id);
                Assert.IsNotNull(idGet);
            }
        }

        [Fact]
        public void TestUpdate()
        {
            Topic topic = new Topic("Skate");
            var resultValidation = new TopicValidator().Validate(topic);
            if (resultValidation.IsValid)
            {
                // Conhecimento MemoryCache                
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(120);
                memoryCache.Add("topicUpdate", topic, policy);
                Topic topicGet = (Topic)memoryCache["topicUpdate"];
                Assert.AreEqual(topic.ToString(), topicGet.ToString());
                Topic topicSecond = new Topic("Cultura");
                memoryCache.Set("topicUpdate", topicSecond, policy);
                topicGet = (Topic)memoryCache["topicUpdate"];
                Assert.IsTrue(topic.Name.ToString() != topicGet.Name.ToString());

                // Produção através dos métodos
                new CreateTopic().CreateNewRegister(topic);
                var topicCopia = new GetTopic().GetRegisterById(topic.Id);
                Topic topicThird = new Topic(topic.Id, "Comida");
                new UpdateTopic().UpdateRegister(topicThird);
                Assert.IsTrue(topicCopia.Id.ToString() == topic.Id.ToString());
                Assert.IsTrue(topicCopia.Name.ToString() != topicThird.Name.ToString());
            }
        }

        [Fact]
        public void TestGetAll()
        {
            Topic topicFirst = new Topic("Skate");
            Topic topicSecond = new Topic("Cultura");
            Topic topicThird = new Topic("Musica");
            var resultValidationFirst = new TopicValidator().Validate(topicFirst);
            var resultValidationSecond = new TopicValidator().Validate(topicSecond);
            var resultValidationThird = new TopicValidator().Validate(topicThird);
            if (resultValidationFirst.IsValid & resultValidationSecond.IsValid & resultValidationThird.IsValid)
            {
                // Conhecimento MemoryCache 
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(120);
                memoryCache.Add("topicFirst", topicFirst, policy);
                memoryCache.Add("topicSecond", topicSecond, policy);
                memoryCache.Add("topicThird", topicThird, policy);                
                Assert.IsTrue(memoryCache.GetCount() == 3);

                // Produção através dos métodos
                new CreateTopic().CreateNewRegister(topicFirst);
                new CreateTopic().CreateNewRegister(topicSecond);
                new CreateTopic().CreateNewRegister(topicThird);
                List<Topic> listTopics = new GetTopic().GetAllRegister();
                Assert.IsTrue(3 == listTopics.Count);
            }
        }

    }
}