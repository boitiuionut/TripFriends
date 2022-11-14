using System;

namespace Emr.API.Models.PatientDashboard
{
    public class PatientDashboardExaminationModel
    {
        public int ClinicId { get; set; }
        public int PatientId { get; set; }
        public int PatientClaimId { get; set; }
        public int VisitId { get; set; }
        public DateTime ExaminationDate { get; set; }
        public DateTime SrvsEndDate { get; set; }
        public string CptHcpcsCd { get; set; }
        public double ChargeAmount { get; set; }
    }
}