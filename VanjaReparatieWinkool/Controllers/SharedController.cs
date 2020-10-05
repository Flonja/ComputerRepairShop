using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
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
            List<AssignmentModel> assignments = db.AssignmentModels.ToList() ?? new List<AssignmentModel>();
            assignments.Sort(new AssignmentsCompare());

            return assignments;
        }
    }

    class AssignmentsCompare : IComparer<AssignmentModel>
    {
        public int Compare(AssignmentModel x, AssignmentModel y)
        {
            if (x.Status == y.Status)
            {
                return 0;
            }

            return x.Status.CompareTo(y.Status);
        }
    }
}