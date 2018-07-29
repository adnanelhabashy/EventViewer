using EventStore.ClientAPI;
using EventViewer.Models;
using EventViewer.Models.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EventViewer.Controllers
{
    public class FoodAllowanceController : Controller
    {
        //
        // GET: /FoodAllowance/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CardData()
        {
            string NodeName = "Node1";
            CardVM card = null;
            int cardNo;
            DateTime occurred;
            if (Session["Node"] != null)
            {
                NodeName = Session["Node"].ToString();
            }
            else
            {
                NodeName = "Node1";
            }

            using (IEventStoreConnection connection = EventStoreConnection.Create(new IPEndPoint(IPAddress.Loopback, 1113)))
            {
                connection.ConnectAsync();

                var result = Task.Run(() => connection.ReadStreamEventsBackwardAsync(NodeName, StreamPosition.End, 1, false));
                Task.WaitAll();
                var resultData = result.Result;
                foreach (var Event in resultData.Events)
                {
                    string strData = Encoding.UTF8.GetString(Event.Event.Data);
                    string strMeta = Encoding.UTF8.GetString(Event.Event.Metadata);
                    var datetimeConverter = new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" };
                    dynamic Eventdata = JsonConvert.DeserializeObject(strData);
                    dynamic EventMetadata = JsonConvert.DeserializeObject(strMeta);
                    if (Event.Event.EventType == "checkIn" || Event.Event.EventType == "checkOut")
                    {
                        cardNo = (int)EventMetadata.SelectToken("CardNumber");
                        if (cardNo != 0)
                        {
                            using (DB db = new DB())
                            {
                                card = new CardVM();
                                var cardInfo = db.CardInfoes.Where(x => x.CardNumber == cardNo).FirstOrDefault();
                                card.Id = cardInfo.Id;
                                card.Name = cardInfo.Name;
                                card.Title = cardInfo.Title;
                                card.Department = cardInfo.Department;
                                card.ImageName = cardInfo.ImageName;
                                card.CardNumber = cardInfo.CardNumber;
                            }
                        }
                        else
                        {
                            card = null;
                        }
                        occurred = (DateTime)Eventdata.SelectToken("occurred");

                    }
                }
            }

            return PartialView(card);
        }
	}
}