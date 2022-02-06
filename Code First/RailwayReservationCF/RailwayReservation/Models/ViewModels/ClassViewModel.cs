using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RailwayReservation.Models.ViewModels
{
    public class ClassViewModel
    {
        [Display(Name = "ID")]
        [Key]
        public int ClassID { get; set; }


        [Display(Name = "Class")]
        [Required(ErrorMessage = "Enter Class Name")]
        [DataType(DataType.Text)]
        public string ClassName { get; set; }


        [Display(Name = "Fare")]
        [Required(ErrorMessage = "Enter Fare")]
        [DataType(DataType.Currency)]
        public decimal Fare { get; set; }
    }
}