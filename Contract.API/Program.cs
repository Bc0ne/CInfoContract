﻿namespace Contract.API
{

    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Autofac.Extensions.DependencyInjection;

    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureServices(services => services.AddAutofac())
                .Build();
    }
}
