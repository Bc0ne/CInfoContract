namespace Contract.API
{
    using System;
    using Autofac;
    using Contract.API.Bootstraper;
    using Contract.API.Filters;
    using Contract.Data;
    using Contract.Data.Context;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Swashbuckle.AspNetCore.Swagger;

    public class Startup
    {
        private const string SqlServerDb = "SqlServer";
        private const string PostgresDb = "Postgres";
        private const string AllowedSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            HostingEnvironment = hostingEnvironment;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment HostingEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var databaseConfig = (Configuration.GetValue<string>("Database") ?? SqlServerDb);
            var database = databaseConfig.Equals(SqlServerDb, StringComparison.OrdinalIgnoreCase) ?
                SupportedDatabase.SqlServer : SupportedDatabase.Postgres;
            var connection = Configuration.GetConnectionString("ContractConnectionString");
            services.AddDbContext<ContractDbContext>(options =>
            options.UseDatabase(database, connection));

            services.AddCors(options =>
            {
                options.AddPolicy(AllowedSpecificOrigins,
                builder =>
                {
                    builder
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
                });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Contract", Version = "v1" });
            });

            services.AddMvc(options =>
            {
                options.Filters.Add(new ExceptionFilter());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var contextService = serviceScope.ServiceProvider.GetService<ContractDbContext>();
                if (contextService.AllMigrationsApplied())
                {
                    contextService.EnsureMigrated();
                }
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
            AutoMapperConfig.Initialize();
        }

        public void ConfigureContainer(ContainerBuilder builder) =>
           builder.RegisterModule(new DependencyResolver(HostingEnvironment));
    }
}
