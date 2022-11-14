using System;

namespace Emr.API.Models.PatientDashboard
{
    public class PatientDashboardGetClaimsModel
    {
        public int ClaimId { get; set; }
        public int PatientId { get; set; }
        public DateTime? ClaimDos { get; set; }
        public int? UserId { get; set; }
    }
}