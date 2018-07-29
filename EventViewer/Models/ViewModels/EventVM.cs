using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventViewer.Models.ViewModels
{
    public class EventVM
    {
        public long EventID { get; set; }
        public string EventType { get; set; }
        public string NodeCheckedNumber { get; set; }
        public DateTime occurred { get; set; }
    }
}