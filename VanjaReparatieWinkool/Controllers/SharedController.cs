using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using VanjaReparatieWinkool.DAL;
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
    }
}