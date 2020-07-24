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
    public class ProjectTbsController : Controller
    {
        private GraduateDbEntities db = new GraduateDbEntities();

        // GET: ProjectTbs
        public ActionResult Index()
        {
            var projectTbs = db.ProjectTbs.Include(p => p.DoctorTb);
            return View(projectTbs.ToList());
        }

        // GET: ProjectTbs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectTb projectTb = db.ProjectTbs.Find(id);
            if (projectTb == null)
            {
                return HttpNotFound();
            }
            return View(projectTb);
        }

        // GET: ProjectTbs/Create
        public ActionResult Create()
        {
            ViewBag.DocId = new SelectList(db.DoctorTbs, "id", "DoctorName");
            return View();
        }

        // POST: ProjectTbs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "projectId,DocId,ProjectName,Projectcode,Description")] ProjectTb projectTb)
        {
            if (ModelState.IsValid)
            {
                db.ProjectTbs.Add(projectTb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DocId = new SelectList(db.DoctorTbs, "id", "DoctorName", projectTb.DocId);
            return View(projectTb);
        }

        // GET: ProjectTbs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectTb projectTb = db.ProjectTbs.Find(id);
            if (projectTb == null)
            {
                return HttpNotFound();
            }
            ViewBag.DocId = new SelectList(db.DoctorTbs, "id", "DoctorName", projectTb.DocId);
            return View(projectTb);
        }

        // POST: ProjectTbs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "projectId,DocId,ProjectName,Projectcode,Description")] ProjectTb projectTb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectTb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DocId = new SelectList(db.DoctorTbs, "id", "DoctorName", projectTb.DocId);
            return View(projectTb);
        }

        // GET: ProjectTbs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectTb projectTb = db.ProjectTbs.Find(id);
            if (projectTb == null)
            {
                return HttpNotFound();
            }
            return View(projectTb);
        }

        // POST: ProjectTbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectTb projectTb = db.ProjectTbs.Find(id);
            db.ProjectTbs.Remove(projectTb);
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
