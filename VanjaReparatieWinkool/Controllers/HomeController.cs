using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VanjaReparatieWinkool.DAL;
using VanjaReparatieWinkool.Models;

namespace VanjaReparatieWinkool.Controllers
{
    public class HomeController : SharedController
    {
        private VanjaReparatieWinkoolContext db = new VanjaReparatieWinkoolContext();

        //public ActionResult _Layout()
        //{
        //    return PartialView("~/Views/Shared/_Layout.cshtml");
        //}

        public ActionResult Index()
        {
            ViewBag.TotalAssignments = db.AssignmentModels.ToList().Count;

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