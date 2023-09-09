using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using homework.Models;

namespace homework.Views
{
    public class PatientsController : Controller
    {
        private Daspoort_ClinicEntities2 db = new Daspoort_ClinicEntities2();

        // GET: Patients
        public ActionResult Index()
        {
            var patients = db.Patients.Include(p => p.Province).Include(p => p.Title1);
            return View(patients.ToList());
        }

        // GET: Patients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // GET: Patients/Create
        public ActionResult Create()
        {
            ViewBag.Province_ID = new SelectList(db.Provinces, "Province_ID", "Province_Name");
            ViewBag.Title = new SelectList(db.Titles, "Title_ID", "Name");
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Patient_No,Name,Surname,Title,CitizenShip,ID_Number,Passport_No,Patient_Address,Province_ID,TelePhone,Gender,Date_Of_Birth,ImageId")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Patients.Add(patient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Province_ID = new SelectList(db.Provinces, "Province_ID", "Province_Name", patient.Province_ID);
            ViewBag.Title = new SelectList(db.Titles, "Title_ID", "Name", patient.Title);
            return View(patient);
        }

        // GET: Patients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            ViewBag.Province_ID = new SelectList(db.Provinces, "Province_ID", "Province_Name", patient.Province_ID);
            ViewBag.Title = new SelectList(db.Titles, "Title_ID", "Name", patient.Title);
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Patient_No,Name,Surname,Title,CitizenShip,ID_Number,Passport_No,Patient_Address,Province_ID,TelePhone,Gender,Date_Of_Birth,ImageId")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Province_ID = new SelectList(db.Provinces, "Province_ID", "Province_Name", patient.Province_ID);
            ViewBag.Title = new SelectList(db.Titles, "Title_ID", "Name", patient.Title);
            return View(patient);
        }

        // GET: Patients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Patient patient = db.Patients.Find(id);
            db.Patients.Remove(patient);
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
