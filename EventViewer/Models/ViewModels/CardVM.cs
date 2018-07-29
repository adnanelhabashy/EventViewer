using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventViewer.Models.ViewModels
{
    public class CardVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Department { get; set; }
        public string ImageName { get; set; }
        public Nullable<int> CardNumber { get; set; }
    }
}