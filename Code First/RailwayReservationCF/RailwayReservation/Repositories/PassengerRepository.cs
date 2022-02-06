using RailwayReservation.Models;
using RailwayReservation.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RailwayReservation.Repositories
{
    public class PassengerRepository
    {
        ApplicationDbContext dbObj = new ApplicationDbContext();
        public IEnumerable<PassengerViewModel> GetAllPassengers()
        {
            List<PassengerViewModel> Passlist = dbObj.Passengers.Select(p => new PassengerViewModel
            {
                PassengerID = p.PassengerID,
                PassengerName = p.PassengerName,
                PassengerEmail = p.PassengerEmail,
                PassengerPhone = p.PassengerPhone,
                JourneyDate = p.JourneyDate,
                TrainNo = p.TrainNo,
                TrainName = p.Train.TrainName,
                RouteName = p.Route.RouteName,
                ClassName = p.Class.ClassName,
                Fare = p.Class.Fare,
                ClassID=p.ClassID,
                RouteID=p.RouteID,
                ImageName = p.ImageName,
                ImageUrl = p.ImageUrl,
                PageTitle = "Passenger List"
            }).ToList();
            return Passlist;
        }
        public Passenger GetPassenger(int id)
        {

            Passenger obj = dbObj.Passengers.SingleOrDefault(p => p.PassengerID == id);
            return obj;
        }
        public void SavePassenger(Passenger sobj)
        {
            dbObj.Passengers.Add(sobj);
            dbObj.SaveChanges();
        }
        public void UpdatePassenger(Passenger upobj)
        {
            dbObj.Entry(upobj).State = EntityState.Modified;
            dbObj.SaveChanges();
        }
        public void DeletePassenger(int id)
        {
            Passenger deletePass = GetPassenger(id);
            dbObj.Passengers.Remove(deletePass);
            dbObj.SaveChanges();
        }
        public List<Train> GetTrains()
        {
            List<Train> list = dbObj.Trains.ToList();
            return list;
        }
        public List<Route> GetRoutes()
        {
            List<Route> list = dbObj.Routes.ToList();
            return list;
        }
        public List<Class> GetClasses()
        {
            List<Class> list = dbObj.Classes.ToList();
            return list;
        }
    }
}