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
    public class VibesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Vibes
        public ActionResult Index()
        {
            return View(db.Vibes.ToList());
        }

        // GET: Vibes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vibe vibe = db.Vibes.Find(id);
            if (vibe == null)
            {
                return HttpNotFound();
            }
            return View(vibe);
        }

        // GET: Vibes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vibes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] Vibe vibe)
        {
            if (ModelState.IsValid)
            {
                vibe.ID = Guid.NewGuid();
                db.Vibes.Add(vibe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vibe);
        }

        // GET: Vibes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vibe vibe = db.Vibes.Find(id);
            if (vibe == null)
            {
                return HttpNotFound();
            }
            return View(vibe);
        }

        // POST: Vibes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] Vibe vibe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vibe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vibe);
        }

        // GET: Vibes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vibe vibe = db.Vibes.Find(id);
            if (vibe == null)
            {
                return HttpNotFound();
            }
            return View(vibe);
        }

        // POST: Vibes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Vibe vibe = db.Vibes.Find(id);
            db.Vibes.Remove(vibe);
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
