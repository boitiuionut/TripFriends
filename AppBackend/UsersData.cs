//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Emr.API
{
    using System;
    using System.Collections.Generic;
    
    public partial class UsersData
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UsersData()
        {
            this.TripsDatas = new HashSet<TripsData>();
            this.FeedbacksDatas = new HashSet<FeedbacksData>();
        }
    
        public int userId { get; set; }
        public string nume { get; set; }
        public string prenume { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string telefon { get; set; }
        public string pozaprofil { get; set; }
        public string descriere { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TripsData> TripsDatas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FeedbacksData> FeedbacksDatas { get; set; }
    }
}
