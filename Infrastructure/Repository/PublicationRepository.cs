﻿using Domain;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository 
{
    
    public class PublicationRepository : IPublicationRepository
    {
        protected readonly ApiContext ApiContext;

        public PublicationRepository(ApiContext apiContext)
        {
            ApiContext = apiContext;
        }

        public Publication Create(Publication publication)
        {
            ApiContext.Users.Attach(publication.Autor);
            ApiContext.Topics.Attach(publication.Topic);
            ApiContext.Publications.Add(publication);
            ApiContext.SaveChanges();

            return publication;
        }

        public Publication Delete(Guid id)
        {
            Publication publication = ApiContext.Publications.Find(id);
            ApiContext.Remove(publication);
            ApiContext.SaveChanges();

            return publication;
        }

        public IEnumerable<Publication> ListAll()
        {
            return ApiContext.Publications.ToList();
        }
    }
}
