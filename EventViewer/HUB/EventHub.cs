using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using EventStore.ClientAPI;
using System.Text;

namespace EventViewer.HUB
{
    public class EventHub : Hub
    {
        public void Announce(string message)
        {
            Clients.All.Announce(message);
        }

       
    }
}