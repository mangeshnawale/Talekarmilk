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
    public class CityController : Controller
    {
        private indrayanimilkEntities db = new indrayanimilkEntities();

        //
        // GET: /Admin/City/

        public ActionResult Index()
        {
            var tblcities = db.TblCities.Include(t => t.TblState);
            return View(tblcities.ToList());
        }

        //
        // GET: /Admin/City/Details/5

        public ActionResult Details(int id = 0)
        {
            TblCity tblcity = db.TblCities.Find(id);
            if (tblcity == null)
            {
                return HttpNotFound();
            }
            return View(tblcity);
        }

        //
        // GET: /Admin/City/Create

        public ActionResult Create()
        {
            ViewBag.state_id = new SelectList(db.TblStates, "state_id", "state_name");
            return View();
        }

        //
        // POST: /Admin/City/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TblCity tblcity)
        {
            if (ModelState.IsValid)
            {
                db.TblCities.Add(tblcity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.state_id = new SelectList(db.TblStates, "state_id", "state_name", tblcity.state_id);
            return View(tblcity);
        }

        //
        // GET: /Admin/City/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TblCity tblcity = db.TblCities.Find(id);
            if (tblcity == null)
            {
                return HttpNotFound();
            }
            ViewBag.state_id = new SelectList(db.TblStates, "state_id", "state_name", tblcity.state_id);
            return View(tblcity);
        }

        //
        // POST: /Admin/City/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TblCity tblcity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblcity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.state_id = new SelectList(db.TblStates, "state_id", "state_name", tblcity.state_id);
            return View(tblcity);
        }

        //
        // GET: /Admin/City/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TblCity tblcity = db.TblCities.Find(id);
            if (tblcity == null)
            {
                return HttpNotFound();
            }
            return View(tblcity);
        }

        //
        // POST: /Admin/City/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblCity tblcity = db.TblCities.Find(id);
            db.TblCities.Remove(tblcity);
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