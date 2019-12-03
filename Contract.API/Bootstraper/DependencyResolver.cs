namespace Contract.API.Bootstraper
{
    using Autofac;
    using Contract.Data.Context;
    using Contract.Data.Repositories;
    using Microsoft.AspNetCore.Hosting;

    public class DependencyResolver : Module
    {
        private readonly IHostingEnvironment _env;

        public DependencyResolver(IHostingEnvironment env)
        {
            _env = env;
        }

        protected override void Load(ContainerBuilder builder)
        {
            LoadModules(builder);
        }

        private void LoadModules(ContainerBuilder builder)
        {
            builder.RegisterType<ContractDbContext>().InstancePerLifetimeScope();
            builder.RegisterType<IndividualRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<SubjectRoleRepository>().AsImplementedInterfaces().InstancePerLifetimeScope();
            
        }
    }
}
