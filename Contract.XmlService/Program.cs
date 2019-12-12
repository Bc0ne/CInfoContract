namespace Contract.XmlService
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Contract.Core.Contract;
    using Contract.Data;
    using Contract.Data.Context;
    using Contract.Data.Repositories;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using XmlService.Services;


    public class Program
    {
        static async Task Main(string[] args)
        {
            var configuration = Configure();

            await ConfigureServicesAsync(configuration, args);
        }

        private static async Task<IHostBuilder> ConfigureServicesAsync(IConfiguration configuration, string[] args)
        {
            var connectionstring = configuration.GetConnectionString("ContractConnectionString");

            // Run with console or service
            var asService = !(Debugger.IsAttached || args.Contains("--console"));

            var builder = new HostBuilder()
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<XmlService>();

                var serviceCollection = services.AddDbContext<ContractDbContext>(options =>
                    options.UseDatabase(SupportedDatabase.SqlServer, connectionstring));

                services.AddSingleton<IContractRepository, ContractRepository>();

                var config = new XmlConfig();
                configuration.GetSection("XmlConfiguration").Bind(config);
                services.AddSingleton(config);

                var serviceProvider = services.BuildServiceProvider();

                using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var contextService = serviceScope.ServiceProvider.GetService<ContractDbContext>();
                    if (contextService.AllMigrationsApplied())
                    {
                        contextService.EnsureMigrated();
                    }
                }
            });

            builder.UseEnvironment(asService ? EnvironmentName.Production :
            EnvironmentName.Development);

            if (asService)
            {
                Console.WriteLine("as Service");
                await builder.RunAsServiceAsync();
            }
            else
            {
                Console.WriteLine("as Console");
                await builder.RunConsoleAsync();
            }

            return builder;
        }

        private static IConfiguration Configure()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }
    }
}
