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
    public class InfrastructureController : Controller
    {
        private indrayanimilkEntities db = new indrayanimilkEntities();

        //
        // GET: /Admin/Infrastructure/

        public ActionResult Index()
        {
            return View(db.TblInfrastructures.ToList());
        }

        //
        // GET: /Admin/Infrastructure/Details/5

        public ActionResult Details(int id = 0)
        {
            TblInfrastructure tblinfrastructure = db.TblInfrastructures.Find(id);
            if (tblinfrastructure == null)
            {
                return HttpNotFound();
            }
            return View(tblinfrastructure);
        }

        //
        // GET: /Admin/Infrastructure/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Infrastructure/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TblInfrastructure tblinfrastructure)
        {
            if (ModelState.IsValid)
            {
                var file = Request.Files["file"];
                var filename = Path.GetFileName(file.FileName);
                if (filename != "")
                {
                    var path = Path.Combine(Server.MapPath("~/saveimages"), filename);
                    file.SaveAs(path);
                    tblinfrastructure.infra_image = filename;
                }
                
                db.TblInfrastructures.Add(tblinfrastructure);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblinfrastructure);
        }

        //
        // GET: /Admin/Infrastructure/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TblInfrastructure tblinfrastructure = db.TblInfrastructures.Find(id);
            if (tblinfrastructure == null)
            {
                return HttpNotFound();
            }
            return View(tblinfrastructure);
        }

        //
        // POST: /Admin/Infrastructure/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TblInfrastructure tblinfrastructure)
        {
            if (ModelState.IsValid)
            {
                var file = Request.Files["file"];
                var filename = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/saveimages"), filename);
                if (filename != "")
                {

                    file.SaveAs(path);
                    tblinfrastructure.infra_image = filename;
                }
                db.Entry(tblinfrastructure).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblinfrastructure);
        }

        //
        // GET: /Admin/Infrastructure/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TblInfrastructure tblinfrastructure = db.TblInfrastructures.Find(id);
            if (tblinfrastructure == null)
            {
                return HttpNotFound();
            }
            return View(tblinfrastructure);
        }

        //
        // POST: /Admin/Infrastructure/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblInfrastructure tblinfrastructure = db.TblInfrastructures.Find(id);
            db.TblInfrastructures.Remove(tblinfrastructure);
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