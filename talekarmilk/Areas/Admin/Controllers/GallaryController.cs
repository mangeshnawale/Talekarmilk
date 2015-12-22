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
    public class GallaryController : Controller
    {
        private indrayanimilkEntities db = new indrayanimilkEntities();

        //
        // GET: /Admin/Gallary/

        public ActionResult Index()
        {
            return View(db.Tbl_Gallary.ToList());
        }

        //
        // GET: /Admin/Gallary/Details/5

        public ActionResult Details(int id = 0)
        {
            Tbl_Gallary tbl_gallary = db.Tbl_Gallary.Find(id);
            if (tbl_gallary == null)
            {
                return HttpNotFound();
            }
            return View(tbl_gallary);
        }

        //
        // GET: /Admin/Gallary/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Gallary/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tbl_Gallary tbl_gallary)
        {
            if (ModelState.IsValid)
            {
                var file = Request.Files["file"];
                var filename = Path.GetFileName(file.FileName);
                if (filename != "")
                {
                    var path = Path.Combine(Server.MapPath("~/saveimages"), filename);
                    file.SaveAs(path);
                    tbl_gallary.img_image = filename;
                }
                
                db.Tbl_Gallary.Add(tbl_gallary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_gallary);
        }

        //
        // GET: /Admin/Gallary/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Tbl_Gallary tbl_gallary = db.Tbl_Gallary.Find(id);
            if (tbl_gallary == null)
            {
                return HttpNotFound();
            }
            return View(tbl_gallary);
        }

        //
        // POST: /Admin/Gallary/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tbl_Gallary tbl_gallary)
        {
            if (ModelState.IsValid)
            {
                var file = Request.Files["file"];
                var filename = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/saveimages"), filename);
                if (filename != "")
                {

                    file.SaveAs(path);
                    tbl_gallary.img_image = filename;
                }
                db.Entry(tbl_gallary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_gallary);
        }

        //
        // GET: /Admin/Gallary/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Tbl_Gallary tbl_gallary = db.Tbl_Gallary.Find(id);
            if (tbl_gallary == null)
            {
                return HttpNotFound();
            }
            return View(tbl_gallary);
        }

        //
        // POST: /Admin/Gallary/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Gallary tbl_gallary = db.Tbl_Gallary.Find(id);
            db.Tbl_Gallary.Remove(tbl_gallary);
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