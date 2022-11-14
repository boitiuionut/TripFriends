using System;
using System.Collections.Generic;

namespace Emr.API.Models.PatientDashboard
{
    public class PatientDashboardLastClaimDataModel
    {
        public string MostRecentClaim { get; set; }
        public DateTime MostRecentDos { get; set; }
        public string MostRecentProvider { get; set; }
        public List<string> MostRecentDiagnosis { get; set; }
    }
}