using LibraryApi;
using LibraryApi.Services;
using LibraryAPIIntegrationTests;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Testing;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace LibraryApiIntegrationTests
{
    public class WebTestFixture : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Testing");

            builder.ConfigureServices(services => //oh ya I'm gonna use system time every time someone asks for IsystemTime
            {

                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(ISystemTime)); //"I'm expecting theres a class that implements ISystemTime
                if(descriptor != null)//and if there IS
                {
                    services.Remove(descriptor);//Don't use it!
                    services.AddTransient<ISystemTime, TestingSystemTime>();//use this one instead!
                    //what is testingSystemTime? Our own custom SystemTime class for testing that returns hardcoded datatime... of 4/20/69. Dammit Jeff.
                }
                var provider = services
                    .BuildServiceProvider();





                var sp = services.BuildServiceProvider();


                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;

                    var loggerFactory = scopedServices.GetRequiredService<ILoggerFactory>();

                    var logger = scopedServices
                        .GetRequiredService<ILogger<WebTestFixture>>();




                    try
                    {

                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, $"An error occurred seeding the " +
                            "database with test messages. Error: {ex.Message}");
                    }
                }
            });
        }
    }
}