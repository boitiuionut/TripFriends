using Emr.API.Models.Common;
using System;
using System.Collections.Generic;

namespace Emr.API.Models.PatientDashboard
{

    public class PatientDashboardFinancialModel
    {
        public string PayerName { get; set; }
        public string PayerNameSecond { get; set; }
        public string PatientAccNumber { get; set; }
        public DateAmountGenericModel Charges { get; set; }
        public DateAmountGenericModel Balance { get; set; }
        public List<TypeAmountGenericModel> TotalProviderPaymentsPerYear { get; set; }
        public DateTime? LastVisitDate { get; set; }
        public List<TypeAmountGenericModel> Services { get; set; }
        public List<DateAmountGenericModel> PatientPaid { get; set; }
        public List<TypeDateAmountGenericModel> Products { get; set; }
        public List<DateAmountGenericModel> Examinations { get; set; }
        public double InsuranceDeductible { get; set; }
        public double InsuranceCoPay { get; set; }
        public DateAmountGenericModel LastPaid { get; set; }
    }

}