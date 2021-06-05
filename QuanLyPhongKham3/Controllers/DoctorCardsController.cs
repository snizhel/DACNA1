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
            Response.AddHeader("Refresh", "5");
            return View(db.Prescription.Where(x => x.Status == "New" && x.DateOfCreate == DateTime.Today).ToList());
        }

        //[ValidateAntiForgeryToken]
        // [HttpPost]
        public ActionResult Add(int patient_id, int doctor_id)
        {
            Customer customer = db.Customer.Find(patient_id);

            Prescription prescription = new Prescription
            {
                IDCustomer = patient_id,
                IdStaff = doctor_id,
                Status = "New",
                DateOfCreate = DateTime.Today,


            };
            try
            {
                db.Prescription.Add(prescription);
                db.SaveChanges();
                return Json(new
                {
                    status = "OK"
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = "ERROR",
                    message = ex.Message
                }, JsonRequestBehavior.AllowGet);
            }
            ////   ViewBag.Staff = new SelectList(db.AspNetRoles.Where(role => role.Name.Contains("Doctor")).ToList(), "Name", "Name", "Employee");
            //     DoctorCart cart = DoctorCart.getInstance();
            //     cart.Add(item);
            //     //return View(DoctorCart.getInstance().List.Values);
        }

        //public ActionResult CheckScript( int pres_id)
        //{
        //    Prescription prescription = db.Prescription.Find(pres_id);
        //    try
        //    {
                
        //        foreach (var item in items)
        //        {
        //            Medicine medicine = db.Medicine.Find(item.ID);
        //            ViewBag.IdMedicine = new SelectList(db.Medicine, "ID", "Name");
        //            PrescriptionDetails prescriptionDetails = new PrescriptionDetails
        //            {
        //                IDPrescription = prescription.ID,
        //                IDMedicine = medicine.ID,
                       

        //            };
        //            db.PrescriptionDetails.Add(prescriptionDetails);
        //        }
        //        db.SaveChanges();
        //        return Json(new
        //        {
        //            status = "OK"
        //        }, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new
        //        {
        //            status = "ERROR",
        //            message = ex.Message
        //        }, JsonRequestBehavior.AllowGet);
        //    }
        //}



    }




}

