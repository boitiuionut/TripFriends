using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emr.API.Models
{
    public class FeedbackInfoModel
    {
        public string username { get; set; }
        public string description { get; set; }
        public int rating { get; set; }
    }
}