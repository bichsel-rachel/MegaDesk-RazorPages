using System;
using System.ComponentModel.DataAnnotations;

namespace MegaDesk.Models
{
    public class Order
    {

        public int[] RushPrices = new int[] { 60, 40, 30, 70, 50, 35, 80, 60, 40 };

        // Constants for use in validation.  Possibly will use?
        public const int MINWIDTH = 24;
        public const int MAXWIDTH = 96;
        public const int MINDEPTH = 12;
        public const int MAXDEPTH = 48;

        public const int MINDRAWERS = 0;
        public const int MAXDRAWERS = 7;

        public const int BASEPRICE = 200;

        public enum SurfaceMaterials
        {
            Laminate = 100,
            Oak = 200,
            Rosewood = 300,
            Veneer = 125,
            Pine = 50
        }

        public int ID { get; set; }

        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        public string LastName { get; set; }

        public double Width { get; set; }

        public double Depth { get; set; }

        public int Drawers { get; set; }

        [Display(Name = "Surface Material")]
        public string SurfaceMaterial { get; set; }

        [Display(Name = "Rush Order")]
        public int RushOrder { get; set; }

        [Display(Name = "Total")]
        public double QuoteTotal { get; set; }

        [Display(Name = "Date Added")]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }

        public int getQuoteTotal()
        {
            var total = 90 * 10;

            return total;
        }

        // Gets the cost of the surface materials the client wants
        public double getSurfaceMaterialCost()
        {
            double cost = 0;

            switch (SurfaceMaterial)
            {
                case "Oak":
                    cost = (int)SurfaceMaterials.Oak;
                    break;

                case "Laminate":
                    cost = (int)SurfaceMaterials.Laminate;
                    break;

                case "Pine":
                    cost = (int)SurfaceMaterials.Pine;
                    break;

                case "Rosewood":
                    cost = (int)SurfaceMaterials.Rosewood;
                    break;

                case "Veneer":
                    cost = (int)SurfaceMaterials.Veneer;
                    break;
            }

            return cost;
        }

        // Calculates the entire surface area
        public double getDeskSurfaceArea()
        {
            return Width * Depth;
        }

        // Returns the cost above the base price if the surface area is greater than 1000 sq in
        public double getSurfaceAreaCost()
        {
            double cost = 0;
            double surfaceArea = getDeskSurfaceArea();

            if (surfaceArea > 1000)
            {
                cost = surfaceArea - 1000;
            }

            return cost;
        }

        // Returns the cost of drawers, based on how many the client orders
        public double getDrawerCost()
        {
            return Drawers * 50;
        }

        // Gets the rush order options based on desk size
        public double getRushOrderPrice()
        {
            double price = 0;
            double surfaceArea = getDeskSurfaceArea();

            if (surfaceArea < 1000)
            {
                if (RushOrder == 3)
                {
                    price = RushPrices[0];

                }
                else if (RushOrder == 5)
                {
                    price = RushPrices[1];
                }
                else if (RushOrder == 7)
                {
                    price = RushPrices[2];
                }
            }

            else if (surfaceArea > 1000 && surfaceArea < 2000)
            {
                if (RushOrder == 3)
                {
                    price = RushPrices[3];
                }
                else if (RushOrder == 5)
                {
                    price = RushPrices[4];
                }
                else if (RushOrder == 7)
                {
                    price = RushPrices[5];
                }
            }

            else
            {
                if (RushOrder == 3)
                {
                    price = RushPrices[6];
                }
                else if (RushOrder == 5)
                {
                    price = RushPrices[7];
                }
                else if (RushOrder == 7)
                {
                    price = RushPrices[8];
                }
            }

            return price;
        }

        public double getTotalCost()
        {
           return BASEPRICE + getSurfaceAreaCost() + getDrawerCost() + getSurfaceMaterialCost() + getRushOrderPrice();
        }

    }
}