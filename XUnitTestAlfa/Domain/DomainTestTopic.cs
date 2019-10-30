using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestAlfa.Domain
{
    public class DomainTestTopic
    {
        [Fact]
        public void TestCreate()
        {
            Topic topic = TopicBuilder.New().WithName("Nome teste").Build();

            Assert.True(topic.Id != Guid.Empty && topic.Id != null);
            Assert.True(topic.Name == "Nome teste");
        }
    }
}
