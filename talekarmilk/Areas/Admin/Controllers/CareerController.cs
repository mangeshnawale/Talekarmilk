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
    public class CareerController : Controller
    {
        private indrayanimilkEntities db = new indrayanimilkEntities();

        //
        // GET: /Admin/Career/

        public ActionResult Index()
        {
            return View(db.TblCareers.ToList());
        }

        //
        // GET: /Admin/Career/Details/5

        public ActionResult Details(int id = 0)
        {
            TblCareer tblcareer = db.TblCareers.Find(id);
            if (tblcareer == null)
            {
                return HttpNotFound();
            }
            return View(tblcareer);
        }

        //
        // GET: /Admin/Career/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Career/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TblCareer tblcareer)
        {
            var postdate = Request["postdate"];
            var lastdate = Request["lastdate"];
            if (ModelState.IsValid)
            {
                tblcareer.job_date_post = postdate;
                tblcareer.job_last_date = lastdate;
                db.TblCareers.Add(tblcareer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblcareer);
        }

        //
        // GET: /Admin/Career/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TblCareer tblcareer = db.TblCareers.Find(id);
            if (tblcareer == null)
            {
                return HttpNotFound();
            }
            return View(tblcareer);
        }

        //
        // POST: /Admin/Career/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TblCareer tblcareer)
        {
            var postdate = Request["postdate"];
            var lastdate = Request["lastdate"];
            
            if (ModelState.IsValid)
            {
                tblcareer.job_date_post = postdate;
                tblcareer.job_last_date = lastdate;
                
                db.Entry(tblcareer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblcareer);
        }

        //
        // GET: /Admin/Career/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TblCareer tblcareer = db.TblCareers.Find(id);
            if (tblcareer == null)
            {
                return HttpNotFound();
            }
            return View(tblcareer);
        }

        //
        // POST: /Admin/Career/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblCareer tblcareer = db.TblCareers.Find(id);
            db.TblCareers.Remove(tblcareer);
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