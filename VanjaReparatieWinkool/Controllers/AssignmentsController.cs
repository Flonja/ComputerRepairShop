using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using VanjaReparatieWinkool.DAL;
using VanjaReparatieWinkool.Models;
using VanjaReparatieWinkool.ViewModels;

namespace VanjaReparatieWinkool.Controllers
{
    public class AssignmentsController : SharedController
    {
        private VanjaReparatieWinkoolContext db = new VanjaReparatieWinkoolContext();

        // GET: Assignments
        public ActionResult Index()
        {
            return View(GetAssignments());
        }

        // GET: Assignments/Details/5
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

        // GET: Assignments/Create
        public ActionResult Create()
        {
            var viewModel = new AssignmentViewModel();
            viewModel.Klanten = db.Customers.ToList();
            viewModel.Werknemers = db.Employees.ToList();
            //viewModel.Opdracht = 
            return View(viewModel);
        }

        // POST: Assignments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Bind(Include = "AssignmentId,Omschrijving,StartDatum,EindDatum")] 
        public ActionResult Create(AssignmentViewModel assignmentModel)
        {
            if (assignmentModel.Opdracht.StartDatum.CompareTo(DateTime.Today) < 0)
            {
                ModelState.AddModelError("StartDatum", "");
            }

            if (assignmentModel.Opdracht.EindDatum.CompareTo(assignmentModel.Opdracht.StartDatum) < 0)
            {
                ModelState.AddModelError("StartDatum", "");
                ModelState.AddModelError("EindDatum", "");
            }

            if (ModelState.IsValid)
            {
                assignmentModel.Opdracht.Uren = 0;
                assignmentModel.Opdracht.Status = Status.InAfwachting;
                assignmentModel.Opdracht.Klant = db.Customers.Find(assignmentModel.KlantId);
                assignmentModel.Opdracht.Werknemer = db.Employees.Find(assignmentModel.WerknemerId);

                db.Assignments.Add(assignmentModel.Opdracht);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(assignmentModel);
        }

        // GET: Assignments/Edit/5
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

        // POST: Assignments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssignmentId,Omschrijving,Status,EindDatum,Uren")] AssignmentModel assignmentModelLocal)
        {
            if (ModelState.IsValid)
            {
                AssignmentModel assignmentModel = db.Assignments.Find(assignmentModelLocal.AssignmentId);
                ModelState.Remove("StartDatum");

                assignmentModelLocal.StartDatum = assignmentModel.StartDatum;

                db.Assignments.Remove(assignmentModel);
                db.Assignments.Add(assignmentModelLocal);

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(assignmentModelLocal);
        }

        // GET: Assignments/Delete/5
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

        // POST: Assignments/Delete/5
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
