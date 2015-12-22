using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using talekarmilk.Models;

namespace talekarmilk.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Admin/Login/
        indrayanimilkEntities db = new indrayanimilkEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Login(TblAdmin u)
        {
            string username = Request["username"].ToString();
            string password = Request["password"].ToString();
            var v = db.TblAdmins.Where(a => a.admin_username.Equals(username) && a.admin_password.Equals(password)).FirstOrDefault();
            if (v != null)
            {
                Session["LogedAdminID"] = v.admin_name;
                return Redirect("~/Admin");
            }
            else
            {
                ViewBag.LoginFaild = "Invalid username or password";
                return View("Index");
            }
        }
    }

}
