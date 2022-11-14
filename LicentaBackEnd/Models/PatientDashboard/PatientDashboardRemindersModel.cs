using System;

namespace Emr.API.Models.PatientDashboard
{
    public class PatientDashboardRemindersModel
    {
        public int Id { get; set; }
        public int RmdId { get; set; }
        public string Description { get; set; }
        public string Symbol { get; set; }
        public string Message { get; set; }
        public string TotalVisits { get; set; }
        public int? VisitStart { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateCompletion { get; set; }
        public string Status { get; set; }
        public string RecCreateUserId { get; set; }
        public string RecUpdteUserId { get; set; }
        public DateTime RecCreateTs { get; set; }
        public DateTime? RecUpdateTs { get; set; }
        public int PatientId { get; set; }
        public int ClinicId { get; set; }
    }
}