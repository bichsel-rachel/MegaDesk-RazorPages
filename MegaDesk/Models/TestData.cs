using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MegaDesk.Data;

namespace MegaDesk.Models
{
    public class TestData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MegaDeskContext(
                    serviceProvider.GetRequiredService<DbContextOptions<MegaDeskContext>>())) 
                {

                    // If the database already has 1 or more records, skipping seeding the DB
                    if (context.Order.Any())
                    {
                        return;
                    }

                // If it is empty, then lets add in some orders that we can play with
                context.Order.AddRange(
                    new Order
                    {
                        FirstName = "Floor",
                        LastName = "Jansen",
                        Width = 35,
                        Depth = 48,
                        Drawers = 5,
                        SurfaceMaterial = "Oak",
                        RushOrder = 3,
                        QuoteTotal = 1400,
                        DateAdded = DateTime.Parse("2020-1-05")
                    },

                    new Order
                    {
                        FirstName = "Gavin",
                        LastName = "Rossdale",
                        Width = 40,
                        Depth = 25,
                        Drawers = 1,
                        SurfaceMaterial = "Veneer",
                        RushOrder = 5,
                        QuoteTotal = 435,
                        DateAdded = DateTime.Parse("2020-1-07")
                    },

                    new Order
                    {
                        FirstName = "Billy",
                        LastName = "Corgan",
                        Width = 25,
                        Depth = 13,
                        Drawers = 7,
                        SurfaceMaterial = "Pine",
                        RushOrder = 14,
                        QuoteTotal = 600,
                        DateAdded = DateTime.Parse("2020-1-10")
                    },

                    new Order
                    {
                        FirstName = "James",
                        LastName = "Hetfield",
                        Width = 30,
                        Depth = 40,
                        Drawers = 7,
                        SurfaceMaterial = "Laminate",
                        RushOrder = 3,
                        QuoteTotal = 920,
                        DateAdded = DateTime.Parse("2020-1-15")
                    },

                    new Order
                    {
                        FirstName = "Robert",
                        LastName = "Plant",
                        Width = 80,
                        Depth = 35,
                        Drawers = 2,
                        SurfaceMaterial = "Rosewood",
                        RushOrder = 5,
                        QuoteTotal = 2460,
                        DateAdded = DateTime.Parse("2020-1-25")
                    },

                    new Order
                    {
                        FirstName = "Gwen",
                        LastName = "Stefani",
                        Width = 35,
                        Depth = 41,
                        Drawers = 5,
                        SurfaceMaterial = "Veneer",
                        RushOrder = 3,
                        QuoteTotal = 1080,
                        DateAdded = DateTime.Parse("2020-2-05")
                    }


                    ) ;

                context.SaveChanges();
                }
        }
    }
}
