using Emr.API.Models.Common;
using System;
using System.Collections.Generic;

namespace Emr.API.Models.PatientDashboard
{
    public class PatientDashboardDocsModel
    {
        public int FormId { get; set; }
        public long? FeeSlipId { get; set; }
        public int? FormTypeId { get; set; }
        public string FormType { get; set; }
        public DateTime DateOfService { get; set; }
        public string FormName { get; set; }
        public string FormNameShort { get; set; }
        public string Provider { get; set; }
        public string ProviderShort { get; set; }
        public int ProviderId { get; set; }
        public bool FormMigrated { get; set; }
        public List<KeyValueGenericModel> Services { get; set; }
        public int ClinicId { get; set; }
        public int PatientId { get; set; }
        public int? ClaimId { get; set; }
        public string ClaimStatus { get; set; }
    }
}