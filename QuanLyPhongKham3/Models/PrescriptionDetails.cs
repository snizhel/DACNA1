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
    
    public partial class PrescriptionDetails
    {
        public int ID { get; set; }
        public int IDPrescription { get; set; }
        public int IDMedicine { get; set; }
        public int Count { get; set; }
        public string Dosage { get; set; }
        public string Symptom { get; set; }
        public string Using { get; set; }
    
        public virtual Medicine Medicine { get; set; }
        public virtual Prescription Prescription { get; set; }
    }
}