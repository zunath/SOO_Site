using System;

namespace SOOSite
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            IOCContainer.Build();
        }
    }
}