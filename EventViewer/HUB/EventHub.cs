using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using EventStore.ClientAPI;
using System.Text;
using Microsoft.AspNet.SignalR.Hubs;

namespace EventViewer.HUB
{
    [HubName("EventHub")]
    public class EventHub : Hub
    {
        [HubMethodName("announce")]
        public void Announce(string message)
        {
            Clients.All.Announce(message);
        }

        public void GetNow()
        {
            DateTime timenow = DateTime.Now;
            Clients.Caller.GetDate(timenow);
        }
        
        public DateTime getServerDateTime()
        {
            return DateTime.Now;
        }
       
    }
}