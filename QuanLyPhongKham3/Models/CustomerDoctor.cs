using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyPhongKham3.Models
{
    public class CustomerDoctor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public string Sex { get; set; }
        public string Email { get; set; }
        public int Turn { get; set; }
       
    }
}