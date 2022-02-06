using RailwayReservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RailwayReservation.Controllers
{
    public class RouteController : Controller
    {
        ApplicationDbContext dbObj = new ApplicationDbContext();
        // GET: Route
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateRoute()
        {
            var Model = dbObj.Routes.ToList();
            return View(Model);
        }
        public ActionResult AjaxCreateRoute(Route obj)
        {
            if (ModelState.IsValid == true)
            {
                System.Threading.Thread.Sleep(1000);
                dbObj.Routes.Add(obj);
                dbObj.SaveChanges();
            }
            IEnumerable<Route> Model = dbObj.Routes.ToList();
            return PartialView("_RouteDetails", Model);
        }
    }
}