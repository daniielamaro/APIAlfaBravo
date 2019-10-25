using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Runtime.Caching;
using Xunit;
using Application.Repository;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using Application.BusinessRules;
using Application.Entity;

namespace XUnitTestAlfa
{
    public class ApplicationTestTopic
    {
        private readonly ITopicRepository topicRepository;
        private MemoryCache memoryCache;

        public ApplicationTestTopic()
        {
            topicRepository = new TopicRepository();
            memoryCache = MemoryCache.Default;
        }       

        [Fact]
        public void TopicCreater()
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
    }
}
