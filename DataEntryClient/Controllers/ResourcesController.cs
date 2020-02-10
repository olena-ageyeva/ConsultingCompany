using ConsultingCompany.Lib;
using ConsultingCompany.Lib.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataEntryClient.Controllers
{
    public class ResourcesController : Controller   
    {
        private IConsultingCompanyRepository db;

        public ResourcesController(IConsultingCompanyRepository db)
        {
            this.db = db;
        }
        // GET: Resources
        public ActionResult Index()
        {
            ViewBag.LoggedIn = db.LoggedIn();
            var model = db.GetOrderedResources();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = db.GetResource(id);
            if (model == null)
            {
                return View("NotFound"); //RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Resource resource)
        {            
            if (ModelState.IsValid)
            {
                db.AddResource(resource);
                return RedirectToAction("Details", new { id = resource.Id }); //View("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.GetResource(id);
            if (model == null)
            {
                return View("NotFound"); //RedirectToAction("Index");
            }
            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Resource resource)
        {
           
            if (ModelState.IsValid)
            {
                db.UpdateResource(resource);
                return RedirectToAction("Details", new { id = resource.Id });
            }
            return View(resource);
        }

        public ActionResult Delete(int id)
        {
            var model = db.GetResource(id);
            if (model == null)
            {
                return View("NotFound"); //RedirectToAction("Index");
            }
            return View(model);
        }


        [HttpPost]
        public ActionResult Delete(Resource resource)
        {
            db.DeleteResource(resource);
            return RedirectToAction("Index");
        }
    }
}