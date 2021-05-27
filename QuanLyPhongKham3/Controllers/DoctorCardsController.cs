using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using QuanLyPhongKham3.Models;
namespace QuanLyPhongKham3.Controllers
{
    public class DoctorCardsController : Controller
    {
        private QLPKEntities db = new QLPKEntities();
        // GET: DoctorCard
        public ActionResult Index()
        {
            return View(DoctorCart.getInstance().List.Values);
        }
       
        //[ValidateAntiForgeryToken]
       // [HttpPost]
        public ActionResult Add(int? id)
        {
            Customer customer = db.Customer.Find(id);
           
            CustomerDoctor item = new CustomerDoctor
            {
                ID = customer.ID,
                Name = customer.Name,
                Address = customer.Address,
                DateOfBirth = customer.DateOfBirth,
                PhoneNumber = customer.PhoneNumber,
                Sex = customer.Sex,
                Email = customer.Email,
                Turn = 1,
                
                
            };
       //   ViewBag.Staff = new SelectList(db.AspNetRoles.Where(role => role.Name.Contains("Doctor")).ToList(), "Name", "Name", "Employee");
            DoctorCart cart = DoctorCart.getInstance();
            cart.Add(item);
            //return View(DoctorCart.getInstance().List.Values);
            return Json(new
            {
                status = "OK"
            }, JsonRequestBehavior.AllowGet);

        }



    }




}

