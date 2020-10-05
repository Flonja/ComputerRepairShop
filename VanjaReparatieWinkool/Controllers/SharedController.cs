using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using VanjaReparatieWinkool.DAL;
using VanjaReparatieWinkool.Models;
using VanjaReparatieWinkool.ViewModels;

namespace VanjaReparatieWinkool.Controllers
{
    public class SharedController : Controller
    {
        private VanjaReparatieWinkoolContext db = new VanjaReparatieWinkoolContext();

        [ChildActionOnly]
        public PartialViewResult _Header()
        {
            return PartialView(GetStatus());
        }

        public IEnumerable<AssignmentStatus> GetStatus()
        {
            IQueryable<AssignmentStatus> data = from order in db.Assignments
                                                group order by order.Status into statusGroup
                                                select new AssignmentStatus()
                                                {
                                                    RepairStatus = statusGroup.Key,
                                                    StatusCount = statusGroup.Count()
                                                };
            return data.ToList();
        }

        public List<AssignmentModel> GetAssignments() {
            List<AssignmentModel> assignments = db.Assignments.ToList() ?? new List<AssignmentModel>();
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