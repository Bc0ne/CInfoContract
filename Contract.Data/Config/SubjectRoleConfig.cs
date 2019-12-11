namespace Contract.Data.Config
{
    using Contract.Core.SubjectRole;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SubjectRoleConfig : IEntityTypeConfiguration<SubjectRole>
    {
        public void Configure(EntityTypeBuilder<SubjectRole> builder)
        {
            builder
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.CustomerCode)
                .IsRequired();

            builder
                .HasOne(x => x.Contract)
                .WithMany(m => m.SubjectRoles)
                .HasForeignKey(x => x.ContractId);

            builder
                .OwnsOne(x => x.GuranateeAmount);
        }
    }
}
