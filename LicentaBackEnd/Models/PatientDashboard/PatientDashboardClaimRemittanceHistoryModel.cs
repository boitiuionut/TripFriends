namespace Emr.API.Models.PatientDashboard
{
    public class PatientDashboardClaimRemittanceHistoryModel
    {
        public double InsurancePayments { get; set; }
        public double PatientPayments { get; set; }
        public double ProductPayments { get; set; }
        public double WriteOff { get; set; }
        public double InappropriateWriteOff { get; set; }
    }
}