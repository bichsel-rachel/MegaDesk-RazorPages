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
                        // TODO: Change this to "Oak"
                        SurfaceMaterial = 2,
                        RushOrder = 3,
                        DateAdded = DateTime.Parse("2020-1-05")
                    },

                    new Order
                    {
                        FirstName = "Gavin",
                        LastName = "Rossdale",
                        Width = 40,
                        Depth = 25,
                        Drawers = 1,
                        // TODO: Change this to "Veneer"
                        SurfaceMaterial = 3,
                        RushOrder = 5,
                        DateAdded = DateTime.Parse("2020-1-07")
                    },

                    new Order
                    {
                        FirstName = "Billy",
                        LastName = "Corgan",
                        Width = 25,
                        Depth = 13,
                        Drawers = 9,
                        // TODO: Change this to "Pine"
                        SurfaceMaterial = 4,
                        RushOrder = 14,
                        DateAdded = DateTime.Parse("2020-1-10")
                    },

                    new Order
                    {
                        FirstName = "James",
                        LastName = "Hetfield",
                        Width = 30,
                        Depth = 40,
                        Drawers = 7,
                        // TODO: Change this to "Laminate"
                        SurfaceMaterial = 2,
                        RushOrder = 3,
                        DateAdded = DateTime.Parse("2020-1-15")
                    },

                    new Order
                    {
                        FirstName = "Robert",
                        LastName = "Plant",
                        Width = 80,
                        Depth = 35,
                        Drawers = 2,
                        // TODO: Change this to "Rosewood"
                        SurfaceMaterial = 1,
                        RushOrder = 5,
                        DateAdded = DateTime.Parse("2020-1-25")
                    },

                    new Order
                    {
                        FirstName = "Gwen",
                        LastName = "Stefani",
                        Width = 35,
                        Depth = 41,
                        Drawers = 5,
                        // TODO: Change this to "Veneer"
                        SurfaceMaterial = 4,
                        RushOrder = 3,
                        DateAdded = DateTime.Parse("2020-2-05")
                    }


                    ) ;

                context.SaveChanges();
                }
        }
    }
}
