using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyPhongKham3.Models
{
    public class DoctorCart
    {
        public static DoctorCart getInstance()
        {
            return new DoctorCart();
        }
        public SortedList<int, CustomerDoctor> List
        {
            get
            {
                HttpSessionStateBase Session = new HttpSessionStateWrapper(HttpContext.Current.Session);
                if (Session["list"] == null)
                    Session["list"] = new SortedList<int, CustomerDoctor>();
                return Session["list"] as SortedList<int, CustomerDoctor>;
            }
        }
        public void Add(CustomerDoctor customer)
        {
            if (List.ContainsKey(customer.ID))
            {
                CustomerDoctor currentItem = List[customer.ID];
                currentItem.Turn += customer.Turn;
            }
            else
            {
                List.Add(customer.ID, customer);
            }
           
        }

    }
}