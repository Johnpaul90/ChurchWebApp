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
    public class PastorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Pastors
        public ActionResult Index()
        {
            var pastors = db.Pastors.Include(p => p.Ministry);
            return View(pastors.ToList());
        }

        // GET: Pastors/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pastor pastor = db.Pastors.Find(id);
            if (pastor == null)
            {
                return HttpNotFound();
            }
            return View(pastor);
        }

        // GET: Pastors/Create
        public ActionResult Create()
        {
            ViewBag.MinistryId = new SelectList(db.Ministries, "ID", "Name");
            return View();
        }

        // POST: Pastors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "iD,MinistryId,Name,PhoneNumber1,PhoneNumber2,Email,Qualification,Biography,Picture,PictureBlob,PictureWithWife,PictureWithWifeBlob,Facebook,Twitter,Youtube,Instagram,VideoIntroduction,IsMainPastor")] Pastor pastor)
        {
            if (ModelState.IsValid)
            {
                pastor.iD = Guid.NewGuid();
                db.Pastors.Add(pastor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MinistryId = new SelectList(db.Ministries, "ID", "Name", pastor.MinistryId);
            return View(pastor);
        }

        // GET: Pastors/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pastor pastor = db.Pastors.Find(id);
            if (pastor == null)
            {
                return HttpNotFound();
            }
            ViewBag.MinistryId = new SelectList(db.Ministries, "ID", "Name", pastor.MinistryId);
            return View(pastor);
        }

        // POST: Pastors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "iD,MinistryId,Name,PhoneNumber1,PhoneNumber2,Email,Qualification,Biography,Picture,PictureBlob,PictureWithWife,PictureWithWifeBlob,Facebook,Twitter,Youtube,Instagram,VideoIntroduction,IsMainPastor")] Pastor pastor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pastor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MinistryId = new SelectList(db.Ministries, "ID", "Name", pastor.MinistryId);
            return View(pastor);
        }

        // GET: Pastors/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pastor pastor = db.Pastors.Find(id);
            if (pastor == null)
            {
                return HttpNotFound();
            }
            return View(pastor);
        }

        // POST: Pastors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Pastor pastor = db.Pastors.Find(id);
            db.Pastors.Remove(pastor);
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
