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
    public class ProductPrizeController : Controller
    {
        private indrayanimilkEntities db = new indrayanimilkEntities();

        //
        // GET: /Admin/ProductPrize/

        public ActionResult Index()
        {
            var tblproductpackages = db.TblProductPackages.Include(t => t.TblProduct);
            return View(tblproductpackages.ToList());
        }

        //
        // GET: /Admin/ProductPrize/Details/5

        public ActionResult Details(int id = 0)
        {
            TblProductPackage tblproductpackage = db.TblProductPackages.Find(id);
            if (tblproductpackage == null)
            {
                return HttpNotFound();
            }
            return View(tblproductpackage);
        }

        //
        // GET: /Admin/ProductPrize/Create

        public ActionResult Create()
        {
            ViewBag.pro_id = new SelectList(db.TblProducts, "pro_id", "pro_name");
            return View();
        }

        //
        // POST: /Admin/ProductPrize/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TblProductPackage tblproductpackage)
        {
            if (ModelState.IsValid)
            {
                db.TblProductPackages.Add(tblproductpackage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.pro_id = new SelectList(db.TblProducts, "pro_id", "pro_name", tblproductpackage.pro_id);
            return View(tblproductpackage);
        }

        //
        // GET: /Admin/ProductPrize/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TblProductPackage tblproductpackage = db.TblProductPackages.Find(id);
            if (tblproductpackage == null)
            {
                return HttpNotFound();
            }
            ViewBag.pro_id = new SelectList(db.TblProducts, "pro_id", "pro_name", tblproductpackage.pro_id);
            return View(tblproductpackage);
        }

        //
        // POST: /Admin/ProductPrize/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TblProductPackage tblproductpackage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblproductpackage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.pro_id = new SelectList(db.TblProducts, "pro_id", "pro_name", tblproductpackage.pro_id);
            return View(tblproductpackage);
        }

        //
        // GET: /Admin/ProductPrize/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TblProductPackage tblproductpackage = db.TblProductPackages.Find(id);
            if (tblproductpackage == null)
            {
                return HttpNotFound();
            }
            return View(tblproductpackage);
        }

        //
        // POST: /Admin/ProductPrize/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblProductPackage tblproductpackage = db.TblProductPackages.Find(id);
            db.TblProductPackages.Remove(tblproductpackage);
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