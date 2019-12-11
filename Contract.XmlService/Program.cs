namespace Contract.XmlService
{
    using Contract.Core.Contract;
    using Contract.Data;
    using Contract.Data.Context;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using XmlService.Services;
    using Contract.Data.Repositories;
    using Microsoft.Extensions.Configuration;
    using System.IO;

    public class Program
    {
        private const string ConnectionString =
            "Data Source=.;Initial Catalog=ContractDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=false;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        static void Main(string[] args)
        {
            var configuration = Configure();

            var services = ConfigureServices(configuration);

            var serviceProvider = services.BuildServiceProvider();

            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var contextService = serviceScope.ServiceProvider.GetService<ContractDbContext>();
                if (contextService.AllMigrationsApplied())
                {
                    contextService.EnsureMigrated();
                }
            }

            serviceProvider.GetService<XmlService>().Validate();
        }

        private static IServiceCollection ConfigureServices(IConfiguration configuration)
        {
            IServiceCollection services = new ServiceCollection();

            services.AddDbContext<ContractDbContext>(options =>
            options.UseDatabase(SupportedDatabase.SqlServer, ConnectionString));

            services.AddSingleton<IContractRepository, ContractRepository>();

            var config = new XmlConfig();
            configuration.GetSection("XmlConfiguration").Bind(config);

            services.AddSingleton(config);

            // Register our application entry point
            services.AddSingleton<XmlService>();
            return services;
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
