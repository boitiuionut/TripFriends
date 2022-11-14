using System;
using System.Collections.Generic;

namespace Emr.API.Models.PatientDashboard
{
    public class PatientDashboardNotesModel
    {
        public int NoteId { get; set; }
        public int ClinicId { get; set; }
        public int PatientId { get; set; }
        public string Text { get; set; }
        public string RecCreateUserId { get; set; }
        public DateTime RecCreateTs { get; set; }
        public KeyValuePair<string,string> Status { get; set; }

    }
}