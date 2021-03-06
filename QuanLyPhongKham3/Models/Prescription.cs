//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyPhongKham3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Prescription
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Prescription()
        {
            this.PrescriptionDetails = new HashSet<PrescriptionDetails>();
        }
    
        public int ID { get; set; }
        public int IdStaff { get; set; }
        public int IDCustomer { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfCreate { get; set; }
        public string Symptom { get; set; }
        public string Diagnosis { get; set; }
        public string Status { get; set; }
    
        public virtual Customer Customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PrescriptionDetails> PrescriptionDetails { get; set; }
        public virtual Staff Staff { get; set; }
    }
}
