using Inventory.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using static Inventory.Infrastructure.Enums.Enumerators;

namespace Inventory.DummyDataGen
{
    public class DBInitialiser
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new InventoryContext(
                serviceProvider.GetRequiredService<DbContextOptions<InventoryContext>>()))
            {
                // Look for any board games.
                if (!context.Categories.Any())
                {
                    SeedCategories(context);
                }
                if (!context.Products.Any())
                {
                    SeedProducts(context);
                }
                context.SaveChanges();
            }
        }
        private static void SeedProducts(InventoryContext context)
        {
            context.Products.AddRange(
                  new Product
                  {
                      ProductId = 10,
                      Name = "Fuji Apple",
                      Description = "Apple varieties",
                      ActiveStateId = ActiveState.Active,
                      CategoryId = 1,
                      UnitPrice = 3.45m
                  },
                    new Product
                    {
                        ProductId = 11,
                        Name = "Pink Lady Apple",
                        Description = "Apple varieties",
                        ActiveStateId = ActiveState.Active,
                        CategoryId = 1,
                        UnitPrice = 4.55m
                    });
        }

        private static void SeedCategories(InventoryContext context)
        {
            context.Categories.AddRange(
                  new Category
                  {
                      CategoryId = 1,
                      Name = "Fruits",
                      Description = "Farm produced fruits",
                      ActiveStateId = ActiveState.Active
                  },
                    new Category
                    {
                        CategoryId = 2,
                        Name = "BadFruits",
                        Description = "Bad fruits being removed",
                        ActiveStateId = ActiveState.Deleted
                    },
                      new Category
                      {
                          CategoryId = 3,
                          Name = "Stationary",
                          Description = "Item queued by service",
                          ActiveStateId = ActiveState.Queued
                      });

        }
    }
}
