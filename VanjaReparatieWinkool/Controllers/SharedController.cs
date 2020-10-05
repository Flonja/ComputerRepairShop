using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VanjaReparatieWinkool.DAL;
using VanjaReparatieWinkool.Models;

namespace VanjaReparatieWinkool.Controllers
{
    public class SharedController : Controller
    {
        private VanjaReparatieWinkoolContext db = new VanjaReparatieWinkoolContext();

        [ChildActionOnly]
        public PartialViewResult _Header()
        {
            return PartialView(GetAssignments());
        }

        public List<AssignmentModel> GetAssignments() {
            return db.AssignmentModels.ToList() ?? new List<AssignmentModel>();
        }
    }
}