using System;

namespace Emr.API.Models.PatientDashboard
{
    public class PatientDashboardTreatmentPlanModel
    {
        public int Id { get; set; }
        public int PlanId { get; set; }
        public int ClinicId { get; set; }
        public int PatientId { get; set; }
        public string ProcedureCode { get; set; }
        public string Gbp { get; set; }
        public string Amount { get; set; }
        public string ServicesNr { get; set; }
        public string ServiceType { get; set; }
        public string Category { get; set; }
        public DateTime StartDate { get; set; }
        public string TotalVisits { get; set; }
        public string Active { get; set; }
        public string Agreed { get; set; }

    }
}