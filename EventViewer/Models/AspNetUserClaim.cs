//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EventViewer.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AspNetUserClaim
    {
        public int Id { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public string User_Id { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
    }
}
