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
    public class StateController : Controller
    {
        private indrayanimilkEntities db = new indrayanimilkEntities();

        //
        // GET: /Admin/State/

        public ActionResult Index()
        {
            var tblstates = db.TblStates.Include(t => t.TblCountry);
            return View(tblstates.ToList());
        }

        //
        // GET: /Admin/State/Details/5

        public ActionResult Details(int id = 0)
        {
            TblState tblstate = db.TblStates.Find(id);
            if (tblstate == null)
            {
                return HttpNotFound();
            }
            return View(tblstate);
        }

        //
        // GET: /Admin/State/Create

        public ActionResult Create()
        {
            ViewBag.country_id = new SelectList(db.TblCountries, "country_id", "country_name");
            return View();
        }

        //
        // POST: /Admin/State/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TblState tblstate)
        {
            if (ModelState.IsValid)
            {
                db.TblStates.Add(tblstate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.country_id = new SelectList(db.TblCountries, "country_id", "country_name", tblstate.country_id);
            return View(tblstate);
        }

        //
        // GET: /Admin/State/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TblState tblstate = db.TblStates.Find(id);
            if (tblstate == null)
            {
                return HttpNotFound();
            }
            ViewBag.country_id = new SelectList(db.TblCountries, "country_id", "country_name", tblstate.country_id);
            return View(tblstate);
        }

        //
        // POST: /Admin/State/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TblState tblstate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblstate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.country_id = new SelectList(db.TblCountries, "country_id", "country_name", tblstate.country_id);
            return View(tblstate);
        }

        //
        // GET: /Admin/State/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TblState tblstate = db.TblStates.Find(id);
            if (tblstate == null)
            {
                return HttpNotFound();
            }
            return View(tblstate);
        }

        //
        // POST: /Admin/State/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblState tblstate = db.TblStates.Find(id);
            db.TblStates.Remove(tblstate);
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