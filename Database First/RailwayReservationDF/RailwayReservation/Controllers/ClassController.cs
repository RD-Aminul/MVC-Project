using RailwayReservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RailwayReservation.Controllers
{
    public class ClassController : Controller
    {
        RailwayDBEntities dbObj = new RailwayDBEntities();
        // GET: Class
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateClass()
        {
            var Model = dbObj.Classes.ToList();
            return View(Model);
        }
        public ActionResult AjaxCreateClass(Class obj)
        {
            if (ModelState.IsValid == true)
            {
                System.Threading.Thread.Sleep(1000);
                dbObj.Classes.Add(obj);
                dbObj.SaveChanges();
            }
            IEnumerable<Class> Model = dbObj.Classes.ToList();
            return PartialView("_ClassDetails", Model);
        }
    }
}