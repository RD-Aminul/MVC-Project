using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RailwayReservation.Repositories
{
    public class ValidationJournyDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime CurrentDate = DateTime.Now;
            string msg = string.Empty;
            if (Convert.ToDateTime(value).Date >= CurrentDate.Date)
            {
                return ValidationResult.Success;
            }
            else
            {
                msg = "Journey Date Must be Today to Next";
                return new ValidationResult(msg);
            }
        }
    }
}