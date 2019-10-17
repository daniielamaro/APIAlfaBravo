using Domain;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<Publication> GetAll()
        {
            List<Publication> publications = ApiContext.Publications
                .Include(x => x.Autor)
                .Include(x => x.Comments)
                .Include(x => x.Topic)
                .ToList();
            return publications;
        }

        public Publication GetById(Guid id)
        {
            Publication publication = ApiContext.Publications
                .Where(x => x.Id == id)
                .Include(x => x.Autor)
                .Include(x => x.Comments)
                .Include(x => x.Topic)
                .FirstOrDefault();

            return publication;
        }

        public List<Publication> GetByName(string name)
        {
            List<Publication> publications = ApiContext.Publications
                .Where(x => x.Autor.Name.ToLower().Contains(name.ToLower()))
                .Include(x => x.Autor)
                .Include(x => x.Comments)
                .Include(x => x.Topic)
                .ToList();
            return publications;
        }

        public Publication Update(Guid id, Publication publication)
        {
            ApiContext.Entry(publication).State = EntityState.Modified;
            ApiContext.SaveChanges();

            return publication;
        }
    }
}
