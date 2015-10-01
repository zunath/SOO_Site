using System;
using System.Reflection;
using System.Web.Optimization;
using Autofac;
using Autofac.Integration.SignalR;
using Microsoft.AspNet.SignalR;

namespace SOOSite
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterHubs(Assembly.GetExecutingAssembly());
            GlobalHost.DependencyResolver = new AutofacDependencyResolver(builder.Build());
        }
    }
}