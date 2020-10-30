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
    public class StudentTbsController : Controller
    {
        private GraduateDbEntities db = new GraduateDbEntities();

        // GET: StudentTbs
        public ActionResult Index()
        {
            return View(db.StudentTbs.ToList());
        }

        // GET: StudentTbs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentTb studentTb = db.StudentTbs.Find(id);
            if (studentTb == null)
            {
                return HttpNotFound();
            }
            return View(studentTb);
        }

        // GET: StudentTbs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentTbs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StundentRegNo,StundentName")] StudentTb studentTb)
        {
            if (ModelState.IsValid)
            {
                db.StudentTbs.Add(studentTb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentTb);
        }

        // GET: StudentTbs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentTb studentTb = db.StudentTbs.Find(id);
            if (studentTb == null)
            {
                return HttpNotFound();
            }
            return View(studentTb);
        }

        // POST: StudentTbs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StundentRegNo,StundentName")] StudentTb studentTb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentTb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentTb);
        }

        // GET: StudentTbs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentTb studentTb = db.StudentTbs.Find(id);
            if (studentTb == null)
            {
                return HttpNotFound();
            }
            return View(studentTb);
        }

        // POST: StudentTbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentTb studentTb = db.StudentTbs.Find(id);
            db.StudentTbs.Remove(studentTb);
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
