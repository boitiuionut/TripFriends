using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emr.API.Models
{
    public class TripInfoModel
    {
        public string country { get; set; }
        public string town { get; set; }
        public string address { get; set; }
        public string date { get; set; }
        public string duration { get; set; }
        public string description { get; set; }
        public bool? isFutureTrip { get; set; }
    }
}