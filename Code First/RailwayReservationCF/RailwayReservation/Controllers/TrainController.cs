using RailwayReservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RailwayReservation.Controllers
{
    public class TrainController : Controller
    {
        ApplicationDbContext dbObj = new ApplicationDbContext();
        // GET: Train
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateTrain()
        {
            var Model = dbObj.Trains.ToList();
            return View(Model);
        }
        public ActionResult AjaxCreateTrain(Train obj)
        {
            if (ModelState.IsValid == true)
            {
                System.Threading.Thread.Sleep(1000);
                dbObj.Trains.Add(obj);
                dbObj.SaveChanges();
            }
            IEnumerable<Train> Model = dbObj.Trains.ToList();
            return PartialView("_TrainDetails", Model);
        }
    }
}