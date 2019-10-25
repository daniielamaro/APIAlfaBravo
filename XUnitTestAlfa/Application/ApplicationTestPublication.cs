using Application.Entity;
using Application.Repository;
using Autofac;
using Domain;
using Infrastructure.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestAlfa.Application
{
    public class ApplicationTestPublication : IClassFixture<ConfigAutofac.ConfigAutofac>
    {
        private readonly IPublicationRepository pub;

        public ApplicationTestPublication(ConfigAutofac.ConfigAutofac config)
        {
            pub = config.Container.Resolve<IPublicationRepository>();
        }

        [Fact]
        public void TestEntityCreate()
        {
            var pub1 = new Publication(
                new User("teste", "teste", "teste"),
                "Primeiro",
                "Conteudo",
                new Topic("topico")
            );

            var mockTeste = new Mock<IRegisterDB<Publication>>();

            var publicationRepository = new PublicationRepository(mockTeste.Object);

            publicationRepository.Create(pub1);

            mockTeste.Verify(x => x.CreateNew(It.IsAny<Publication>()));
        }
    }
}
