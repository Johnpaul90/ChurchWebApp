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
    public class MinistrySizesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MinistrySizes
        public ActionResult Index()
        {
            return View(db.MinistrySizes.ToList());
        }

        // GET: MinistrySizes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MinistrySize ministrySize = db.MinistrySizes.Find(id);
            if (ministrySize == null)
            {
                return HttpNotFound();
            }
            return View(ministrySize);
        }

        // GET: MinistrySizes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MinistrySizes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,from,to")] MinistrySize ministrySize)
        {
            if (ModelState.IsValid)
            {
                ministrySize.ID = Guid.NewGuid();
                db.MinistrySizes.Add(ministrySize);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ministrySize);
        }

        // GET: MinistrySizes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MinistrySize ministrySize = db.MinistrySizes.Find(id);
            if (ministrySize == null)
            {
                return HttpNotFound();
            }
            return View(ministrySize);
        }

        // POST: MinistrySizes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,from,to")] MinistrySize ministrySize)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ministrySize).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ministrySize);
        }

        // GET: MinistrySizes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MinistrySize ministrySize = db.MinistrySizes.Find(id);
            if (ministrySize == null)
            {
                return HttpNotFound();
            }
            return View(ministrySize);
        }

        // POST: MinistrySizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            MinistrySize ministrySize = db.MinistrySizes.Find(id);
            db.MinistrySizes.Remove(ministrySize);
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
