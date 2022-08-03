using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.Configurations;

public class BookConfiguration:IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        #region Primary Key

        builder.HasKey(x => x.BookId);

        #endregion

        #region Columns

        builder.Property(x => x.BookName).HasMaxLength(150).IsRequired();
        builder.Property(x => x.IsbnId).HasMaxLength(50).IsRequired();
        builder.Property(x => x.NumberOfPages).HasMaxLength(4);
        builder.Property(x => x.BookSummary).HasMaxLength(1500).IsRequired();

        #endregion
    }
}