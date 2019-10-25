using System;
using System.Collections.Generic;
using System.Text;
using Application.Entity;
using Application.Repository;
using Autofac;

namespace XUnitTestAlfa.ConfigAutofac
{
    public class ConfigAutofac
    {
        public IContainer Container { get; private set; }

        public ConfigAutofac()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<PublicationRepository>()
                .As<IPublicationRepository>()
                .InstancePerDependency();

            Container = builder.Build();
        }
    }
}
