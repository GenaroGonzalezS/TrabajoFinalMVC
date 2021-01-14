using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TrabajoFinal.Data;
using System;
using System.Linq;

namespace TrabajoFinal.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new FrutaContexto(
                serviceProvider.GetRequiredService<
                    DbContextOptions<FrutaContexto>>()))
            {
                // Buscar frutas.
                if (context.Fruta.Any())
                {
                    return;   // DB has been seeded
                }

                context.Fruta.AddRange(
                    new Fruta
                    {
                        Nombre = "Banana",
                        Caducidad = DateTime.Parse("2021-1-1"),
                        Color = "Romantic Comedy",
                        Price = 7.99M
                    },

                    new Fruta
                    {
                        Nombre = "Manzana",
                        Caducidad = DateTime.Parse("2021-1-25"),
                        Color = "Rojo",
                        Price = 20.0M
                    },

                    new Fruta
                    {
                        Nombre = "Manzana",
                        Caducidad = DateTime.Parse("2021-1-26"),
                        Color = "Verde",
                        Price = 21.0M
                    },

                    new Fruta
                    {
                        Nombre = "Pera",
                        Caducidad = DateTime.Parse("2021-1-22"),
                        Color = "Verde",
                        Price = 15.0M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
