//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace homework.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Patient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Patient()
        {
            this.Consultations = new HashSet<Consultation>();
            this.Family_Member = new HashSet<Family_Member>();
        }
    
        public int Patient_No { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Nullable<int> Title { get; set; }
        public string CitizenShip { get; set; }
        public string ID_Number { get; set; }
        public string Passport_No { get; set; }
        public string Patient_Address { get; set; }
        public Nullable<int> Province_ID { get; set; }
        public string TelePhone { get; set; }
        public string Gender { get; set; }
        public string Date_Of_Birth { get; set; }
        public Nullable<int> ImageId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Consultation> Consultations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Family_Member> Family_Member { get; set; }
        public virtual Province Province { get; set; }
        public virtual Title Title1 { get; set; }
    }
}
