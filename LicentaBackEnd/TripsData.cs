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
    
    public partial class TripsData
    {
        public int tripid { get; set; }
        public int userid { get; set; }
        public string country { get; set; }
        public string town { get; set; }
        public string detailedaddress { get; set; }
        public string tripdate { get; set; }
        public string tripduration { get; set; }
        public int availability { get; set; }
        public string whycompany { get; set; }
    
        public virtual UsersData UsersData { get; set; }
    }
}
