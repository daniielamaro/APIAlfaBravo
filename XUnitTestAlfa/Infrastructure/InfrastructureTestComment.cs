using Application.BusinessRules;
using Application.Entity;
using Application.Repository;
using Domain;
using System;
using System.Collections.Generic;
using Xunit;
using System.Runtime.Caching;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using Infrastructure.Repository.CommentDB;
using Infrastructure.Repository.UserDB;

namespace XUnitTestAlfa.Infrastructure
{
    public class InfrastructureTestComment
    {        
        private MemoryCache memoryCache;

        public InfrastructureTestComment()
        {
            memoryCache = MemoryCache.Default;
        }

        [Fact]
        public void TestCreate()
        {
            var comment = CommentBuilder.New().Build();

            // Conhecimento MemoryCache
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(60);
            Assert.IsTrue(memoryCache.Add("comment", comment, policy));
                
            // Produção através dos métodos
            new CreateComment().CreateNewRegister(comment);                
            var idGet = new GetComment().GetRegisterById(comment.Id);
            Assert.IsNotNull(idGet);
            
        }

        [Fact]
        public void TestDelete()
        {
            var comment = CommentBuilder.New().Build();

            // Conhecimento MemoryCache
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(60);
            memoryCache.Add("commentRemove", comment, policy);
            Comment commentGet = (Comment)memoryCache["commentRemove"];
            Assert.AreEqual(comment.ToString(), commentGet.ToString());
            memoryCache.Remove("commentRemove");
            commentGet = (Comment)memoryCache["commentRemove"];
            Assert.IsNull(commentGet);

            // Produção através dos métodos
            new CreateComment().CreateNewRegister(comment);
            new DeleteComment().DeleteRegister(comment);
            var idGet = new GetComment().GetRegisterById(comment.Id);
            Assert.IsNull(idGet);
            
        }

        [Fact]
        public void TestGetById()
        {
            var comment = CommentBuilder.New().WithId(new Guid()).Build();

            var resultValidation = new CommentValidator().Validate(comment);

            // Conhecimento MemoryCache                                                
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(60);
            memoryCache.Add("commentGetId", comment, policy);
            Comment commentGet = (Comment)memoryCache["commentGetId"];
            Assert.IsTrue(commentGet.Id == Guid.Parse("00000000-0000-0000-0000-000000000000"));

            // Produção através dos métodos
            new CreateComment().CreateNewRegister(comment);                
            var idGet = new GetComment().GetRegisterById(comment.Id);
            Assert.IsNotNull(idGet);
         
        }

        [Fact]
        public void TestUpdate()
        {
            var comment = CommentBuilder.New().Build();

            // Conhecimento MemoryCache                                                                
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(120);
            memoryCache.Add("commentUpdate", comment, policy);
            Comment commentGet = (Comment)memoryCache["commentUpdate"];
            Assert.AreEqual(comment.ToString(), commentGet.ToString());

            var secondComment = CommentBuilder.New().WithContent("AnotherContent").Build();
            memoryCache.Set("commentUpdate", secondComment, policy);
            commentGet = (Comment)memoryCache["commentUpdate"];
            Assert.IsTrue(comment.Content.ToString() != commentGet.Content.ToString());
                
            // Produção através dos métodos
            new CreateComment().CreateNewRegister(comment);
            var commentCopia = new GetComment().GetRegisterById(comment.Id);
            var thirdComment = CommentBuilder.New().WithId(commentCopia.Id).WithContent("SecondContent").Build();
            new UpdateComment().UpdateRegister(thirdComment);
            Assert.IsTrue(thirdComment.Content.ToString() != comment.Content.ToString());
            
        }

        [Fact]
        public void TestGetAll()
        {
            var firstComment = CommentBuilder.New().WithContent("FirstComment").Build();
            var secondComment = CommentBuilder.New().WithContent("SecondComment").Build();
            var thirdComment = CommentBuilder.New().WithContent("ThirdComment").Build();

            var resultValidationFirst = new CommentValidator().Validate(firstComment);
            var resultValidationSecond = new CommentValidator().Validate(secondComment);
            var resultValidationThird = new CommentValidator().Validate(thirdComment);

            // Conhecimento MemoryCache 
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(120);
            memoryCache.Add("firstComment", firstComment, policy);
            memoryCache.Add("secondComment", secondComment, policy);
            memoryCache.Add("thirdComment", thirdComment, policy);
            Assert.IsTrue(3 == memoryCache.GetCount());

            // Produção através dos métodos
            new CreateComment().CreateNewRegister(firstComment);
            new CreateComment().CreateNewRegister(secondComment);
            new CreateComment().CreateNewRegister(thirdComment);
            List<Comment> listComments = new GetComment().GetAllRegister();
            Assert.IsTrue(3 == listComments.Count);

        }

    }
}