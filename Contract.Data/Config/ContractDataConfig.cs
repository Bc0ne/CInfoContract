namespace Contract.Data.Config
{
    using Contract.Core.Contract;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ContractDataConfig : IEntityTypeConfiguration<ContractData>
    {
        public void Configure(EntityTypeBuilder<ContractData> builder)
        {
            builder
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder
                .OwnsOne(x => x.OriginalAmount);

            builder
                .OwnsOne(x => x.InstallmentAmount);

            builder
                .OwnsOne(x => x.CurrentBalance,
                cb =>
                {
                    cb.Property(x => x.Value).IsRequired();
                    cb.Property(x => x.Currency).IsRequired();
                });

            builder
                .OwnsOne(x => x.OverdueBalance);
        }
    }
}
