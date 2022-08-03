using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.Seed;

public class BookAuthorSeed:IEntityTypeConfiguration<BookAuthor>
{
    public void Configure(EntityTypeBuilder<BookAuthor> builder)
    {
        builder.HasData(
            new BookAuthor
            {
                BookAuthorId = 1,
                AuthorId = 1,
                BookId = 1,
            },
            new BookAuthor
            {
                BookAuthorId = 2,
                AuthorId = 1,
                BookId = 2,
            },
            new BookAuthor
            {
                BookAuthorId = 3,
                AuthorId = 1,
                BookId = 3,
            },
            new BookAuthor
            {
                BookAuthorId = 4,
                AuthorId = 2,
                BookId = 1,
            },
            new BookAuthor
            {
                BookAuthorId = 5,
                AuthorId = 2,
                BookId = 4,
            },
            new BookAuthor
            {
                BookAuthorId = 6,
                AuthorId = 2,
                BookId = 5,
            },
            new BookAuthor
            {
                BookAuthorId = 7,
                AuthorId = 3,
                BookId = 5,
            },
            new BookAuthor
            {
                BookAuthorId = 8,
                AuthorId = 3,
                BookId = 6,
            },
            new BookAuthor
            {
                BookAuthorId = 9,
                AuthorId = 4,
                BookId = 7,
            },
            new BookAuthor
            {
                BookAuthorId = 10,
                AuthorId = 5,
                BookId = 8,
            },
            new BookAuthor
            {
                BookAuthorId = 11,
                AuthorId = 6,
                BookId = 9,
            },
            new BookAuthor
            {
                BookAuthorId = 12,
                AuthorId = 7,
                BookId = 10,
            }
            );
    }
}