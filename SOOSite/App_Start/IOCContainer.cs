using Autofac;
using Autofac.Integration.SignalR;
using Microsoft.AspNet.SignalR;
using SOOSite.Data.Contexts;
using SOOSite.Data.Repositories;
using SOOSite.Interfaces.Repositories;
using SOOSite.Interfaces.Services;
using SOOSite.Services;
using System.Reflection;
using SOOSite.Common.GFFParser;

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
            builder.RegisterType<KeyItemRepository>().As<IKeyItemRepository>();
            builder.RegisterType<ModuleEditorRepository>().As<IModuleEditorRepository>();

            // Services
            builder.RegisterType<AuthorizedDMService>().As<IAuthorizedDMService>();
            builder.RegisterType<KeyItemService>().As<IKeyItemService>();
            builder.RegisterType<ModuleEditorService>().As<IModuleEditorService>();

            builder.RegisterType<ModuleReader>();

            GlobalHost.DependencyResolver = new AutofacDependencyResolver(builder.Build());
        }
    }
}