using ConsultingCompany.DataStore;
using ConsultingCompany.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace DataEntryClient.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly IConsultingCompanyRepository db;

        public HomeController(IConsultingCompanyRepository db)
        {
            this.db = db;
        }

        [HttpGet]
        public ActionResult Index()
        {         
            return View();
        }

        [HttpPost]
       public ActionResult Index(User user)
        {
            ViewBag.Message = "";
           if (db.PasswordMatch(user.UserName, user.Password)!= null)
            {
                db.LogIn(true);
                ViewBag.Message = "Welcome, " + user.UserName + "!";
            }

            return View();
        }
        

    }
}