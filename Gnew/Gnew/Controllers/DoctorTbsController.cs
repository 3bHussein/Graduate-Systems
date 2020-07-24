using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gnew.Models;

namespace Gnew.Controllers
{
    public class DoctorTbsController : Controller
    {
        private GraduateDbEntities db = new GraduateDbEntities();

        // GET: DoctorTbs
        public ActionResult Index()
        {
            return View(db.DoctorTbs.ToList());
        }

        // GET: DoctorTbs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorTb doctorTb = db.DoctorTbs.Find(id);
            if (doctorTb == null)
            {
                return HttpNotFound();
            }
            return View(doctorTb);
        }

        // GET: DoctorTbs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DoctorTbs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,DoctorName,Description")] DoctorTb doctorTb)
        {
            if (ModelState.IsValid)
            {
                db.DoctorTbs.Add(doctorTb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(doctorTb);
        }

        // GET: DoctorTbs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorTb doctorTb = db.DoctorTbs.Find(id);
            if (doctorTb == null)
            {
                return HttpNotFound();
            }
            return View(doctorTb);
        }

        // POST: DoctorTbs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,DoctorName,Description")] DoctorTb doctorTb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctorTb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doctorTb);
        }

        // GET: DoctorTbs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorTb doctorTb = db.DoctorTbs.Find(id);
            if (doctorTb == null)
            {
                return HttpNotFound();
            }
            return View(doctorTb);
        }

        // POST: DoctorTbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DoctorTb doctorTb = db.DoctorTbs.Find(id);
            db.DoctorTbs.Remove(doctorTb);
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
