using System;
using System.ComponentModel.DataAnnotations;

namespace MegaDesk.Models
{
    public class Order
    {
        public int ID { get; set; }

        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        public string LastName { get; set; }

        public double Width { get; set; }

        public double Depth { get; set; }

        public int Drawers { get; set; }

        [Display(Name = "Surface Material")]
        public int SurfaceMaterial { get; set; }

        [Display(Name = "Rush Order")]
        public int RushOrder { get; set; }

        [Display(Name = "Date Added")]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }

    }
}