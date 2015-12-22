using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace talekarmilk.Areas.Admin.Controllers
{
    public class LogoutController : Controller
    {
        //
        // GET: /Admin/Logout/

        public ActionResult Index()
        {
            Session.Abandon();
            return Redirect("~/Talekar/Index");
        }

    }
}
