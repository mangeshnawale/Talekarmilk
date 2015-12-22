using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using talekarmilk.Models;
using System.Net.Mail;
using System.Net;

namespace talekarmilk.Controllers
{
    public class TalekarController : Controller
    {
        //
        // GET: /Talekar/
        //talekarEntities1 db = new talekarEntities1();
        indrayanimilkEntities db = new indrayanimilkEntities();

        public void data()
        {
            //ViewBag.About = db.TblAbouts.ToList();
            ViewBag.About = db.TblAboutDairies.ToList();
            ViewBag.Director = db.TblAboutDirectors.ToList();
            ViewBag.Product = db.TblProducts.ToList();
            ViewBag.Gallary = db.Tbl_Gallary.ToList();
            ViewBag.Prize = db.TblProductPackages.ToList();
            ViewBag.Infrastructure = db.TblInfrastructures.ToList();
            ViewBag.Country = db.TblCountries.ToList();
            ViewBag.City = db.TblCities.ToList();
            ViewBag.State = db.TblStates.ToList();
            ViewBag.Career = db.TblCareers.ToList();
            
        }
        public ActionResult Index()
        {
            data();
            return View();
            
        }
        [HttpPost]
        public ActionResult Contact(TblContact c)
        {
            var fname = Request["fname"];
            var lname = Request["lname"];
            var email=Request["email"];
            var mobile=Request["mobile"];
            var message = Request["message"];
            var sub=Request["subject"];
            if (ModelState.IsValid)
            {
                c.fname = fname;
                c.lname = lname;
                c.message = message;
                c.mobile = mobile;
                c.email = email;
                c.subject = sub;
                db.TblContacts.Add(c);
                db.SaveChanges();
            }
            try
            {
                MailMessage msg = new MailMessage();
                msg.To.Add("milk.indrayani@gmail.com");
                msg.From = new MailAddress(email);
                msg.Subject = sub;
                msg.Body = "Hi, new enrty from contact us page<br><br>Name:<b>" + fname + "</b><br>Email:<b>" + email + "</b><br>Subject:<b>" + sub + "</b><br>Message:<b>" + message + "</b>" + "<br><br>Thanks & Regards,<br><b>Indrayani Milk Marketing</b>";
                msg.IsBodyHtml = true;
                SmtpClient smtp2 = new SmtpClient();
                smtp2.Host = "smtp.gmail.com";
                smtp2.EnableSsl = true;
                NetworkCredential NetworkCred2 = new NetworkCredential("milk.indrayani@gmail.com", "steelframe_9");
                smtp2.UseDefaultCredentials = false;
                smtp2.Credentials = NetworkCred2;
                smtp2.Port = 25;
                smtp2.Send(msg);

                return RedirectToAction("Index", "Talekar");
            }
            catch
            {
                return RedirectToAction("Index", "Talekar");
            }

        }
        public ActionResult Product()
        {
            data();
            return View();
        }
        public ActionResult Gallary()
        {
            data();
            return View();
        }
        public ActionResult Product_View(int prod_id)
        {
            data();
          int pid= Convert.ToInt32(Request.QueryString["prod_id"]);

          ViewBag.pid = pid;
            return View();
        }
        public ActionResult _LayoutIndex()
        {
            data();
            return View();
        }
        public ActionResult Dealer()
        {
            data();
            return View();

        }
        [HttpPost]
        public ActionResult Dealer(TblDealer d)
        {
            var name = Request["name"];
            var email = Request["email"];
            var number = Request["mobile"];
            var faxnumber=Request["faxnumber"];
            var address=Request["address"];
            var pincode=Request["pincode"];
            var city = Request["city"];
            var state=Request["state"];
            var country=Request["country"];
            var company=Request["company"];
            var description=Request["description"];
            if (ModelState.IsValid)
            {
                d.dealer_name = name;
                d.dealer_number = number;
                d.dealer_email = email;
                d.dealer_fax = faxnumber;
                d.dealer_address = address;
                d.dealer_pin = pincode;
                d.dealer_city = city;
                d.dealer_state = state;
                d.dealer_country = country;
                d.dealer_company = company;
                d.dealer_description = description;
                db.TblDealers.Add(d);
                db.SaveChanges();
            }
            try
            {
                MailMessage msg = new MailMessage();
                msg.To.Add("milk.indrayani@gmail.com");
                msg.From = new MailAddress(email);
                msg.Subject = "New entry for in Dealership form";
                msg.Body = "Hi, new request for dealership<br><br>Name:<b>" + name + "</b><br>Email:<b>" + email + "</b><br>Mobile Number:<b>" + number + "</b><br>Description:<b>" + description + "</b>" + "<br><br>Thanks & Regards,<br><b>Indrayani Milk Marketing</b>";
                msg.IsBodyHtml = true;
                SmtpClient smtp2 = new SmtpClient();
                smtp2.Host = "smtp.gmail.com";
                smtp2.EnableSsl = true;
                NetworkCredential NetworkCred2 = new NetworkCredential("milk.indrayani@gmail.com", "steelframe_9");
                smtp2.UseDefaultCredentials = false;
                smtp2.Credentials = NetworkCred2;
                smtp2.Port = 25;
                smtp2.Send(msg);
                return RedirectToAction("Index", "Talekar");
            }
            catch
            {
                return RedirectToAction("Dealer", "Talekar");
            }
        }
        public ActionResult Franchise()
        {
            data();
            return View();

        }
        [HttpPost]
        public ActionResult Franchise(TblFranchise d)
        {
            var name = Request["name"];
            var email = Request["email"];
            var number = Request["mobile"];
            var faxnumber = Request["faxnumber"];
            var address = Request["address"];
            var pincode = Request["pincode"];
            var city = Request["city"];
            var state = Request["state"];
            var country = Request["country"];
            var company = Request["company"];
            var description = Request["description"];
            if (ModelState.IsValid)
            {
                d.fran_name = name;
                d.fran_number = number;
                d.fran_email=email;
                d.fran_fax = faxnumber;
                d.fran_address = address;
                d.fran_pin = pincode;
                d.fran_city = city;
                d.fran_state = state;
                d.fran_country = country;
                d.fran_company = company;
                d.fran_description = description;
                db.TblFranchises.Add(d);
                db.SaveChanges();

            }
            try
            {
                MailMessage msg = new MailMessage();
                msg.To.Add("milk.indrayani@gmail.com");
                msg.From = new MailAddress(email);
                msg.Subject = "New entry for in Franchise form";
                msg.Body = "Hi, new request forfranchise<br><br>Name:<b>" + name + "</b><br>Email:<b>" + email + "</b><br>Mobile Number:<b>" + number + "</b><br>Description:<b>" + description + "</b>" + "<br><br>Thanks & Regards,<br><b>Indrayani Milk Marketing</b>";
                msg.IsBodyHtml = true;
                SmtpClient smtp2 = new SmtpClient();
                smtp2.Host = "smtp.gmail.com";
                smtp2.EnableSsl = true;
                NetworkCredential NetworkCred2 = new NetworkCredential("milk.indrayani@gmail.com", "steelframe_9");
                smtp2.UseDefaultCredentials = false;
                smtp2.Credentials = NetworkCred2;
                smtp2.Port = 25;
                smtp2.Send(msg);
                
                return RedirectToAction("Index", "Talekar");
            }
            catch
            {
                return RedirectToAction("Franchise", "Talekar");
            }
        }
        public ActionResult Partner()
        {
            data();
            return View();

        }
        [HttpPost]
        public ActionResult Partner(TablPartner p)
        {
            var name = Request["name"];
            var email = Request["email"];
            var number = Request["mobile"];
            var company = Request["company"];
            var message = Request["message"];
            var designation = Request["designation"];
            if (ModelState.IsValid)
            {
                p.part_name = name;
                p.part_number = number;
                p.part_email = email;
                p.part_company = company;
                p.part_designation = designation;
                p.part_message = message;
                db.TablPartners.Add(p);
                db.SaveChanges();
            }
            try
            {

                MailMessage msg = new MailMessage();
                msg.To.Add("milk.indrayani@gmail.com");
                msg.From = new MailAddress(email);
                msg.Subject = "New entry for in Dealership form";
                msg.Body = "Hi, new request for dealership<br><br>Name:<b>" + name + "</b><br>Email:<b>" + email + "</b><br>Mobile Number:<b>" + number + "</b><br>Message<b>" + message + "</b>" + "<br><br>Thanks & Regards,<br><b>Indrayani Milk Marketing</b>";
                msg.IsBodyHtml = true;
                SmtpClient smtp2 = new SmtpClient();
                smtp2.Host = "smtp.gmail.com";
                smtp2.EnableSsl = true;
                NetworkCredential NetworkCred2 = new NetworkCredential("milk.indrayani@gmail.com", "steelframe_9");
                smtp2.UseDefaultCredentials = false;
                smtp2.Credentials = NetworkCred2;
                smtp2.Port = 25;
                smtp2.Send(msg);
                return RedirectToAction("Index", "Talekar");
            }
            catch
            {
                return RedirectToAction("Partner", "Talekar");
            }
        }

        public ActionResult Career()
        {
            data();
            return View();

        }
    
    }
}
