using Application.BusinessRules;
using Application.Entity;
using Application.Repository;
using Domain;
using System;
using System.Collections.Generic;
using Xunit;
using System.Runtime.Caching;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using Infrastructure.Repository.PublicationDB;

namespace XUnitTestAlfa.Infrastructure
{
    public class InfrastructureTestPublication
    {        
        private MemoryCache memoryCache;

        public InfrastructureTestPublication()
        {     
            memoryCache = MemoryCache.Default;
        }

        [Fact]
        public void TestCreate()
        {
            User user = new User("Raul Santiago", "raul@gmail.com", "1203456789");
            Topic topic = new Topic("Esporte");
            Publication publication = new Publication(user, "Skate", "O melhor esporte", topic);
            var resultValidation = new PublicationValidator().Validate(publication);
            if (resultValidation.IsValid)
            {
                // Conhecimento MemoryCache
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(60);
                Assert.IsTrue(memoryCache.Add("publication", publication, policy));

                // Produção através dos métodos
                new CreatePublication().CreateNewRegister(publication);
                var idGet = new GetPublication().GetRegisterById(publication.Id);
                Assert.IsNotNull(idGet);
            }
        }  

        [Fact]
        public void TestDelete()
        {
            User user = new User("Raul Santiago", "raul@gmail.com", "1203456789");
            Topic topic = new Topic("Esporte");
            Publication publication = new Publication(user, "Skate", "O melhor esporte", topic);
            var resultValidation = new PublicationValidator().Validate(publication);
            if (resultValidation.IsValid)
            {
                // Conhecimento MemoryCache                
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(60);
                memoryCache.Add("publicationRevome", publication, policy);
                Publication publicationGet = (Publication)memoryCache["publicationRevome"];
                Assert.AreEqual(publication.ToString(), publicationGet.ToString());
                memoryCache.Remove("publicationRevome");
                publicationGet = (Publication)memoryCache["publicationRevome"];
                Assert.IsNull(publicationGet);

                // Produção através dos métodos
                new CreatePublication().CreateNewRegister(publication);
                var idGet = new GetPublication().GetRegisterById(publication.Id);
                new DeletePublication().DeleteRegister(publication);                                
                Assert.IsNull(idGet);
            }
        }

        [Fact]
        public void TestGetById()
        {
            User user = new User("Raul Santiago", "raul@gmail.com", "1203456789");
            Topic topic = new Topic("Esporte");
            Publication publication = new Publication(Guid.Parse("fea77e83-001a-4cb7-b7ed-eedb6deff57a"), user, "Skate", "O melhor esporte", DateTime.Now, new List<Comment>(), topic);            
            var resultValidation = new PublicationValidator().Validate(publication);
            if (resultValidation.IsValid)
            {
                // Conhecimento MemoryCache
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(60);
                memoryCache.Add("publicationGetId", publication, policy);
                Publication publicationGet = (Publication)memoryCache["publicationGetId"];                
                Assert.IsTrue(publicationGet.Id == Guid.Parse("fea77e83-001a-4cb7-b7ed-eedb6deff57a"));

                // Produção através dos métodos
                new CreatePublication().CreateNewRegister(publication);
                var idGet = new GetPublication().GetRegisterById(publication.Id);                
                Assert.IsNotNull(idGet);
            }
        }

        [Fact]
        public void TestUpdate()
        {
            User user = new User("Raul Santiago", "raul@gmail.com", "1203456789");
            Topic topic = new Topic("Esporte");
            Publication publication = new Publication(user, "Skate", "O melhor esporte", topic);
            var resultValidation = new PublicationValidator().Validate(publication);
            if (resultValidation.IsValid)
            {
                // Conhecimento MemoryCache                
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(120);
                memoryCache.Add("publicationUpdate", publication, policy);
                Publication publicationGet = (Publication)memoryCache["publicationUpdate"];
                Assert.AreEqual(publication.ToString(), publicationGet.ToString());
                User userSegundo = new User("Raul Luar", "raull@gmail.com", "120345678109");
                Topic topicSegundo = new Topic("Cultura");
                Publication publicationSegundo = new Publication(userSegundo, "Musica", "A melhor musica", topicSegundo);
                memoryCache.Set("publicationUpdate", publicationSegundo, policy);
                publicationGet = (Publication)memoryCache["publicationUpdate"];
                Assert.IsTrue(publication.Title.ToString() != publicationGet.Title.ToString());

                // Produção através dos métodos
                new CreatePublication().CreateNewRegister(publication);
                var publicationCopia = new GetPublication().GetRegisterById(publication.Id);
                List<Comment> listComments = new List<Comment>();
                Publication publicationTerceiro = new Publication(publication.Id, user, "Skate é radical", "O melhor esporte", DateTime.Now, listComments, topic);
                new UpdatePublication().UpdateRegister(publicationTerceiro);
                Assert.IsTrue(publicationCopia.Title.ToString() != publication.Title.ToString());
                Assert.IsTrue(publicationCopia.Id.ToString() == publication.Id.ToString());
            }
        }

        [Fact]
        public void TestGetAll()
        {
            User userPrimeiro = new User("Raul Santiago", "raul@gmail.com", "1203456789");
            Topic topicPrimeiro = new Topic("Esporte");
            Publication publicationPrimeiro = new Publication(userPrimeiro, "Skate", "O melhor esporte", topicPrimeiro);
            User userSegundo = new User("Raul Luar", "raull@gmail.com", "120345678109");
            Topic topicSegundo = new Topic("Cultura");
            Publication publicationSegundo = new Publication(userSegundo, "Musica", "A melhor musica", topicSegundo);
            Publication publicationTerceiro = new Publication(userSegundo, "Musica", "A melhor musica", topicSegundo);
            var resultValidationPrimeiro = new PublicationValidator().Validate(publicationPrimeiro);
            var resultValidationSegundo = new PublicationValidator().Validate(publicationSegundo);
            var resultValidationTerceiro = new PublicationValidator().Validate(publicationTerceiro);
            if (resultValidationPrimeiro.IsValid & resultValidationSegundo.IsValid & resultValidationTerceiro.IsValid)
            {
                // Conhecimento MemoryCache 
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(120);
                memoryCache.Add("publicationPrimeiro", publicationPrimeiro, policy);
                memoryCache.Add("publicationSegundo", publicationSegundo, policy);
                memoryCache.Add("publicationTerceiro", publicationTerceiro, policy);
                Assert.IsTrue(memoryCache.GetCount() == 3);

                // Produção através dos métodos
                new CreatePublication().CreateNewRegister(publicationPrimeiro);
                new CreatePublication().CreateNewRegister(publicationSegundo);
                new CreatePublication().CreateNewRegister(publicationTerceiro);
                List<Publication> listPublications = new GetPublication().GetAllRegister();                                
                Assert.IsTrue(3 == listPublications.Count);
            }
        }

    }
}