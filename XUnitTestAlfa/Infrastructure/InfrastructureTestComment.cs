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
            User user = new User("Raul Santiago", "raul@gmail.com", "1203456789");
            Topic topic = new Topic("Esporte");
            Publication publication = new Publication(user, "Skate", "O melhor esporte", topic);            
            Comment comment = new Comment(user, "Skate", publication.Id);
            var resultValidation = new CommentValidator().Validate(comment);
            if (resultValidation.IsValid)
            {
                // Conhecimento MemoryCache
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(60);
                Assert.IsTrue(memoryCache.Add("comment", comment, policy));
                
                // Produção através dos métodos
                new CreateComment().CreateNewRegister(comment);                
                var idGet = new GetComment().GetRegisterById(comment.Id);
                Assert.IsNotNull(idGet);
            }
        }

        [Fact]
        public void TestDelete()
        {
            User user = new User("Raul Santiago", "raul@gmail.com", "1203456789");
            Topic topic = new Topic("Esporte");
            Publication publication = new Publication(user, "Skate", "O melhor esporte", topic);
            Comment comment = new Comment(user, "Skate", publication.Id);            
            var resultValidation = new CommentValidator().Validate(comment);
            if (resultValidation.IsValid)
            {
                // Conhecimento MemoryCache
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(60);
                memoryCache.Add("commentRevome", comment, policy);
                Comment commentGet = (Comment)memoryCache["commentRevome"];
                Assert.AreEqual(comment.ToString(), commentGet.ToString());
                memoryCache.Remove("commentRevome");
                commentGet = (Comment)memoryCache["commentRevome"];
                Assert.IsNull(commentGet);

                // Produção através dos métodos
                new CreateComment().CreateNewRegister(comment);
                var idGet = new GetComment().GetRegisterById(comment.Id);
                new DeleteComment().DeleteRegister(comment);                
                Assert.IsNull(idGet);
            }
        }

        [Fact]
        public void TestGetById()
        {
            User user = new User("Raul Santiago", "raul@gmail.com", "1203456789");
            Topic topic = new Topic("Esporte");
            Publication publication = new Publication(user, "Skate", "O melhor esporte", topic);
            Comment comment = new Comment(Guid.Parse("fea77e83-001a-4cb7-b7ed-eedb6deff57a"), user, "Skate", publication.Id);            
            var resultValidation = new CommentValidator().Validate(comment);
            if (resultValidation.IsValid)
            {
                // Conhecimento MemoryCache                                                
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(60);
                memoryCache.Add("commentGetId", comment, policy);
                Comment commentGet = (Comment)memoryCache["commentGetId"];
                Assert.IsTrue(commentGet.Id == Guid.Parse("fea77e83-001a-4cb7-b7ed-eedb6deff57a"));

                // Produção através dos métodos
                new CreateComment().CreateNewRegister(comment);                
                var idGet = new GetComment().GetRegisterById(comment.Id);
                Assert.IsNotNull(idGet);
            }
        }

        [Fact]
        public void TestUpdate()
        {
            User user = new User("Raul Santiago", "raul@gmail.com", "1203456789");
            Topic topic = new Topic("Esporte");
            Publication publication = new Publication(user, "Skate", "O melhor esporte", topic);
            Comment comment = new Comment(Guid.Parse("fea77e83-001a-4cb7-b7ed-eedb6deff57a"), user, "Skate", publication.Id);
            var resultValidation = new CommentValidator().Validate(comment);
            if (resultValidation.IsValid)
            {
                // Conhecimento MemoryCache                                                                
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(120);
                memoryCache.Add("commentUpdate", comment, policy);
                Comment commentGet = (Comment)memoryCache["commentUpdate"];
                Assert.AreEqual(comment.ToString(), commentGet.ToString());
                User userSecond = new User("Raul Luar", "raull@gmail.com", "120345678109");
                Topic topicSecond = new Topic("Cultura");
                Publication publicationSecond = new Publication(userSecond, "Skate8", "O melhor esporte 8", topicSecond);
                Comment commentSecond = new Comment(userSecond, "Musica Nova", publicationSecond.Id);
                memoryCache.Set("commentUpdate", commentSecond, policy);
                commentGet = (Comment)memoryCache["commentUpdate"];
                Assert.IsTrue(comment.Content.ToString() != commentGet.Content.ToString());
                
                // Produção através dos métodos
                new CreateComment().CreateNewRegister(comment);
                var commentCopia = new GetComment().GetRegisterById(comment.Id);
                Comment commentThird = new Comment(comment.Id, user, "Skate é radical", publication.Id);
                new UpdateComment().UpdateRegister(commentThird);
                Assert.IsTrue(commentCopia.Content.ToString() != comment.Content.ToString());
            }
        }

        [Fact]
        public void TestGetAll()
        {

            User user = new User("Raul Santiago", "raul@gmail.com", "1203456789");
            Topic topic = new Topic("Esporte");
            Publication publication = new Publication(user, "Skate", "O melhor esporte", topic);            
            Comment commentFirst = new Comment(user, "Skate é show", publication.Id);
            Comment commentSecond = new Comment(user, "Skate8", publication.Id);
            Comment commentThird = new Comment(user, "Skate radical", publication.Id);
            var resultValidationFirst = new CommentValidator().Validate(commentFirst);
            var resultValidationSecond = new CommentValidator().Validate(commentSecond);
            var resultValidationThird = new CommentValidator().Validate(commentThird);
            if (resultValidationFirst.IsValid & resultValidationSecond.IsValid & resultValidationThird.IsValid)
            {
                // Conhecimento MemoryCache 
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(120);
                memoryCache.Add("commentFirst", commentFirst, policy);
                memoryCache.Add("commentSecond", commentSecond, policy);
                memoryCache.Add("commentThird", commentThird, policy);
                Assert.IsTrue(3 == memoryCache.GetCount());

                // Produção através dos métodos
                new CreateComment().CreateNewRegister(commentFirst);
                new CreateComment().CreateNewRegister(commentSecond);
                new CreateComment().CreateNewRegister(commentThird);
                List<Comment> listComments = new GetComment().GetAllRegister();
                Assert.IsTrue(3 == listComments.Count);
            }
        }

    }
}