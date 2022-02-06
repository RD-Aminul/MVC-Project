using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RailwayReservation.Models.ViewModels
{
    public class RouteViewModel
    {

        [Display(Name = "ID")]
        [Key]
        public int RouteID { get; set; }


        [Display(Name = "Route")]
        [Required(ErrorMessage = "Enter Route Name")]
        [DataType(DataType.Text)]
        public string RouteName { get; set; }
    }
}