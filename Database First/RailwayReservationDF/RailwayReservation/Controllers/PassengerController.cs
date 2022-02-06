using CrystalDecisions.CrystalReports.Engine;
using PagedList;
using RailwayReservation.Models;
using RailwayReservation.Models.ViewModels;
using RailwayReservation.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RailwayReservation.Controllers
{
    public class PassengerController : Controller
    {
        RailwayDBEntities dbObj = new RailwayDBEntities();
        // GET: Passenger
        PassengerRepository repo = new PassengerRepository();
        [HttpGet]
        public ActionResult Index(string SearchString, string CurrentFilter, string SortOrder, int? page)
        {
            if (SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = CurrentFilter;
            }
            ViewBag.SortNameParam = string.IsNullOrEmpty(SortOrder) ? "name_desc" : "";
            ViewBag.CurrentFilter = SearchString;
            IEnumerable<PassengerViewModel> list = repo.GetAllPassengers();
            if (!string.IsNullOrEmpty(SearchString))
            {
                list = list.Where(p => p.PassengerName.ToUpper().Contains(SearchString.ToUpper())).ToList();
            }
            switch (SortOrder)
            {
                case "name_desc":
                    list = list.OrderByDescending(p => p.PassengerName).ToList();
                    break;
                default:
                    list = list.OrderBy(p => p.PassengerName).ToList();
                    break;
            }
            int pageSize = 2;
            int pageNumber = (page ?? 1);
            return View(list.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ViewResult Insert()
        {
            List<Train> tlist = repo.GetTrains();
            ViewBag.Trains = tlist;
            List<Route> rlist = repo.GetRoutes();
            ViewBag.Routes = rlist;
            List<Class> clist = repo.GetClasses();
            ViewBag.Classes = clist;
            return View();
        }
        [HttpGet]
        public PartialViewResult Edit(int id)
        {
            List<Train> tlist = repo.GetTrains();
            ViewBag.Trains = tlist;
            List<Route> rlist = repo.GetRoutes();
            ViewBag.Routes = rlist;
            List<Class> clist = repo.GetClasses();
            ViewBag.Classes = clist;
            Passenger pass = repo.GetPassenger(id);
            PassengerViewModel obj = new PassengerViewModel();
            obj.PassengerID = pass.PassengerID;
            obj.PassengerName = pass.PassengerName;
            obj.PassengerEmail = pass.PassengerEmail;
            obj.PassengerPhone = pass.PassengerPhone;
            obj.JourneyDate = pass.JourneyDate;
            obj.TrainNo = pass.TrainNo;
            obj.ClassID = pass.ClassID;
            obj.RouteID = pass.RouteID;
            obj.TrainName = pass.Train.TrainName;
            obj.RouteName = pass.Route.RouteName;
            obj.ClassName = pass.Class.ClassName;
            obj.Fare = pass.Class.Fare;
            obj.ImageName = pass.ImageName;
            obj.ImageUrl = pass.ImageUrl;
            ViewBag.Details = "Show";
            return PartialView("_EditPassenger", obj);
        }
        [HttpGet]
        public PartialViewResult Delete(int id)
        {
            List<Train> tlist = repo.GetTrains();
            ViewBag.Trains = tlist;
            List<Route> rlist = repo.GetRoutes();
            ViewBag.Routes = rlist;
            List<Class> clist = repo.GetClasses();
            ViewBag.Classes = clist;
            Passenger pass = repo.GetPassenger(id);
            PassengerViewModel obj = new PassengerViewModel();
            obj.PassengerID = pass.PassengerID;
            obj.PassengerName = pass.PassengerName;
            obj.PassengerEmail = pass.PassengerEmail;
            obj.PassengerPhone = pass.PassengerPhone;
            obj.JourneyDate = pass.JourneyDate;
            obj.TrainNo = pass.TrainNo;
            obj.ClassID = pass.ClassID;
            obj.RouteID = pass.RouteID;
            obj.TrainName = pass.Train.TrainName;
            obj.RouteName = pass.Route.RouteName;
            obj.ClassName = pass.Class.ClassName;
            obj.Fare = pass.Class.Fare;
            obj.ImageName = pass.ImageName;
            obj.ImageUrl = pass.ImageUrl;
            ViewBag.Details = "Show";
            return PartialView("_DeletePassenger", obj);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult PostDelete(PassengerViewModel viewObj)
        {
            List<Train> tlist = repo.GetTrains();
            ViewBag.Trains = tlist;
            List<Route> rlist = repo.GetRoutes();
            ViewBag.Routes = rlist;
            List<Class> clist = repo.GetClasses();
            ViewBag.Classes = clist;
            Passenger obj = repo.GetPassenger(viewObj.PassengerID);
            string imageName = viewObj.ImageName;
            DeleteExistingImage(imageName);
            repo.DeletePassenger(obj.PassengerID);
            return RedirectToAction("Index");
        }
        public PartialViewResult Details(int id)
        {
            List<Train> tlist = repo.GetTrains();
            ViewBag.Trains = tlist;
            List<Route> rlist = repo.GetRoutes();
            ViewBag.Routes = rlist;
            List<Class> clist = repo.GetClasses();
            ViewBag.Classes = clist;
            Passenger pass = repo.GetPassenger(id);
            PassengerViewModel obj = new PassengerViewModel();
            obj.PassengerID = pass.PassengerID;
            obj.PassengerName = pass.PassengerName;
            obj.PassengerEmail = pass.PassengerEmail;
            obj.PassengerPhone = pass.PassengerPhone;
            obj.JourneyDate = pass.JourneyDate;
            obj.TrainNo = pass.TrainNo;
            obj.TrainName = pass.Train.TrainName;
            obj.RouteName = pass.Route.RouteName;
            obj.ClassName = pass.Class.ClassName;
            obj.Fare = pass.Class.Fare;
            obj.ImageName = pass.ImageName;
            obj.ImageUrl = pass.ImageUrl;
            ViewBag.Details = "Show";
            return PartialView("_PassengerDetails", obj);
        }


        [HttpPost]
        [ActionName("Insert")]
        public ActionResult PostInsert(PassengerViewModel viewobj)
        {
            var result = false;
            Passenger domainobj;
            if (viewobj.PassengerID == 0)
            {
                if (ModelState.IsValid)
                {
                    domainobj = new Passenger();
                    domainobj.PassengerName = viewobj.PassengerName;
                    domainobj.PassengerEmail = viewobj.PassengerEmail;
                    domainobj.PassengerPhone = viewobj.PassengerPhone;
                    domainobj.JourneyDate = viewobj.JourneyDate;
                    domainobj.TrainNo = viewobj.TrainNo;
                    domainobj.ClassID = viewobj.ClassID;
                    domainobj.RouteID = viewobj.RouteID;
                    string fileName = Path.GetFileNameWithoutExtension(viewobj.ImageFile.FileName);
                    string extension = Path.GetExtension(viewobj.ImageFile.FileName);
                    domainobj.ImageName = fileName + extension;
                    domainobj.ImageUrl = "~/Images/" + domainobj.ImageName;
                    fileName = Path.Combine(Server.MapPath(domainobj.ImageUrl));
                    viewobj.ImageFile.SaveAs(fileName);
                    repo.SavePassenger(domainobj);
                    result = true;
                }
            }
            else
            {
                domainobj = repo.GetPassenger(viewobj.PassengerID);
                domainobj.PassengerName = viewobj.PassengerName;
                domainobj.PassengerEmail = viewobj.PassengerEmail;
                domainobj.PassengerPhone = viewobj.PassengerPhone;
                domainobj.JourneyDate = viewobj.JourneyDate;
                domainobj.TrainNo = viewobj.TrainNo;
                domainobj.ClassID = viewobj.ClassID;
                domainobj.RouteID = viewobj.RouteID;

                if (viewobj.ImageFile != null)
                {

                    string fileName = Path.GetFileNameWithoutExtension(viewobj.ImageFile.FileName);
                    string extension = Path.GetExtension(viewobj.ImageFile.FileName);
                    domainobj.ImageName = fileName + extension;
                    domainobj.ImageUrl = "~/Images/" + domainobj.ImageName;
                    fileName = Path.Combine(Server.MapPath(domainobj.ImageUrl));
                    viewobj.ImageFile.SaveAs(fileName);
                }
                else
                {
                    viewobj.ImageName = domainobj.ImageName;
                    viewobj.ImageUrl = domainobj.ImageUrl;
                }
                repo.UpdatePassenger(domainobj);
                result = true;

            }
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                List<Train> tlist = repo.GetTrains();
                ViewBag.Trains = tlist;
                List<Route> rlist = repo.GetRoutes();
                ViewBag.Routes = rlist;
                List<Class> clist = repo.GetClasses();
                ViewBag.Classes = clist;
                return View();
            }

        }

        private void DeleteExistingImage(string imagename)
        {
            string root = Server.MapPath("~");
            string parent = Path.GetDirectoryName(root);
            string path = parent + "/Images/" + imagename;
            FileInfo fileObj = new FileInfo(path);
            if (fileObj.Exists)
            {
                fileObj.Delete();
            }
        }

        public ActionResult PassengerReport()
        {
            repo.GetAllPassengers();
            ReportDocument rd = new ReportDocument();
            string path = Server.MapPath("~") + "Report//" + "PassengerReport.rpt";
            rd.Load(path);
            IEnumerable<PassengerViewModel> flist = repo.GetAllPassengers();
            rd.SetDataSource(flist);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "PassengerReport.pdf");
        }
        public ActionResult Reports()
        {
            using (RailwayDBEntities dc = new RailwayDBEntities())
            {
                var c = dc.Classes.ToList();
                var p = dc.Passengers.ToList();
                var r = dc.Routes.ToList();
                var t = dc.Trains.ToList();
                return View(p);
            }
        }
    }
}