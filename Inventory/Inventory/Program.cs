using Inventory.Infrastructure.Entities;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Inventory
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var host = CreateWebHostBuilder(args).Build();
                using (var scope = host.Services.CreateScope())
                {
                    //et the instance of InventoryContext in our services layer
                    var services = scope.ServiceProvider;
                    var context = services.GetRequiredService<InventoryContext>();

                    //    Call the DataGenerator to create sample data
                    DummyDataGen.DBInitialiser.Initialize(services);

                }

                host.Run();
            }
            catch(Exception ex)
            {
              
            }
        }
       
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
