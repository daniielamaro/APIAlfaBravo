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
    public class InfrastructureTestPublication
    {
        private readonly IPublicationRepository publicationRepository;
        private MemoryCache memoryCache;

        public InfrastructureTestPublication()
        {
            publicationRepository = new PublicationRepository();
            memoryCache = MemoryCache.Default;
        }

        [Fact]
        public void TestCreate()
        {
            User user = new User ("Raul Santiago", "raul@gmail.com", "1203456789");
            Topic topic = new Topic("Esporte");
            Publication publication = new Publication(user, "Skate", "O melhor esporte", topic);
            var resultValidation = new PublicationValidator().Validate(publication);
            if (resultValidation.IsValid)
            {
                publicationRepository.Create(publication);
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(60);
                Assert.IsTrue(memoryCache.Add("publication", publication, policy));
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
                publicationRepository.Create(publication);                
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(60);
                memoryCache.Add("publicationRevome", publication, policy);
                Publication publicationGet = (Publication)memoryCache["publicationRevome"];
                Assert.AreEqual(publication.ToString(), publicationGet.ToString());
                memoryCache.Remove("publicationRevome");
                publicationGet = (Publication)memoryCache["publicationRevome"];
                Assert.IsNull(publicationGet);

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
                publicationRepository.Create(publication);
                var id = publication.Id;
                var idGet = publicationRepository.GetById(id);
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(60);
                memoryCache.Add("publicationGetId", publication, policy);
                Publication publicationGet = (Publication)memoryCache["publicationGetId"];                
                Assert.IsTrue(idGet.Id == publicationGet.Id);
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
                publicationRepository.Create(publication);
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(120);
                memoryCache.Add("publicationUpdate", publication, policy);
                Publication publicationGet = (Publication)memoryCache["publicationUpdate"];
                Assert.AreEqual(publication.ToString(), publicationGet.ToString());
                User user2 = new User("Raul Luar", "raull@gmail.com", "120345678109");
                Topic topic2 = new Topic("Cultura");
                Publication publication2 = new Publication(user2, "Musica", "A melhor musica", topic2);
                memoryCache.Set("publicationUpdate", publication2, policy);
                publicationGet = (Publication)memoryCache["publicationUpdate"];
                Assert.IsTrue(publication.Title != publicationGet.Title);
            }
        }

        [Fact]
        public void TestGetAll()
        {
            User user = new User("Raul Santiago", "raul@gmail.com", "1203456789");
            Topic topic = new Topic("Esporte");
            Publication publication1 = new Publication(user, "Skate", "O melhor esporte", topic);

            User user2 = new User("Raul Luar", "raull@gmail.com", "120345678109");
            Topic topic2 = new Topic("Cultura");
            Publication publication2 = new Publication(user2, "Musica", "A melhor musica", topic2);

            Publication publication3 = new Publication(user2, "Musica", "A melhor musica", topic2);

            var resultValidation1 = new PublicationValidator().Validate(publication1);
            var resultValidation2 = new PublicationValidator().Validate(publication2);
            var resultValidation3 = new PublicationValidator().Validate(publication3);
            if (resultValidation1.IsValid & resultValidation2.IsValid & resultValidation3.IsValid)
            {
                publicationRepository.Create(publication1);
                publicationRepository.Create(publication2);
                publicationRepository.Create(publication3);
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(120);
                memoryCache.Add("publication1", publication1, policy);
                memoryCache.Add("publication2", publication2, policy);
                memoryCache.Add("publication3", publication3, policy);
                List<Publication> listPublications = publicationRepository.GetAll();
                Assert.IsTrue(memoryCache.GetCount() == listPublications.Count);
            }
        }

    }
}