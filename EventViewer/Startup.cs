using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;
using System;
using System.Net;

[assembly: OwinStartupAttribute(typeof(EventViewer.Startup))]
namespace EventViewer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            ConfigureAuth(app);
            //var config = new HubConfiguration { EnableCrossDomain = true };
            //app.MapHubs(config);
            


           
        }
    }
}
