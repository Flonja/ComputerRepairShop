using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using VanjaReparatieWinkool.DAL;
using VanjaReparatieWinkool.Models;

namespace VanjaReparatieWinkool.Controllers
{
    public class AssignmentsController : SharedController
    {
        private VanjaReparatieWinkoolContext db = new VanjaReparatieWinkoolContext();

        // GET: AssignmentModels
        public ActionResult Index()
        {
            return View(db.Assignments.ToList());
        }

        // GET: AssignmentModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignmentModel assignmentModel = db.Assignments.Find(id);
            if (assignmentModel == null)
            {
                return HttpNotFound();
            }
            return View(assignmentModel);
        }

        // GET: AssignmentModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AssignmentModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AssignmentId,Omschrijving,Status,StartDatum,EindDatum,Uren")] AssignmentModel assignmentModel)
        {
            if (ModelState.IsValid)
            {
                db.Assignments.Add(assignmentModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(assignmentModel);
        }

        // GET: AssignmentModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignmentModel assignmentModel = db.Assignments.Find(id);
            if (assignmentModel == null)
            {
                return HttpNotFound();
            }
            return View(assignmentModel);
        }

        // POST: AssignmentModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssignmentId,Omschrijving,Status,StartDatum,EindDatum,Uren")] AssignmentModel assignmentModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assignmentModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(assignmentModel);
        }

        // GET: AssignmentModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignmentModel assignmentModel = db.Assignments.Find(id);
            if (assignmentModel == null)
            {
                return HttpNotFound();
            }
            return View(assignmentModel);
        }

        // POST: AssignmentModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssignmentModel assignmentModel = db.Assignments.Find(id);
            db.Assignments.Remove(assignmentModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
