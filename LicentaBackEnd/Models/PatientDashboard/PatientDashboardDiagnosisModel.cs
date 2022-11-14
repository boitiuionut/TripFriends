using System;

namespace Emr.API.Models.PatientDashboard
{
    public class PatientDashboardDiagnosisModel
    {
        public int Id { get; set; }
        public int ClinicId { get; set; }
        public int PatientId { get; set; }
        public int ProblemId { get; set; }
        public string ProblemCode { get; set; }
        public string ProblemName { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime LastReportedDate { get; set; }
        public DateTime ResolvedDate { get; set; }
        public bool Chronic { get; set; }
        public bool Acute { get; set; }
        public bool IsActive { get; set; }
    }
}