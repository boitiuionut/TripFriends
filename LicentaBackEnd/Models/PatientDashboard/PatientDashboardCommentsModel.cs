using System;

namespace Emr.API.Models.PatientDashboard
{
    public class PatientDashboardCommentsModel
    {
        public int Id { get; set; }
        public int ClinicId { get; set; }
        public int PatientId { get; set; }
        public string NoteDr { get; set; }
        public string NoteWarning { get; set; }
        public string NoteCa { get; set; }
        public string NoteListings { get; set; }
        public DateTime RecCreateTs { get; set; }
        public string RecCreateUserId { get; set; }
        public DateTime? RecUpdateTs { get; set; }
        public string RecUpdateUserId { get; set; }

    }
}