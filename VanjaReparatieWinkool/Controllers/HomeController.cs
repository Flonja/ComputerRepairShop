using System.Web.Mvc;

namespace VanjaReparatieWinkool.Controllers
{
    public class HomeController : SharedController
    {

        //public ActionResult _Layout()
        //{
        //    return PartialView("~/Views/Shared/_Layout.cshtml");
        //}

        public ActionResult Index()
        {
            //ViewBag.TotalAssignments = db.Assignments.ToList().Count;

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