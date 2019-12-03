namespace Contract.Data.Config
{
    using Microsoft.EntityFrameworkCore;
    using Contract.Core.Contract;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ContractConfig : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.ContractCode)
                .IsRequired();

            builder
                .HasOne(x => x.ContractData)
                .WithOne(o => o.Contract)
                .HasForeignKey<ContractData>(x => x.ContractId);
        }
    }
}
