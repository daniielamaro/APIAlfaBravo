using Application.Repository;
using Domain;
using Infrastructure.Repository;
<<<<<<< HEAD
=======
using Infrastructure.Repository.Publications;
>>>>>>> a15940ef19fd927d23fae7c0f3f0105e99844a0b
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Entity
{
    
    public class PublicationRepository : IPublicationRepository
    {
<<<<<<< HEAD
        protected readonly ApiContext ApiContext;

        public PublicationRepository()
        {
            ApiContext = new ApiContext();
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
            Publication publication = GetById(id);
            ApiContext.Remove(publication);
            ApiContext.SaveChanges();

            return publication;
        }

        public List<Publication> GetAll()
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
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Include(x => x.Autor)
                .Include(x => x.Comments)
                .Include(x => x.Topic)
                .FirstOrDefault();
=======
        public ICreateDB<Publication> Register;
        public IDeleteDB<Publication> Remove;
        public IGetDB<Publication> Get;
        public IUpdateDB<Publication> Alter;

        public PublicationRepository()
        {
            Register = new CreatePublication();
            Remove = new DeletePublication();
            Get = new GetPublication();
            Alter = new UpdatePublication();
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
>>>>>>> a15940ef19fd927d23fae7c0f3f0105e99844a0b

            return publication;
        }

<<<<<<< HEAD
        public List<Publication> GetByName(string name)
        {
            List<Publication> publications = ApiContext.Publications
                .Where(x => x.Autor.Name.ToLower().Contains(name.ToLower()))
                .Include(x => x.Autor)
                .Include(x => x.Comments)
                .Include(x => x.Topic)
                .ToList();
            return publications;
=======
        public List<Publication> GetAll()
        {
            return Get.GetAllRegister();
        }

        public Publication GetById(Guid id)
        {
            return Get.GetRegisterById(id);
>>>>>>> a15940ef19fd927d23fae7c0f3f0105e99844a0b
        }

        public Publication Update(Publication publication)
        {
<<<<<<< HEAD
            ApiContext.Update(publication);
            ApiContext.SaveChanges();

=======
            Alter.UpdateRegister(publication);
            return publication;
        }

        public Publication Delete(Publication publication)
        {
            Remove.DeleteRegister(publication);
>>>>>>> a15940ef19fd927d23fae7c0f3f0105e99844a0b
            return publication;
        }
    }
}
