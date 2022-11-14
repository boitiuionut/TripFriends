using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emr.API.Models
{
    public class RegisterClientModel
    {
        public string nume { get; set; }
        public string prenume { get; set; }
        public string email { get; set; }
        public string telefon { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }
        public string pozaprofil { get; set; }
        
    }
}