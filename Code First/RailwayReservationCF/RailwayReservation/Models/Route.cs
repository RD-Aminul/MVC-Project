//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RailwayReservation.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Route
    {
        public Route()
        {
            this.Passengers = new HashSet<Passenger>();
        }

        [Key]
        public int RouteID { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string RouteName { get; set; }
    
        public virtual ICollection<Passenger> Passengers { get; set; }
    }
}
