using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emr.API.Models
{
    public class FullTripsInfoModel
    {
        public int userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string description { get; set; }
        public string profilepicture { get; set; }

        public string country { get; set; }
        public string town { get; set; }
        public string address { get; set; }
        public string date { get; set; }
        public string duration { get; set; }
        public string descriptionTrip { get; set; }
        public bool? isFutureTrip { get; set; }

        public int avgRating { get; set; }
        public List<FeedbackReceivedInfoModel> userFeedbackInfo { get; set; }
    }
}