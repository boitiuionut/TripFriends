using System;
using System.Collections.Generic;

namespace Emr.API.Models.PatientDashboard
{
    public class PatientDashboardOrderModel
    {
        public int ClinicId { get; set; }
        public int PatientId { get; set; }
        public DateTime? DateOfService { get; set; }
        public string Service { get; set; }
        public string Description { get; set; }
        public int Performed { get; set; }
        public int? Anticipate { get; set; }
        public int Remaining { get; set; }
        public DateTime? Today { get; set; }
        public bool TodayBool { get; set; }
        public DateTime? StartDate { get; set; }
        public bool? NewService { get; set; }
    }

    public class PatientDashboardOrderReturnModel
    {
        public PatientDashboardOrderReturnModel()
        {

        }

        public PatientDashboardOrderReturnModel(IEnumerable<PatientDashboardOrderModel> Orders, DateTime? StartDate, bool PatientOrderStartDateChanged, string PatientName, int PatientId)
        {
            this.Orders = Orders;
            this.StartDate = StartDate;
            this.PatientOrderStartDateChanged = PatientOrderStartDateChanged;
            this.PatientName = PatientName;
            this.PatientId = PatientId;
        }

        public IEnumerable<PatientDashboardOrderModel> Orders { get; set; }
        public DateTime? StartDate { get; set; }
        public bool PatientOrderStartDateChanged { get; set; }
        public string PatientName { get; set; }
        public int PatientId { get; set; }
    }
}