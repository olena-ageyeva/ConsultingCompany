using ConsultingCompany.DataStore;
using ConsultingCompany.Lib;
using ConsultingCompany.Lib.Entity;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataEntryClient.Controllers
{
    
    public class ClientsController : Controller
    {
        private readonly IConsultingCompanyRepository db;
        
        public ClientsController(IConsultingCompanyRepository db)
        {
            this.db = db;
        }


        [HttpGet]
       // public ActionResult Index()
       // {
       //     ViewBag.Message = "Our Clients";
       //     ViewBag.LoggedIn = db.LoggedIn();
       //     dynamic mymodel = new ExpandoObject();
       //     mymodel.Clients = db.GetOrderedClients();
       //     mymodel.Resources = db.GetOrderedResources();
        //    return View(mymodel);
        //}

        
        public ActionResult Index(string searchString)
        {
          
            ViewBag.Message = "Our Clients";
            ViewBag.LoggedIn = db.LoggedIn();
            dynamic mymodel = new ExpandoObject();
            mymodel.Clients = db.GetOrderedClients();
            mymodel.Resources = db.GetOrderedResources();

            if (!String.IsNullOrEmpty(searchString))
            {
                mymodel.Clients = db.GetOrderedClients().Where(c => c.CompanyName.Contains(searchString));
            }

            return View(mymodel);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = db.Get(id);
            if (model== null)
            {
                return View("NotFound"); //RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Resources = db.GetOrderedResources();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client client)
        {           

            if (ModelState.IsValid)
            {
                db.Add(client);
                return RedirectToAction("Details", new { id = client.Id }); //View("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound"); //RedirectToAction("Index");
            }
            
            return View(model);           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Client client)
        {
           if (ModelState.IsValid)
            {
                db.Update(client);
                return RedirectToAction("Details", new { id = client.Id });
            }
            return View(client);
        }

        public ActionResult Delete(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound"); //RedirectToAction("Index");
            }
            return View(model);
        }


        [HttpPost]        
        public ActionResult Delete(Client client)
        {
            db.Delete(client);
            return RedirectToAction("Index");
        }
    }
}