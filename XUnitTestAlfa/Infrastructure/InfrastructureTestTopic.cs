using Application.BusinessRules;
using Application.Entity;
using Application.Repository;
using Domain;
using System;
using System.Collections.Generic;
using Xunit;
using System.Runtime.Caching;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace XUnitTestAlfa.Infrastructure
{
    public class InfrastructureTestTopic
    {
        private readonly ITopicRepository topicRepository;
        private MemoryCache memoryCache;

        public InfrastructureTestTopic()
        {
            topicRepository = new TopicRepository();
            memoryCache = MemoryCache.Default;
        }

        [Fact]
        public void TestCreate()
        {
            Topic topic = new Topic("Skate");
            var resultValidation = new TopicValidator().Validate(topic);
            if (resultValidation.IsValid)
            {
                topicRepository.Create(topic);
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(60);
                Assert.IsTrue(memoryCache.Add("topic", topic, policy));
            }
        }

        [Fact]
        public void TestDelete()
        {
            Topic topic = new Topic("Skate");
            var resultValidation = new TopicValidator().Validate(topic);
            if (resultValidation.IsValid)
            {
                topicRepository.Create(topic);                
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(60);
                memoryCache.Add("topicRevome", topic, policy);
                Topic topicGet = (Topic)memoryCache["topicRevome"];
                Assert.AreEqual(topic.ToString(), topicGet.ToString());
                memoryCache.Remove("topicRevome");
                topicGet = (Topic)memoryCache["topicRevome"];
                Assert.IsNull(topicGet);

            }
        }

        [Fact]
        public void TestGetById()
        {
            Topic topic = new Topic(Guid.Parse("fea77e83-001a-4cb7-b7ed-eedb6deff57a"), "Skate");
            var resultValidation = new TopicValidator().Validate(topic);
            if (resultValidation.IsValid)
            {
                topicRepository.Create(topic);
                var id = topic.Id;
                var idGet = topicRepository.GetById(id);
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(60);
                memoryCache.Add("topicGetId", topic, policy);
                Topic topicGet = (Topic)memoryCache["topicGetId"];                
                Assert.IsTrue(idGet.Id == topicGet.Id);
            }
        }

        [Fact]
        public void TestUpdate()
        {
            Topic topic = new Topic("Skate");
            var resultValidation = new TopicValidator().Validate(topic);
            if (resultValidation.IsValid)
            {
                topicRepository.Create(topic);
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(120);
                memoryCache.Add("topicUpdate", topic, policy);
                Topic topicGet = (Topic)memoryCache["topicUpdate"];
                Assert.AreEqual(topic.ToString(), topicGet.ToString());
                Topic topic2 = new Topic("Cultura");
                memoryCache.Set("topicUpdate", topic2, policy);
                topicGet = (Topic)memoryCache["topicUpdate"];                
                Assert.IsTrue(topic.Name != topicGet.Name);
            }
        }

        [Fact]
        public void TestGetAll()
        {
            Topic topic1 = new Topic("Skate");
            Topic topic2 = new Topic("Cultura");
            Topic topic3 = new Topic("Musica");
            var resultValidation1 = new TopicValidator().Validate(topic1);
            var resultValidation2 = new TopicValidator().Validate(topic2);
            var resultValidation3 = new TopicValidator().Validate(topic3);
            if (resultValidation1.IsValid & resultValidation2.IsValid & resultValidation3.IsValid)
            {
                topicRepository.Create(topic1);
                topicRepository.Create(topic2);
                topicRepository.Create(topic3);
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(120);
                memoryCache.Add("topic1", topic1, policy);
                memoryCache.Add("topic2", topic2, policy);
                memoryCache.Add("topic3", topic3, policy);
                List<Topic> listTopics = topicRepository.GetAll();
                Assert.IsTrue(memoryCache.GetCount() == listTopics.Count);
            }
        }

    }
}