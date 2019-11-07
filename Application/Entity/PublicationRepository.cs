using Application.Repository;
using Autofac;
using Domain;
using Infrastructure.ConfigAutofac;
using Infrastructure.Repository;
using Infrastructure.Repository.PublicationDB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Entity
{
    
    public class PublicationRepository : IPublicationRepository
    {
        public ICreateDB<Publication> Register;
        public IDeleteDB<Publication> Remove;
        public IGetDB<Publication> Get;
        public IUpdateDB<Publication> Alter;

        private readonly ConfigAutofacInfrastructure ConfigInjection;

        public PublicationRepository()
        {
            ConfigInjection = new ConfigAutofacInfrastructure();

            Register = ConfigInjection.Container.Resolve<ICreateDB<Publication>>();
            Remove = ConfigInjection.Container.Resolve<IDeleteDB<Publication>>();
            Get = ConfigInjection.Container.Resolve<IGetDB<Publication>>();
            Alter = ConfigInjection.Container.Resolve<IUpdateDB<Publication>>();
        }

        public PublicationRepository(ICreateDB<Publication> register)
        {
            Register = register;
        }

        public PublicationRepository(IDeleteDB<Publication> remove)
        {
            Remove = remove;
        }

        public PublicationRepository(IGetDB<Publication> get)
        {
            Get = get;
        }

        public PublicationRepository(IUpdateDB<Publication> alter)
        {
            Alter = alter;
        }

        public Publication Create(Publication publication)
        {
            Register.CreateNewRegister(publication);

            return publication;
        }

        public List<Publication> GetAll()
        {
            return Get.GetAllRegister();
        }

        public Publication GetById(Guid id)
        {
            return Get.GetRegisterById(id);
        }

        public Publication Update(Publication publication)
        {
            Alter.UpdateRegister(publication);
            return publication;
        }

        public Publication Delete(Publication publication)
        {
            Remove.DeleteRegister(publication);
            return publication;
        }
    }
}
