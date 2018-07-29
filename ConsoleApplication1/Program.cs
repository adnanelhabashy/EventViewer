using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var esClient = EventStore.ClientAPI.EventStoreConnection.Create();
            esClient.Connect(new IPEndPoint(IPAddress.Loopback, 1113));

            using (WebApplication.Start<Startup>("http://localhost:8081"))
            {
                Console.WriteLine("SignalR Server running.");
                esClient.SubscribeToAll(true, SendToClient);
                Console.ReadLine();
            }
        }
    }
}
