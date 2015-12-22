using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using talekarmilk.Models;
using System.IO;

namespace talekarmilk.Areas.Admin.Controllers
{
    public class AboutdirectorController : Controller
    {
        private indrayanimilkEntities db = new indrayanimilkEntities();

        //
        // GET: /Admin/Aboutdirector/

        public ActionResult Index()
        {
            return View(db.TblAboutDirectors.ToList());
        }

        //
        // GET: /Admin/Aboutdirector/Details/5

        public ActionResult Details(int id = 0)
        {
            TblAboutDirector tblaboutdirector = db.TblAboutDirectors.Find(id);
            if (tblaboutdirector == null)
            {
                return HttpNotFound();
            }
            return View(tblaboutdirector);
        }

        //
        // GET: /Admin/Aboutdirector/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Aboutdirector/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TblAboutDirector tblaboutdirector)
        {
            if (ModelState.IsValid)
            {
                var file = Request.Files["file"];
                var filename = Path.GetFileName(file.FileName);
                if (filename != "")
                {
                    var path = Path.Combine(Server.MapPath("~/saveimages"), filename);
                    file.SaveAs(path);
                    tblaboutdirector.dir_image = filename;
                }
                
                db.TblAboutDirectors.Add(tblaboutdirector);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblaboutdirector);
        }

        //
        // GET: /Admin/Aboutdirector/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TblAboutDirector tblaboutdirector = db.TblAboutDirectors.Find(id);
            if (tblaboutdirector == null)
            {
                return HttpNotFound();
            }
            return View(tblaboutdirector);
        }

        //
        // POST: /Admin/Aboutdirector/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TblAboutDirector tblaboutdirector)
        {
            if (ModelState.IsValid)
            {
                var file = Request.Files["file"];
                var filename = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/saveimages"), filename);
                if (filename != "")
                {
                    
                    file.SaveAs(path);
                    tblaboutdirector.dir_image = filename;
                }
                db.Entry(tblaboutdirector).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblaboutdirector);
        }

        //
        // GET: /Admin/Aboutdirector/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TblAboutDirector tblaboutdirector = db.TblAboutDirectors.Find(id);
            if (tblaboutdirector == null)
            {
                return HttpNotFound();
            }
            return View(tblaboutdirector);
        }

        //
        // POST: /Admin/Aboutdirector/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblAboutDirector tblaboutdirector = db.TblAboutDirectors.Find(id);
            db.TblAboutDirectors.Remove(tblaboutdirector);
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