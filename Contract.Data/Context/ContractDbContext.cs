namespace Contract.Data.Context
{
    using Microsoft.EntityFrameworkCore;
    using Contract.Core.Contract;
    using Contract.Data.Config;
    using Contract.Core.Individual;
    using Contract.Core.SubjectRole;

    public class ContractDbContext: DbContext
    {
        public ContractDbContext(DbContextOptions<ContractDbContext> options)
            :base(options)
        {
        }

        public DbSet<Contract> Contracts { get; set; }
        public DbSet<ContractData> ContractsData { get; set; }
        public DbSet<Individual> Individuals { get; set; }
        public DbSet<SubjectRole> SubjectRole { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContractConfig())
                .ApplyConfiguration(new ContractDataConfig())
                .ApplyConfiguration(new IndividualConfig())
                .ApplyConfiguration(new SubjectRoleConfig());
        }
    }
}
