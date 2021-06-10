﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            return View();
        }

        public ActionResult Transfer(int? detail_id, int? pres_id)
        {
            Prescription prescription = db.Prescription.Find(pres_id);
            try
            {
                prescription.Status = "Unpaid";
                db.Entry(prescription).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new
                {
                    status = "OK",
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

