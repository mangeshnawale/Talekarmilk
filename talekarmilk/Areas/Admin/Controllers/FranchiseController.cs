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
    public class FranchiseController : Controller
    {
        private indrayanimilkEntities db = new indrayanimilkEntities();

        //
        // GET: /Admin/Franchise/

        public ActionResult Index()
        {
            return View(db.TblFranchises.ToList());
        }

        //
        // GET: /Admin/Franchise/Details/5

        public ActionResult Details(int id = 0)
        {
            TblFranchise tblfranchise = db.TblFranchises.Find(id);
            if (tblfranchise == null)
            {
                return HttpNotFound();
            }
            return View(tblfranchise);
        }

        //
        // GET: /Admin/Franchise/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Franchise/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TblFranchise tblfranchise)
        {
            if (ModelState.IsValid)
            {
                db.TblFranchises.Add(tblfranchise);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblfranchise);
        }

        //
        // GET: /Admin/Franchise/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TblFranchise tblfranchise = db.TblFranchises.Find(id);
            if (tblfranchise == null)
            {
                return HttpNotFound();
            }
            return View(tblfranchise);
        }

        //
        // POST: /Admin/Franchise/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TblFranchise tblfranchise)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblfranchise).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblfranchise);
        }

        //
        // GET: /Admin/Franchise/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TblFranchise tblfranchise = db.TblFranchises.Find(id);
            if (tblfranchise == null)
            {
                return HttpNotFound();
            }
            return View(tblfranchise);
        }

        //
        // POST: /Admin/Franchise/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblFranchise tblfranchise = db.TblFranchises.Find(id);
            db.TblFranchises.Remove(tblfranchise);
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