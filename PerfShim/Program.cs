using ApiShim.Shim;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services;
using ServviceInterfaces;

namespace ApiShim
{
    class Program
    {
        static void Main()
        {
            using var host = CreateHostBuilder().Build();
            using var serviceScope = host.Services.CreateScope();
            var app = serviceScope.ServiceProvider.GetService<IApp>();
            app?.Run();
        }

        static IHostBuilder CreateHostBuilder()
        {
            var host = Host.CreateDefaultBuilder();

            // default
            host.ConfigureServices((_, services) =>
                services.AddSingleton<IApp, App>()
                        .AddTransient(sp => PerfShimFactory.CreateProxy<ISomeService1, SomeService1>())
                        .AddTransient<ISomeService2, SomeService2>()
            );

            return host;
        }

    }
}
