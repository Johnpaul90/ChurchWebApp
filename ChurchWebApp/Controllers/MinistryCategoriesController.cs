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
    public class MinistryCategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MinistryCategories
        public ActionResult Index()
        {
            return View(db.MinistryCategories.ToList());
        }

        // GET: MinistryCategories/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MinistryCategory ministryCategory = db.MinistryCategories.Find(id);
            if (ministryCategory == null)
            {
                return HttpNotFound();
            }
            return View(ministryCategory);
        }

        // GET: MinistryCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MinistryCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] MinistryCategory ministryCategory)
        {
            if (ModelState.IsValid)
            {
                ministryCategory.ID = Guid.NewGuid();
                db.MinistryCategories.Add(ministryCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ministryCategory);
        }

        // GET: MinistryCategories/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MinistryCategory ministryCategory = db.MinistryCategories.Find(id);
            if (ministryCategory == null)
            {
                return HttpNotFound();
            }
            return View(ministryCategory);
        }

        // POST: MinistryCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] MinistryCategory ministryCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ministryCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ministryCategory);
        }

        // GET: MinistryCategories/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MinistryCategory ministryCategory = db.MinistryCategories.Find(id);
            if (ministryCategory == null)
            {
                return HttpNotFound();
            }
            return View(ministryCategory);
        }

        // POST: MinistryCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            MinistryCategory ministryCategory = db.MinistryCategories.Find(id);
            db.MinistryCategories.Remove(ministryCategory);
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
