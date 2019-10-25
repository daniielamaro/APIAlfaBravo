using Application.Repository;
using Domain;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Entity
{
    
    public class PublicationRepository : IPublicationRepository
    {
        public IRegisterDB<Publication> Register;

        public PublicationRepository()
        {
            Register = new RegisterPublication();
        }

        public PublicationRepository(IRegisterDB<Publication> register)
        {
            Register = register;
        }

        public Publication Create(Publication publication)
        {
            Register.CreateNew(publication);

            return publication;
        }

        public Publication Delete(Guid id)
        {
            Publication publication = GetById(id);
            //Context.Remove(publication);
            //Context.SaveChanges();

            return publication;
        }

        public List<Publication> GetAll()
        {
            /*List<Publication> publications = Context.Publications
                .Include(x => x.Autor)
                .Include(x => x.Comments)
                .Include(x => x.Topic)
                .ToList();
            return publications;*/
            return new List<Publication>();
        }

        public Publication GetById(Guid id)
        {
            /* Publication publication = Context.Publications
                 .AsNoTracking()
                 .Where(x => x.Id == id)
                 .Include(x => x.Autor)
                 .Include(x => x.Comments)
                 .Include(x => x.Topic)
                 .FirstOrDefault();

             return publication; */

            return new Publication();
        }

        public List<Publication> GetByName(string name)
        {
            /*List<Publication> publications = Context.Publications
                .Where(x => x.Autor.Name.ToLower().Contains(name.ToLower()))
                .Include(x => x.Autor)
                .Include(x => x.Comments)
                .Include(x => x.Topic)
                .ToList();
            return publications; */
            return new List<Publication>();
        }

        public Publication Update(Publication publication)
        {
            //Context.Update(publication);
            //Context.SaveChanges();

            return publication;
        }
    }
}
