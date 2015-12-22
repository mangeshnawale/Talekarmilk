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
    public class ProductController : Controller
    {
        private indrayanimilkEntities db = new indrayanimilkEntities();

        //
        // GET: /Admin/Product/

        public ActionResult Index()
        {
            return View(db.TblProducts.ToList());
        }

        //
        // GET: /Admin/Product/Details/5

        public ActionResult Details(int id = 0)
        {
            TblProduct tblproduct = db.TblProducts.Find(id);
            if (tblproduct == null)
            {
                return HttpNotFound();
            }
            return View(tblproduct);
        }

        //
        // GET: /Admin/Product/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Product/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TblProduct tblproduct)
        {
            if (ModelState.IsValid)
            {
                var file = Request.Files["file"];
                var filename = Path.GetFileName(file.FileName);
                if (filename != "")
                {
                    var path = Path.Combine(Server.MapPath("~/saveimages"), filename);
                    file.SaveAs(path);
                    tblproduct.pro_image = filename;
                }
                
                db.TblProducts.Add(tblproduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblproduct);
        }

        //
        // GET: /Admin/Product/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TblProduct tblproduct = db.TblProducts.Find(id);
            if (tblproduct == null)
            {
                return HttpNotFound();
            }
            return View(tblproduct);
        }

        //
        // POST: /Admin/Product/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TblProduct tblproduct)
        {
            if (ModelState.IsValid)
            {
                var file = Request.Files["file"];
                var filename = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/saveimages"), filename);
                if (filename != "")
                {
                    
                    file.SaveAs(path);
                    tblproduct.pro_image = filename;
                }
                db.Entry(tblproduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblproduct);
        }

        //
        // GET: /Admin/Product/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TblProduct tblproduct = db.TblProducts.Find(id);
            if (tblproduct == null)
            {
                return HttpNotFound();
            }
            return View(tblproduct);
        }

        //
        // POST: /Admin/Product/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblProduct tblproduct = db.TblProducts.Find(id);
            db.TblProducts.Remove(tblproduct);
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