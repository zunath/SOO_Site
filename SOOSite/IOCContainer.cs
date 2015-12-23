using Autofac;
using Autofac.Integration.SignalR;
using Microsoft.AspNet.SignalR;
using SOOSite.Data.Contexts;
using SOOSite.Data.Repositories;
using SOOSite.Interfaces.Repositories;
using SOOSite.Interfaces.Services;
using SOOSite.Services;
using System.Reflection;

namespace SOOSite
{
    public static class IOCContainer
    {
        public static void Build()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterHubs(Assembly.GetExecutingAssembly());
            builder.RegisterType<SOOContext>();

            // Repositories
            builder.RegisterType<AuthorizedDMRepository>().As<IAuthorizedDMRepository>();


            // Services
            builder.RegisterType<AuthorizedDMService>().As<IAuthorizedDMService>();

            GlobalHost.DependencyResolver = new AutofacDependencyResolver(builder.Build());
        }
    }
}