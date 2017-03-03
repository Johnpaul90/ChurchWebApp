using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ChurchWebApp.Models;

namespace ChurchWebApp.Controllers
{
    public class DenominationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Denominations
        public ActionResult Index()
        {
            return View(db.Denominations.ToList());
        }

        // GET: Denominations/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Denomination denomination = db.Denominations.Find(id);
            if (denomination == null)
            {
                return HttpNotFound();
            }
            return View(denomination);
        }

        // GET: Denominations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Denominations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Type")] Denomination denomination)
        {
            if (ModelState.IsValid)
            {
                denomination.ID = Guid.NewGuid();
                db.Denominations.Add(denomination);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(denomination);
        }

        // GET: Denominations/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Denomination denomination = db.Denominations.Find(id);
            if (denomination == null)
            {
                return HttpNotFound();
            }
            return View(denomination);
        }

        // POST: Denominations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Type")] Denomination denomination)
        {
            if (ModelState.IsValid)
            {
                db.Entry(denomination).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(denomination);
        }

        // GET: Denominations/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Denomination denomination = db.Denominations.Find(id);
            if (denomination == null)
            {
                return HttpNotFound();
            }
            return View(denomination);
        }

        // POST: Denominations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Denomination denomination = db.Denominations.Find(id);
            db.Denominations.Remove(denomination);
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
