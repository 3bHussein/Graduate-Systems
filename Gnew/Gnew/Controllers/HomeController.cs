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

            ViewBag.Doc = QSCount;
            ViewBag.Pro = QSCount1;
            ViewBag.Reg = QSCount2;

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