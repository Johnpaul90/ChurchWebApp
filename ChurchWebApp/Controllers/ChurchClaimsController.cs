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
    public class ChurchClaimsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ChurchClaims
        public ActionResult Index()
        {
            var churchClaims = db.ChurchClaims.Include(c => c.Ministry);
            return View(churchClaims.ToList());
        }

        // GET: ChurchClaims/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChurchClaims churchClaims = db.ChurchClaims.Find(id);
            if (churchClaims == null)
            {
                return HttpNotFound();
            }
            return View(churchClaims);
        }

        // GET: ChurchClaims/Create
        public ActionResult Create()
        {
            ViewBag.MinistryId = new SelectList(db.Ministries, "ID", "Name");
            return View();
        }

        // POST: ChurchClaims/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserId,MinistryId")] ChurchClaims churchClaims)
        {
            if (ModelState.IsValid)
            {
                churchClaims.ID = Guid.NewGuid();
                db.ChurchClaims.Add(churchClaims);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MinistryId = new SelectList(db.Ministries, "ID", "Name", churchClaims.MinistryId);
            return View(churchClaims);
        }

        // GET: ChurchClaims/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChurchClaims churchClaims = db.ChurchClaims.Find(id);
            if (churchClaims == null)
            {
                return HttpNotFound();
            }
            ViewBag.MinistryId = new SelectList(db.Ministries, "ID", "Name", churchClaims.MinistryId);
            return View(churchClaims);
        }

        // POST: ChurchClaims/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserId,MinistryId")] ChurchClaims churchClaims)
        {
            if (ModelState.IsValid)
            {
                db.Entry(churchClaims).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MinistryId = new SelectList(db.Ministries, "ID", "Name", churchClaims.MinistryId);
            return View(churchClaims);
        }

        // GET: ChurchClaims/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChurchClaims churchClaims = db.ChurchClaims.Find(id);
            if (churchClaims == null)
            {
                return HttpNotFound();
            }
            return View(churchClaims);
        }

        // POST: ChurchClaims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ChurchClaims churchClaims = db.ChurchClaims.Find(id);
            db.ChurchClaims.Remove(churchClaims);
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
