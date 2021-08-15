using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaV5.Infrastructure.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var _context = new PruebaV5BDContext(serviceProvider.GetRequiredService<DbContextOptions<PruebaV5BDContext>>()))
            {
                //bool countriesAny = _context.Country.AnyAsync();
                //if ()
                //{

                //}
                _context.Security.AddRange(
                    new Core.Entities.Security { Id=1, Pwd="abcd", User= "alex@b.com", UserName="Alex", Role = "Admin"}
                    );

                _context.Toy.AddRange(
                    new Core.Entities.Toy { Age=5, Company="Matel", Description="Beutiful Doll", Id=1, Name="Barbie", Price= 400},
                    new Core.Entities.Toy { Age = 7, Company = "Hasbro", Description = "Action Man", Id = 3, Name = "Max Stell", Price = 300 }
                    );

                _context.SaveChanges();
            }
        }
    }
}
