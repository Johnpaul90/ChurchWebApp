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
    public class MinistriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Ministries
        public ActionResult Index()
        {
            var ministries = db.Ministries.Include(m => m.AvgChurchSize).Include(m => m.Country).Include(m => m.Denomination).Include(m => m.MinistryCategory);
            return View(ministries.ToList());
        }

        // GET: Ministries/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ministry ministry = db.Ministries.Find(id);
            if (ministry == null)
            {
                return HttpNotFound();
            }
            return View(ministry);
        }

        // GET: Ministries/Create
        public ActionResult Create()
        {
            var mz = db.MinistrySizes.Select(a=> new { ID=a.ID, Range=a.from+" - " +a.to });
            ViewBag.MinistrySizeId = new SelectList(mz, "ID", "Range");
            ViewBag.CountryId = new SelectList(db.Countries, "ID", "Name");
            ViewBag.DenominationId = new SelectList(db.Denominations, "ID", "Type");
            ViewBag.MinistryCategoryId = new SelectList(db.MinistryCategories, "ID", "Name");
            return View();
        }

        // POST: Ministries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MinistryCategoryId,MinistrySizeId,DenominationId,CountryId,Name,PhoneNumber1,PhoneNumber2,Email,Town,State,Vision,Mission,About,Logo,LogoBlob,FacebookUrl,TwitterUrl,YoutubeUrl,InstagramUrl,Source,DateEntered,DateClaimed,IsVerified,IsClaimed")] Ministry ministry)
        {
            if (ModelState.IsValid)
            {
                ministry.ID = Guid.NewGuid();
                db.Ministries.Add(ministry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MinistrySizeId = new SelectList(db.MinistrySizes, "ID", "ID", ministry.MinistrySizeId);
            ViewBag.CountryId = new SelectList(db.Countries, "ID", "Name", ministry.CountryId);
            ViewBag.DenominationId = new SelectList(db.Denominations, "ID", "Type", ministry.DenominationId);
            ViewBag.MinistryCategoryId = new SelectList(db.MinistryCategories, "ID", "Name", ministry.MinistryCategoryId);
            return View(ministry);
        }

        // GET: Ministries/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ministry ministry = db.Ministries.Find(id);
            if (ministry == null)
            {
                return HttpNotFound();
            }
            ViewBag.MinistrySizeId = new SelectList(db.MinistrySizes, "ID", "ID", ministry.MinistrySizeId);
            ViewBag.CountryId = new SelectList(db.Countries, "ID", "Name", ministry.CountryId);
            ViewBag.DenominationId = new SelectList(db.Denominations, "ID", "Type", ministry.DenominationId);
            ViewBag.MinistryCategoryId = new SelectList(db.MinistryCategories, "ID", "Name", ministry.MinistryCategoryId);
            return View(ministry);
        }

        // POST: Ministries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MinistryCategoryId,MinistrySizeId,DenominationId,CountryId,Name,PhoneNumber1,PhoneNumber2,Email,Town,State,Vision,Mission,About,Logo,LogoBlob,FacebookUrl,TwitterUrl,YoutubeUrl,InstagramUrl,Source,DateEntered,DateClaimed,IsVerified,IsClaimed")] Ministry ministry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ministry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MinistrySizeId = new SelectList(db.MinistrySizes, "ID", "ID", ministry.MinistrySizeId);
            ViewBag.CountryId = new SelectList(db.Countries, "ID", "Name", ministry.CountryId);
            ViewBag.DenominationId = new SelectList(db.Denominations, "ID", "Type", ministry.DenominationId);
            ViewBag.MinistryCategoryId = new SelectList(db.MinistryCategories, "ID", "Name", ministry.MinistryCategoryId);
            return View(ministry);
        }

        // GET: Ministries/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ministry ministry = db.Ministries.Find(id);
            if (ministry == null)
            {
                return HttpNotFound();
            }
            return View(ministry);
        }

        // POST: Ministries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Ministry ministry = db.Ministries.Find(id);
            db.Ministries.Remove(ministry);
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
