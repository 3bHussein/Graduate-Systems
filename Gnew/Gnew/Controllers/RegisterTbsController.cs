using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gnew.Models;
//
using PagedList;
using PagedList.Mvc;
using Microsoft.Reporting.WebForms;
using System.IO;

namespace Graduate_Systems.Controllers
{
    public class RegisterTbsController : Controller
    {
        private GraduateDbEntities db = new GraduateDbEntities();

        // GET: RegisterTbs
        public ActionResult Index(int page=1)
        {
            var registerTbs = db.RegisterTbs.Include(r => r.ProjectTb);
            return View(registerTbs.ToList().OrderByDescending(a => a.id).ToPagedList(page, 5));

            //return PartialView("_Register", registerTbs);



        }


        public PartialViewResult all()
        {
            var registerTbs = db.RegisterTbs.Include(r => r.ProjectTb);

            return PartialView("_Register", registerTbs);

        }
        public ActionResult Search(string search1, string searchby)
        {

            {
                if (searchby == "StudentName")
                {
                    return View("Search", db.RegisterTbs.Where(a => a.StudentName.ToString().Contains(search1)));

                }
                else if (searchby == "StudentCode")
                {
                    return View("search", db.RegisterTbs.Where(a => a.StudentRegNo.ToString().Contains(search1)));

                }
                else if (searchby == "ProjectName")
                {
                    return View("search", db.RegisterTbs.Where(a => a.ProjectTb.ProjectName.ToString().Contains(search1)));

                }


                else if (searchby == "ProjectCode")
                {
                    return View("search", db.RegisterTbs.Where(a => a.ProjectTb.Projectcode.ToString().Contains(search1)));

                }
                
                     else if (searchby == "Date")
                {
                    return View("search", db.RegisterTbs.Where(a => a.DateReg.ToString().Contains(search1)));

                }


                else
                    return View("search", db.RegisterTbs.ToList());

            }

        }






        // GET: RegisterTbs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterTb registerTb = db.RegisterTbs.Find(id);
            if (registerTb == null)
            {
                return HttpNotFound();
            }
            return View(registerTb);
        }

        // GET: RegisterTbs/Create
        public ActionResult Create()
        {
            ViewBag.projectId = new SelectList(db.ProjectTbs, "projectId", "ProjectName");
            return View();
        }

        // POST: RegisterTbs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,DateReg,StudentName,StudentRegNo,projectId,Description")] RegisterTb registerTb)
        {
            if (ModelState.IsValid)
            {
                db.RegisterTbs.Add(registerTb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.projectId = new SelectList(db.ProjectTbs, "projectId", "ProjectName", registerTb.projectId);
            return View(registerTb);
        }

        // GET: RegisterTbs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterTb registerTb = db.RegisterTbs.Find(id);
            if (registerTb == null)
            {
                return HttpNotFound();
            }
            ViewBag.projectId = new SelectList(db.ProjectTbs, "projectId", "ProjectName", registerTb.projectId);
            return View(registerTb);
        }

        // POST: RegisterTbs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,DateReg,StudentName,StudentRegNo,projectId,Description")] RegisterTb registerTb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registerTb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.projectId = new SelectList(db.ProjectTbs, "projectId", "ProjectName", registerTb.projectId);
            return View(registerTb);
        }

        // GET: RegisterTbs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterTb registerTb = db.RegisterTbs.Find(id);
            if (registerTb == null)
            {
                return HttpNotFound();
            }
            return View(registerTb);
        }

        // POST: RegisterTbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegisterTb registerTb = db.RegisterTbs.Find(id);
            db.RegisterTbs.Remove(registerTb);
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


        public ActionResult Report(string id)
        {




            var result = (from p in db.RegisterTbs
                          join c in db.ProjectTbs
                          on p.projectId equals c.projectId
                          join q in db.DoctorTbs
                          on c.DocId equals q.id

                          select new
                          {
                              p.DateReg,
                              p.StudentName,
                              p.StudentRegNo,
                                c.ProjectName,
                                c.Projectcode,
                                q.DoctorName
                          }).ToList();
 

            //var result2 = ().tolist();



            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Report"), "Reportsa.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return View("Index");
            }

             ReportDataSource rd = new ReportDataSource("mydata", result);
             lr.DataSources.Add(rd);
            string reportType = id;
            string mimeType;
            string encoding;
            string fileNameExtension;



            string deviceInfo =

            "<DeviceInfo>" +
            "  <OutputFormat>" + id + "</OutputFormat>" +
            "  <PageWidth>8.5in</PageWidth>" +
            "  <PageHeight>11in</PageHeight>" +
            "  <MarginTop>0.5in</MarginTop>" +
            "  <MarginLeft>1in</MarginLeft>" +
            "  <MarginRight>1in</MarginRight>" +
            "  <MarginBottom>0.5in</MarginBottom>" +
            "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            renderedBytes = lr.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);
            return File(renderedBytes, mimeType);
        }
    }
}
