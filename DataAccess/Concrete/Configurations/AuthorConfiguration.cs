using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.Configurations;

public class AuthorConfiguration:IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        #region Primary Key

        builder.HasKey(x => x.AuthorId);

        #endregion

        #region Columns

        builder.Property(x => x.Name).HasMaxLength(150).IsRequired();
        builder.Property(x => x.Surname).HasMaxLength(150).IsRequired();
        builder.Property(x => x.YearOfBirth).HasMaxLength(4).IsRequired();
        builder.Property(x => x.Life).HasMaxLength(1000).IsRequired();

        #endregion
    }
}