using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emr.API.Models
{
    public class UserInfoModel
    {
        public int userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string description { get; set; }
        public string profilepicture { get; set; }
    }
}