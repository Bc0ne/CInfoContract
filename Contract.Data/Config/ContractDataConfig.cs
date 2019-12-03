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
        }
    }
}
