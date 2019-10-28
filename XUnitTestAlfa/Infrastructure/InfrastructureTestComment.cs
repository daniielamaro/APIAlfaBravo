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
        private readonly ICommentRepository commentRepository;
        private MemoryCache memoryCache;

        public InfrastructureTestComment()
        {
            commentRepository = new CommentRepository();
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
                commentRepository.Create(comment);
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(60);
                Assert.IsTrue(memoryCache.Add("comment", comment, policy));
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
                new CreateComment().CreateNewRegister(comment);
                var id = comment.Id;
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(60);
                memoryCache.Add("commentRevome", comment, policy);
                Comment commentGet = (Comment)memoryCache["commentRevome"];
                Assert.AreEqual(comment.ToString(), commentGet.ToString());
                memoryCache.Remove("commentRevome");
                commentGet = (Comment)memoryCache["commentRevome"];
                Assert.IsNull(commentGet);
                new DeleteComment().DeleteRegister(comment);
                var idGet = new GetComment().GetRegisterById(comment.Id);
                Assert.IsNull(idGet);

                /*

                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(60);
                memoryCache.Add("commentRevome", comment, policy);
                Comment commentGet = (Comment)memoryCache["commentRevome"];
                Assert.AreEqual(comment.ToString(), commentGet.ToString());
                memoryCache.Remove("commentRevome");
                commentGet = (Comment)memoryCache["commentRevome"];
                Assert.IsNull(commentGet);
                */
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
                commentRepository.Create(comment);
                var id = comment.Id;
                var idGet = commentRepository.GetById(id);
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(60);
                memoryCache.Add("commentGetId", comment, policy);
                Comment commentGet = (Comment)memoryCache["commentGetId"];                
                Assert.IsTrue(idGet.Id == commentGet.Id);
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
                commentRepository.Create(comment);
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(120);
                memoryCache.Add("commentUpdate", comment, policy);
                Comment commentGet = (Comment)memoryCache["commentUpdate"];
                Assert.AreEqual(comment.ToString(), commentGet.ToString());
                User user2 = new User("Raul Luar", "raull@gmail.com", "120345678109");
                Topic topic2 = new Topic("Cultura");
                Publication publication2 = new Publication(user2, "Skate8", "O melhor esporte 8", topic2);
                Comment comment2 = new Comment(user2, "Musica Nova", publication2.Id);
                memoryCache.Set("commentUpdate", comment2, policy);
                commentGet = (Comment)memoryCache["commentUpdate"];
                Assert.IsTrue(comment.Content != commentGet.Content);
            }
        }

        [Fact]
        public void TestGetAll()
        {

            User user = new User("Raul Santiago", "raul@gmail.com", "1203456789");
            Topic topic = new Topic("Esporte");
            Publication publication = new Publication(user, "Skate", "O melhor esporte", topic);            
            Comment comment1 = new Comment(user, "Skate é show", publication.Id);
            Comment comment2 = new Comment(user, "Skate8", publication.Id);
            Comment comment3 = new Comment(user, "Skate radical", publication.Id);
            var resultValidation1 = new CommentValidator().Validate(comment1);
            var resultValidation2 = new CommentValidator().Validate(comment2);
            var resultValidation3 = new CommentValidator().Validate(comment3);
            if (resultValidation1.IsValid & resultValidation2.IsValid & resultValidation3.IsValid)
            {
                commentRepository.Create(comment1);
                commentRepository.Create(comment2);
                commentRepository.Create(comment3);
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(120);
                memoryCache.Add("comment1", comment1, policy);
                memoryCache.Add("comment2", comment2, policy);
                memoryCache.Add("comment3", comment3, policy);
                List<Comment> listComments = commentRepository.GetAll();
                Assert.IsTrue(memoryCache.GetCount() == listComments.Count);
            }
        }

    }
}