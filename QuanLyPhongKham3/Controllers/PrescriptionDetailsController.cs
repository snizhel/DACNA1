using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyPhongKham3.Models;

namespace QuanLyPhongKham3.Controllers
{
    public class PrescriptionDetailsController : Controller
    {
        private QLPKEntities db = new QLPKEntities();

        // GET: PrescriptionDetails
        public ActionResult Index()
        {
            var prescriptionDetails = db.PrescriptionDetails.Include(p => p.Medicine);
            return View(prescriptionDetails.ToList());
        }

        // GET: PrescriptionDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrescriptionDetails prescriptionDetails = db.PrescriptionDetails.Find(id);
            if (prescriptionDetails == null)
            {
                return HttpNotFound();
            }
            return View(prescriptionDetails);
        }

        // GET: PrescriptionDetails/Create
        public ActionResult Create()
        {
            ViewBag.IDMedicine = new SelectList(db.Medicine, "ID", "Name");
            return View();
        }

        // POST: PrescriptionDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDPrescription,IDMedicine,Count,Dosage,Symptom,Using")] PrescriptionDetails prescriptionDetails)
        {
            if (ModelState.IsValid)
            {
                db.PrescriptionDetails.Add(prescriptionDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDMedicine = new SelectList(db.Medicine, "ID", "Name", prescriptionDetails.IDMedicine);
            return View(prescriptionDetails);
        }

        // GET: PrescriptionDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrescriptionDetails prescriptionDetails = db.PrescriptionDetails.Find(id);
            if (prescriptionDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDMedicine = new SelectList(db.Medicine, "ID", "Name", prescriptionDetails.IDMedicine);
            return View(prescriptionDetails);
        }

        // POST: PrescriptionDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDPrescription,IDMedicine,Count,Dosage,Symptom,Using")] PrescriptionDetails prescriptionDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prescriptionDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDMedicine = new SelectList(db.Medicine, "ID", "Name", prescriptionDetails.IDMedicine);
            return View(prescriptionDetails);
        }

        // GET: PrescriptionDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrescriptionDetails prescriptionDetails = db.PrescriptionDetails.Find(id);
            if (prescriptionDetails == null)
            {
                return HttpNotFound();
            }
            return View(prescriptionDetails);
        }

        // POST: PrescriptionDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PrescriptionDetails prescriptionDetails = db.PrescriptionDetails.Find(id);
            db.PrescriptionDetails.Remove(prescriptionDetails);
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
