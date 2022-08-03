using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.Configurations;

public class MemberConfiguration:IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        #region Primary Key

        builder.HasKey(x => x.MemberId);

        #endregion

        #region Columns

        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Lastname).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Address).HasMaxLength(250).IsRequired();
        builder.Property(x => x.isActive);

        #endregion
    }
}