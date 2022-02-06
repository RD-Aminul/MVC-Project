using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RailwayReservation.Models.ViewModels
{
    public class TrainViewModel
    {
        [Display(Name = "ID")]
        public int TrainNo { get; set; }


        [Display(Name = "Train")]
        [Required(ErrorMessage = "Enter Train Name")]
        [DataType(DataType.Text)]
        public string TrainName { get; set; }
    }
}