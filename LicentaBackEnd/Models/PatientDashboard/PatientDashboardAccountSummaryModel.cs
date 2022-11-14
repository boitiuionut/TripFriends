namespace Emr.API.Models.PatientDashboard
{
    public class PatientDashboardAccountSummaryModel
    {
        public int ClaimsToDate { get; set; }
        public double PreviousBalance { get; set; }
        public double ChargesToDate { get; set; }
        public double AccountBalance { get; set; }
        public double UnnapliedPaymentsOnAccount { get; set; }
    }
}