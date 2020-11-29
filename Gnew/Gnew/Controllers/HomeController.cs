using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gnew.Models;

namespace Gnew.Controllers
{
    public class HomeController : Controller
    {
        private GraduateDbEntities db = new GraduateDbEntities();

        public ActionResult Index()
        {
           

            var QSCount = (from emp in db.DoctorTbs
                              select emp).Count();

            var QSCount1 = (from emp in db.ProjectTbs
                           select emp).Count();
            var QSCount2 = (from emp in db.RegisterTbs
                           select emp).Count();


            var kh1 = (from emp in db.RegisterTbs
                            select emp).Where(a => a.ProjectTb.Projectcode== "KH1").Count();
            var kh2 = (from emp in db.RegisterTbs
                       select emp).Where(a => a.ProjectTb.Projectcode == "KH2").Count();
            var kh0 = kh1 + kh2;

            var z1 = (from emp in db.RegisterTbs
                       select emp).Where(a => a.ProjectTb.Projectcode == "Z1").Count();
            var z2 = (from emp in db.RegisterTbs
                       select emp).Where(a => a.ProjectTb.Projectcode == "Z2").Count();
            var z0 = z1 + z2;

            var sh1 = (from emp in db.RegisterTbs
                      select emp).Where(a => a.ProjectTb.Projectcode == "sh1").Count();
            var sh2 = (from emp in db.RegisterTbs
                      select emp).Where(a => a.ProjectTb.Projectcode == "sh2").Count();
            var sh0 = sh1 + sh2;

            var ar1 = (from emp in db.RegisterTbs
                       select emp).Where(a => a.ProjectTb.Projectcode == "ar1").Count();
            var ar2 = (from emp in db.RegisterTbs
                       select emp).Where(a => a.ProjectTb.Projectcode == "ar2").Count();
            var ar0 = ar1 + ar2;


            var s1 = (from emp in db.RegisterTbs
                       select emp).Where(a => a.ProjectTb.Projectcode == "s1").Count();
            var s2 = (from emp in db.RegisterTbs
                       select emp).Where(a => a.ProjectTb.Projectcode == "s2").Count();
            var s0 = s1 + s2;

            var n1 = (from emp in db.RegisterTbs
                      select emp).Where(a => a.ProjectTb.Projectcode == "n1").Count();
            var n2 = (from emp in db.RegisterTbs
                      select emp).Where(a => a.ProjectTb.Projectcode == "n2").Count();
            var n0 = n1 + n2;


            var mo1 = (from emp in db.RegisterTbs
                      select emp).Where(a => a.ProjectTb.Projectcode == "mo1").Count();
            var mo2 = (from emp in db.RegisterTbs
                      select emp).Where(a => a.ProjectTb.Projectcode == "mo2").Count();
            var mo0 = mo1 + mo2;


            ViewBag.Doc = QSCount;
            ViewBag.Pro = QSCount1;
            ViewBag.Reg = QSCount2;

            ViewBag.kh1 = kh1;
            ViewBag.kh2 = kh2;
            ViewBag.kh0 = kh0;

            ViewBag.z1 = z1;
            ViewBag.z2 = z2;
            ViewBag.z0 = z0;

            ViewBag.sh1 = sh1;
            ViewBag.sh2 = sh2;
            ViewBag.sh0 = sh0;

            ViewBag.ar1 = ar1;
            ViewBag.ar2 = ar2;
            ViewBag.ar0 = ar0;

            ViewBag.s1 = s1;
            ViewBag.s2 = s2;
            ViewBag.s0 = s0;

            ViewBag.n1 = n1;
            ViewBag.n2 = n2;
            ViewBag.n0 = n0;

            ViewBag.mo1 = mo1;
            ViewBag.mo2 = mo2;
            ViewBag.mo0 = mo0;


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}