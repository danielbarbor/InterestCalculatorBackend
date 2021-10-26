using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InterestCalculatorBackend.ApiIntegrationTest.WebAPI
{
    public class WebApiApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup: class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Getting another app settings file only for tests
                services.AddSingleton<IConfiguration>(
                    new ConfigurationBuilder()
                        .AddJsonFile("appsettings.test.json")
                        .Build()
                    );
            });
        }
    }
}