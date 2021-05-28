using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using QuanLyPhongKham3.Models;

namespace QuanLyPhongKham3.Controllers
{
    public class PrescriptionsController : Controller
    {
        private QLPKEntities db = new QLPKEntities();
        [Authorize(Roles = "MedicalStaff,Admin")]
        // GET: Prescriptions
        public ActionResult Index()
        {
            var prescription = db.Prescription.Include(p => p.Customer).Include(p => p.PrescriptionDetails).Include(p => p.Staff);
            return View(prescription.ToList());
        }
        [Authorize(Roles = "MedicalStaff")]
        // GET: Prescriptions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prescription prescription = db.Prescription.Find(id);
            if (prescription == null)
            {
                return HttpNotFound();
            }
            return View(prescription);
        }
        [Authorize(Roles = "Doctor")]
        // GET: Prescriptions/Create
        public ActionResult Create()
        {
            ViewBag.IDCustomer = new SelectList(db.Customer, "ID", "Name");
            ViewBag.IDPrescriptionDetails = new SelectList(db.PrescriptionDetails, "IDPrescription", "Dosage");
            ViewBag.IdStaff = new SelectList(db.Staff, "ID", "Name");
            return View();
        }

        // POST: Prescriptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IdStaff,IDCustomer,DateOfCreate,IDMedicine,Count,Dosage,Symptom,Using,Status")] Prescription prescription)
        {
            if (ModelState.IsValid)
            {
                db.Prescription.Add(prescription);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCustomer = new SelectList(db.Customer, "ID", "Name", prescription.IDCustomer);
            ViewBag.IDPrescriptionDetails = new SelectList(db.PrescriptionDetails, "IDPrescription", "Dosage", prescription.ID);
            ViewBag.IdStaff = new SelectList(db.Staff, "ID", "Name", prescription.IdStaff);
            return View(prescription);
        }
        [Authorize(Roles = "MedicalStaff")]
        // GET: Prescriptions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prescription prescription = db.Prescription.Find(id);
            if (prescription == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCustomer = new SelectList(db.Customer, "ID", "Name", prescription.IDCustomer);
            ViewBag.IDPrescriptionDetails = new SelectList(db.PrescriptionDetails, "IDPrescription", "Dosage", prescription.ID);
            ViewBag.IdStaff = new SelectList(db.Staff, "ID", "Name", prescription.IdStaff);
            return View(prescription);
        }

        // POST: Prescriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IdStaff,IDCustomer,DateOfCreate,IDMedicine,Count,Dosage,Symptom,Using,Status")] Prescription prescription)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prescription).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCustomer = new SelectList(db.Customer, "ID", "Name", prescription.IDCustomer);
            ViewBag.IDPrescriptionDetails = new SelectList(db.PrescriptionDetails, "IDPrescription", "Dosage", prescription.ID);
            ViewBag.IdStaff = new SelectList(db.Staff, "ID", "Name", prescription.IdStaff);
            return View(prescription);
        }

        // GET: Prescriptions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prescription prescription = db.Prescription.Find(id);
            if (prescription == null)
            {
                return HttpNotFound();
            }
            return View(prescription);
        }
        
        // POST: Prescriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prescription prescription = db.Prescription.Find(id);
            db.Prescription.Remove(prescription);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
