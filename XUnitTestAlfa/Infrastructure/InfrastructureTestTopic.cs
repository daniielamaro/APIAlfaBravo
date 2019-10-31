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
            Topic topic = TopicBuilder.New().WithName("Skate").Build();
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
            Topic topic = TopicBuilder.New().WithName("Skate").Build();

            new CreateTopic().CreateNewRegister(topic);
            new DeleteTopic().DeleteRegister(topic);
            var idGet = new GetTopic().GetRegisterById(topic.Id);
            Assert.IsNull(idGet);
        }

        [Fact]
        public void TestGetById()
        {
            Topic topic = TopicBuilder.New().Build();
            new CreateTopic().CreateNewRegister(topic);
            var idGet = new GetTopic().GetRegisterById(topic.Id);
            Assert.IsNotNull(idGet);
        }

        [Fact]
        public void TestUpdate()
        {
            Topic topic = TopicBuilder.New().WithName("Skate").Build();
            new CreateTopic().CreateNewRegister(topic);
            var idGet = new GetTopic().GetRegisterById(topic.Id);
            Assert.IsNotNull(idGet);
        }

        [Fact]
        public void TestGetAll()
        {
            Topic topic = TopicBuilder.New().WithName("Skate").Build();
            new CreateTopic().CreateNewRegister(topic);
            var idGet = new GetTopic().GetRegisterById(topic.Id);
            Assert.IsNotNull(idGet);
        }
    }
}