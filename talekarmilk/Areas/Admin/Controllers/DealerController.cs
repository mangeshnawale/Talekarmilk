using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using talekarmilk.Models;

namespace talekarmilk.Areas.Admin.Controllers
{
    public class DealerController : Controller
    {
        private indrayanimilkEntities db = new indrayanimilkEntities();

        //
        // GET: /Admin/Dealer/

        public ActionResult Index()
        {
            return View(db.TblDealers.ToList());
        }

        //
        // GET: /Admin/Dealer/Details/5

        public ActionResult Details(int id = 0)
        {
            TblDealer tbldealer = db.TblDealers.Find(id);
            if (tbldealer == null)
            {
                return HttpNotFound();
            }
            return View(tbldealer);
        }

        //
        // GET: /Admin/Dealer/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Dealer/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TblDealer tbldealer)
        {
            if (ModelState.IsValid)
            {
                db.TblDealers.Add(tbldealer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbldealer);
        }

        //
        // GET: /Admin/Dealer/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TblDealer tbldealer = db.TblDealers.Find(id);
            if (tbldealer == null)
            {
                return HttpNotFound();
            }
            return View(tbldealer);
        }

        //
        // POST: /Admin/Dealer/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TblDealer tbldealer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbldealer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbldealer);
        }

        //
        // GET: /Admin/Dealer/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TblDealer tbldealer = db.TblDealers.Find(id);
            if (tbldealer == null)
            {
                return HttpNotFound();
            }
            return View(tbldealer);
        }

        //
        // POST: /Admin/Dealer/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblDealer tbldealer = db.TblDealers.Find(id);
            db.TblDealers.Remove(tbldealer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}