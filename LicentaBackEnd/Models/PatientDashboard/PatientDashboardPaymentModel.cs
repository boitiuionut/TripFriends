using System;

namespace Emr.API.Models.PatientDashboard
{
    public class PatientDashboardPaymentModel
    {
        public int PatientId { get; set; }
        public int PaymentId { get; set; }
        public int PatientClaimId { get; set; }
        public double PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string ReceivedFromName { get; set; }
        public string ReceivedFromType  { get; set; }
    }
}