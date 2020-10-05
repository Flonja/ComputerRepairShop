﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VanjaReparatieWinkool.DAL;
using VanjaReparatieWinkool.Models;

namespace VanjaReparatieWinkool.Controllers
{
    public class PartModelsController : SharedController
    {
        private VanjaReparatieWinkoolContext db = new VanjaReparatieWinkoolContext();

        // GET: PartModels
        public ActionResult Index()
        {
            return View(db.PartModels.ToList());
        }

        // GET: PartModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartModel partModel = db.PartModels.Find(id);
            if (partModel == null)
            {
                return HttpNotFound();
            }
            return View(partModel);
        }

        // GET: PartModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PartModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PartId,Naam,Leverancier,Aantal,Prijs")] PartModel partModel)
        {
            if (ModelState.IsValid)
            {
                db.PartModels.Add(partModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(partModel);
        }

        // GET: PartModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartModel partModel = db.PartModels.Find(id);
            if (partModel == null)
            {
                return HttpNotFound();
            }
            return View(partModel);
        }

        // POST: PartModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PartId,Naam,Leverancier,Aantal,Prijs")] PartModel partModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(partModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(partModel);
        }

        // GET: PartModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartModel partModel = db.PartModels.Find(id);
            if (partModel == null)
            {
                return HttpNotFound();
            }
            return View(partModel);
        }

        // POST: PartModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PartModel partModel = db.PartModels.Find(id);
            db.PartModels.Remove(partModel);
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
