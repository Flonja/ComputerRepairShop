using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VanjaReparatieWinkool.Models;
using VanjaReparatieWinkool.ViewModels;

namespace VanjaReparatieWinkool.Controllers
{
    public class BillController : SharedController
    {
        // GET: Bill
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignmentModel model = db.Assignments.Find(id);

            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
    }
}