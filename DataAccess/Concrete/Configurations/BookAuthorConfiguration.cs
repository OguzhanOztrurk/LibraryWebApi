using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.Configurations;

public class BookAuthorConfiguration:IEntityTypeConfiguration<BookAuthor>
{
    public void Configure(EntityTypeBuilder<BookAuthor> builder)
    {
        #region Primary Key

        builder.HasKey(x => x.BookAuthorId);

        #endregion

        #region Columns

        builder.Property(x => x.AuthorId).IsRequired();
        builder.Property(x => x.BookId).IsRequired();

        #endregion
        
    }
}