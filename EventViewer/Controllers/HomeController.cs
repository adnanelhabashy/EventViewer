using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventStore.ClientAPI;
using EventStore.ClientAPI.SystemData;
using System.Net;
using System.Threading.Tasks;
using EventViewer.Models.ViewModels;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using EventStore.ClientAPI.Projections;
using EventStore.ClientAPI.Common.Log;
using EventViewer.Models;
using Microsoft.Owin.Hosting;


namespace EventViewer.Controllers
{
    
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
           
            return View();
        }
      

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        
    }
}