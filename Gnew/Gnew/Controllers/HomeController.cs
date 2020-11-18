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



            ViewBag.Doc = QSCount;
            ViewBag.Pro = QSCount1;
            ViewBag.Reg = QSCount2;
            ViewBag.kh1 = kh1;
            ViewBag.kh2 = kh2;
            ViewBag.kh0 = kh0;
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