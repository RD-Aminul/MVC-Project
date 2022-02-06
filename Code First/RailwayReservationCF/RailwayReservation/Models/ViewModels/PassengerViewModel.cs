using RailwayReservation.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RailwayReservation.Models.ViewModels
{
    public class PassengerViewModel
    {
        [Display(Name = "ID")]
        [Key]
        public int PassengerID { get; set; }


        [Display(Name = "Passenger Name")]
        [Required(ErrorMessage = "Enter Passenger Name")]
        [DataType(DataType.Text)]
        public string PassengerName { get; set; }


        [Display(Name = "Passenger Email")]
        [Required(ErrorMessage = "Enter Passenger Email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$", ErrorMessage = "Email is not valid")]
        public string PassengerEmail { get; set; }


        [Display(Name = "Passenger Mobile")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Enter Passenger Phone")]
        public string PassengerPhone { get; set; }


        [Display(Name = "Journey Date")]
        [Required(ErrorMessage = "Please Select Journey Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.DateTime)]
        [ValidationJournyDate]
        public DateTime JourneyDate { get; set; }


        [Display(Name = "Image Name")]
        public string ImageName { get; set; }


        [Display(Name = "Image")]
        [DataType(DataType.Upload)]
        public string ImageUrl { get; set; }


        [Display(Name = "Train")]
        [Required(ErrorMessage = "Please Select Train")]
        public int TrainNo { get; set; }


        [Display(Name = "Train Name")]
        public string TrainName { get; set; }


        [Display(Name = "Class")]
        [Required(ErrorMessage = "Please Select Class")]
        public int ClassID { get; set; }


        [Display(Name = "Class Name")]
        public string ClassName { get; set; }


        [Display(Name = "Fare")]
        [Required(ErrorMessage = "Enter Fare")]
        [DataType(DataType.Currency)]
        public decimal Fare { get; set; }


        [Display(Name = "Route")]
        [Required(ErrorMessage = "Please Select Route")]
        public int RouteID { get; set; }


        [Display(Name = "Train Route")]
        public string RouteName { get; set; }


        public HttpPostedFileBase ImageFile { get; set; }
        public string PageTitle { get; set; }
    }
}