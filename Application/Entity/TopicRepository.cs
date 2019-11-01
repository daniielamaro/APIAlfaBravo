using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Repository;
using Autofac;
using Domain;
using Infrastructure.ConfigAutofac;
using Infrastructure.Context;
using Infrastructure.Repository;
using Infrastructure.Repository.TopicDB;
using Microsoft.EntityFrameworkCore;

namespace Application.Entity
{
    public class TopicRepository : ITopicRepository
    {
        public ICreateDB<Topic> Register;
        public IDeleteDB<Topic> Remove;
        public IGetDB<Topic> Get;
        public IUpdateDB<Topic> Alter;

        private readonly ConfigAutofacInfrastructure ConfigInjection;

        public TopicRepository()
        {
            ConfigInjection = new ConfigAutofacInfrastructure();

            Register = ConfigInjection.Container.Resolve<ICreateDB<Topic>>();
            Remove = ConfigInjection.Container.Resolve<IDeleteDB<Topic>>();
            Get = ConfigInjection.Container.Resolve<IGetDB<Topic>>();
            Alter = ConfigInjection.Container.Resolve<IUpdateDB<Topic>>();
        }

        public TopicRepository(ICreateDB<Topic> register)
        {
            Register = register;
        }

        public TopicRepository(IDeleteDB<Topic> remove)
        {
            Remove = remove;
        }

        public TopicRepository(IGetDB<Topic> get)
        {
            Get = get;
        }

        public TopicRepository(IUpdateDB<Topic> alter)
        {
            Alter = alter;
        }

        public Topic Create(Topic topic)
        {
            Register.CreateNewRegister(topic);

            return topic;
        }

        public Topic Delete(Topic topic)
        {
            Remove.DeleteRegister(topic);

            return topic;
        }

        public List<Topic> GetAll()
        {
            return Get.GetAllRegister();
        }

        public Topic GetById(Guid id)
        {
            return Get.GetRegisterById(id);
        }

        public Topic Update(Topic topic)
        {
            Alter.UpdateRegister(topic);

            return topic;
        }
    }
}
