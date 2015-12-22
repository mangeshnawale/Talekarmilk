using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using talekarmilk.Models;

namespace talekarmilk.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/Admin/
        //indrayanimilkEntities db = new indrayanimilkEntities();
        public ActionResult Index()
        {
            return View();
        }

    }
}
