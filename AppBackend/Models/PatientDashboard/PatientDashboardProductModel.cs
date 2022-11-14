using System;

namespace Emr.API.Models.PatientDashboard
{
    public class PatientDashboardProductModel
    {
        public int PatientId { get; set; }
        public int PatientClaimId { get; set; }
        public int VisitId { get; set; }
        public DateTime VisitDate { get; set; }
        public string VisitSrvsType { get; set; }
        public string CptHcpcsCd { get; set; }
        public string ProdName { get; set; }
        public double ChargeAmount { get; set; }
    }
}