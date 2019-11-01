using Autofac;
using Domain;
using Infrastructure.Repository;
using Infrastructure.Repository.CommentDB;
using Infrastructure.Repository.PublicationDB;
using Infrastructure.Repository.TopicDB;
using Infrastructure.Repository.UserDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.ConfigAutofac
{
    public class ConfigAutofacInfrastructure
    {
        public IContainer Container { get; private set; }

        public ConfigAutofacInfrastructure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<CreateUser>()
                .As<ICreateDB<User>>()
                .InstancePerDependency();

            builder.RegisterType<UpdateUser>()
                .As<IUpdateDB<User>>()
                .InstancePerDependency();

            builder.RegisterType<GetUser>()
                .As<IGetDB<User>>()
                .InstancePerDependency();

            builder.RegisterType<DeleteUser>()
                .As<IDeleteDB<User>>()
                .InstancePerDependency();

            builder.RegisterType<CreateTopic>()
                .As<ICreateDB<Topic>>()
                .InstancePerDependency();

            builder.RegisterType<UpdateTopic>()
                .As<IUpdateDB<Topic>>()
                .InstancePerDependency();

            builder.RegisterType<GetTopic>()
                .As<IGetDB<Topic>>()
                .InstancePerDependency();

            builder.RegisterType<DeleteTopic>()
                .As<IDeleteDB<Topic>>()
                .InstancePerDependency();

            builder.RegisterType<CreatePublication>()
                .As<ICreateDB<Publication>>()
                .InstancePerDependency();

            builder.RegisterType<UpdatePublication>()
                .As<IUpdateDB<Publication>>()
                .InstancePerDependency();

            builder.RegisterType<GetPublication>()
                .As<IGetDB<Publication>>()
                .InstancePerDependency();

            builder.RegisterType<DeletePublication>()
                .As<IDeleteDB<Publication>>()
                .InstancePerDependency();

            builder.RegisterType<CreateComment>()
                .As<ICreateDB<Comment>>()
                .InstancePerDependency();

            builder.RegisterType<UpdateComment>()
                .As<IUpdateDB<Comment>>()
                .InstancePerDependency();

            builder.RegisterType<GetComment>()
                .As<IGetDB<Comment>>()
                .InstancePerDependency();

            builder.RegisterType<DeleteComment>()
                .As<IDeleteDB<Comment>>()
                .InstancePerDependency();

            Container = builder.Build();
        }
    }
}
