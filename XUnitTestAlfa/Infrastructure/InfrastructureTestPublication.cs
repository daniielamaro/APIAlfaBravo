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
                Publication publication = PublicationBuilder.New().Build();

                // Produção através dos métodos
                new CreatePublication().CreateNewRegister(publication);
                var idGet = new GetPublication().GetRegisterById(publication.Id);
                Assert.IsNotNull(idGet);
        }  

        [Fact]
        public void TestDelete()
        {
            Publication publication = PublicationBuilder.New().Build();

            // Produção através dos métodos
            new CreatePublication().CreateNewRegister(publication);
            new DeletePublication().DeleteRegister(publication);
            var idGet = new GetPublication().GetRegisterById(publication.Id);                            
            Assert.IsNull(idGet);
        }

        [Fact]
        public void TestGetById()
        {
            Publication publication = PublicationBuilder.New().Build();

            // Produção através dos métodos
            new CreatePublication().CreateNewRegister(publication);
            var idGet = new GetPublication().GetRegisterById(publication.Id);                
            Assert.IsNotNull(idGet);
        }

        [Fact]
        public void TestUpdate()
        {
            Publication publication = PublicationBuilder.New().Build();
            new CreatePublication().CreateNewRegister(publication);

            var publicationAlter = PublicationBuilder.New().WithId(publication.Id).WithTitle("Teste API").Build();

            new UpdatePublication().UpdateRegister(publicationAlter);

            Assert.IsTrue(publicationAlter.Title.ToString() != publication.Title.ToString());
            Assert.IsTrue(publicationAlter.Id.ToString() == publication.Id.ToString());
        }

        [Fact]
        public void TestGetAll()
        {

            Publication publicationFirst = PublicationBuilder.New().Build();
            Publication publicationSecond = PublicationBuilder.New().Build();
            Publication publicationThird = PublicationBuilder.New().Build();

            // Produção através dos métodos
            new CreatePublication().CreateNewRegister(publicationFirst);
            new CreatePublication().CreateNewRegister(publicationSecond);
            new CreatePublication().CreateNewRegister(publicationThird);
            List<Publication> listPublications = new GetPublication().GetAllRegister();                                
            Assert.IsTrue(3 == listPublications.Count);
        }

    }
}