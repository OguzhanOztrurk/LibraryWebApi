using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.Seed;

public class BookTypeSeed:IEntityTypeConfiguration<BookType>
{
    public void Configure(EntityTypeBuilder<BookType> builder)
    {
        builder.HasData(
            new BookType
            {
                BookId = 1,
                TypeId = 1
            },
            new BookType
            {
                BookId = 1,
                TypeId = 2
            },
            new BookType
            {
                BookId = 2,
                TypeId = 1
            },
            new BookType
            {
                BookId = 3,
                TypeId = 4
            },
            new BookType
            {
                BookId = 6,
                TypeId = 8
            },
            new BookType
            {
                BookId = 5,
                TypeId = 3
            },
            new BookType
            {
                BookId = 3,
                TypeId = 5
            },
            new BookType
            {
                BookId = 9,
                TypeId = 2
            },
            new BookType
            {
                BookId = 6,
                TypeId = 1
            },
            new BookType
            {
                BookId = 4,
                TypeId = 1
            }
        );
    }
}