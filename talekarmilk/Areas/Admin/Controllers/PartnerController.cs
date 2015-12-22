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
    public class PartnerController : Controller
    {
        private indrayanimilkEntities db = new indrayanimilkEntities();

        //
        // GET: /Admin/Partner/

        public ActionResult Index()
        {
            return View(db.TablPartners.ToList());
        }

        //
        // GET: /Admin/Partner/Details/5

        public ActionResult Details(int id = 0)
        {
            TablPartner tablpartner = db.TablPartners.Find(id);
            if (tablpartner == null)
            {
                return HttpNotFound();
            }
            return View(tablpartner);
        }

        //
        // GET: /Admin/Partner/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Partner/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TablPartner tablpartner)
        {
            if (ModelState.IsValid)
            {
                db.TablPartners.Add(tablpartner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tablpartner);
        }

        //
        // GET: /Admin/Partner/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TablPartner tablpartner = db.TablPartners.Find(id);
            if (tablpartner == null)
            {
                return HttpNotFound();
            }
            return View(tablpartner);
        }

        //
        // POST: /Admin/Partner/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TablPartner tablpartner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tablpartner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tablpartner);
        }

        //
        // GET: /Admin/Partner/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TablPartner tablpartner = db.TablPartners.Find(id);
            if (tablpartner == null)
            {
                return HttpNotFound();
            }
            return View(tablpartner);
        }

        //
        // POST: /Admin/Partner/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TablPartner tablpartner = db.TablPartners.Find(id);
            db.TablPartners.Remove(tablpartner);
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