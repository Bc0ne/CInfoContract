namespace Contract.Data.Config
{
    using Contract.Core.Individual;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class IndividualConfig : IEntityTypeConfiguration<Individual>
    {
        public void Configure(EntityTypeBuilder<Individual> builder)
        {
            builder
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.CustomerCode)
                .IsRequired();

            builder
                .Property(x => x.Firstname)
                .IsRequired();

            builder
                .Property(x => x.Lastname)
                .IsRequired();

            builder
                .HasOne(x => x.Contract)
                .WithMany(m => m.Individuals)
                .HasForeignKey(x => x.ContractId);
        }
    }
}
