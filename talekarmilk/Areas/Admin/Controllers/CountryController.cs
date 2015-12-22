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
    public class CountryController : Controller
    {
        private indrayanimilkEntities db = new indrayanimilkEntities();

        //
        // GET: /Admin/Country/

        public ActionResult Index()
        {
            return View(db.TblCountries.ToList());
        }

        //
        // GET: /Admin/Country/Details/5

        public ActionResult Details(int id = 0)
        {
            TblCountry tblcountry = db.TblCountries.Find(id);
            if (tblcountry == null)
            {
                return HttpNotFound();
            }
            return View(tblcountry);
        }

        //
        // GET: /Admin/Country/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Country/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TblCountry tblcountry)
        {
            if (ModelState.IsValid)
            {
                db.TblCountries.Add(tblcountry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblcountry);
        }

        //
        // GET: /Admin/Country/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TblCountry tblcountry = db.TblCountries.Find(id);
            if (tblcountry == null)
            {
                return HttpNotFound();
            }
            return View(tblcountry);
        }

        //
        // POST: /Admin/Country/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TblCountry tblcountry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblcountry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblcountry);
        }

        //
        // GET: /Admin/Country/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TblCountry tblcountry = db.TblCountries.Find(id);
            if (tblcountry == null)
            {
                return HttpNotFound();
            }
            return View(tblcountry);
        }

        //
        // POST: /Admin/Country/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblCountry tblcountry = db.TblCountries.Find(id);
            db.TblCountries.Remove(tblcountry);
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