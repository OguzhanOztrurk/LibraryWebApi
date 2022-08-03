using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Type = Entities.Concrete.Type;

namespace DataAccess.Concrete.Configurations;

public class TypeConfiguration:IEntityTypeConfiguration<Type>
{
    public void Configure(EntityTypeBuilder<Type> builder)
    {
        #region Primary Key

        builder.HasKey(x => x.TypeId);

        #endregion

        #region Columns

        builder.Property(x => x.TypeExplanation).HasMaxLength(150).IsRequired();

        #endregion
    }
}