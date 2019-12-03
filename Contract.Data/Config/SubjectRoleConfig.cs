namespace Contract.Data.Config
{
    using Contract.Core.Individual;
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
                .HasOne(x => x.Contract)
                .WithMany(m => m.SubjectRoles)
                .HasForeignKey(x => x.ContractId);
        }
    }
}
