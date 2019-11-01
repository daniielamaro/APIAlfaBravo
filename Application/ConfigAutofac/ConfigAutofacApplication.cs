using Application.Entity;
using Application.Repository;
using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ConfigAutofac
{
    public class ConfigAutofacApplication
    {
        public IContainer Container { get; private set; }

        public ConfigAutofacApplication()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<UserRepository>()
                .As<IUserRepository>()
                .InstancePerDependency();

            builder.RegisterType<TopicRepository>()
                .As<ITopicRepository>()
                .InstancePerDependency();

            builder.RegisterType<PublicationRepository>()
                .As<IPublicationRepository>()
                .InstancePerDependency();

            builder.RegisterType<CommentRepository>()
                .As<ICommentRepository>()
                .InstancePerDependency();

            Container = builder.Build();
        }
    }
}
