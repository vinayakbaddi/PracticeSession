using ApplicationCore.Interface;
using ApplicationInfrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace MainConsole
{
    class Program
    {
        static ServiceProvider serviceProvider;
        static void DI()
        {
            //setup our DI
            var serviceCollection = new ServiceCollection()
                .AddLogging()
                .AddSingleton<ICleanService, CleanService>()
                .AddSingleton<IDemoService, DemoService>();

            serviceProvider = serviceCollection.BuildServiceProvider();
                

            //configure console logging
            //serviceProvider
            //    .GetService<ILoggerFactory>()

            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();
            logger.LogDebug("Starting application");

            
        }
        static void Main(string[] args)
        {
            DI();

            Consume();
        }

        static void Consume()
        {
            Console.WriteLine("Start");

            var demoService = serviceProvider.GetService<IDemoService>();
            demoService.Serve();
        }
    }
}
