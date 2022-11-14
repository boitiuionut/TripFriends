using System.Collections.Generic;

namespace Emr.API.Models.PatientDashboard
{
    public class PatientDashboardDataModel
    {
        public List<PatientDashboardRemindersModel> Remiders { get; set; }
        // visits
        public int CurrentVisit { get; set; }
        public string TotalVisits { get; set; }
        public int TreatmentPlanId { get; set; }
    }
}