using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.Configurations;

public class BookTypeConfiguration:IEntityTypeConfiguration<Entities.Concrete.BookType>
{
    public void Configure(EntityTypeBuilder<Entities.Concrete.BookType> builder)
    {
        #region Primary Key

        builder.HasKey(x => new
        {
            x.BookId,
            x.TypeId
        });

        #endregion

        #region Foreign Key

        builder
            .HasOne(x => x.Type)
            .WithMany(x => x.BookTypes)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(x => x.Book)
            .WithMany(x => x.BookTypes)
            .OnDelete(DeleteBehavior.Restrict);

        #endregion

    }
}