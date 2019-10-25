using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Repository;
using Domain;
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

        public TopicRepository()
        {
            Register = new CreateTopic();
            Remove = new DeleteTopic();
            Get = new GetTopic();
            Alter = new UpdateTopic();
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
