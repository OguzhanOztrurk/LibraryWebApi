using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.Seed;

public class BookSeed:IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasData(
            new Book
            {
                BookId = 1,
                BookName = "Küçükler",
                IsbnId = 123456,
                NumberOfPages = "365",
                BookSummary = "Güzel bir kitap"
            },
            new Book
            {
                BookId = 2,
                BookName = "Küçükler",
                IsbnId = 126523,
                NumberOfPages = "365",
                BookSummary = "Güzel bir kitap"
            },
            new Book
            {
                BookId = 3,
                BookName = "Küçükler",
                IsbnId = 789653,
                NumberOfPages = "365",
                BookSummary = "Güzel bir kitap"
            },
            new Book
            {
                BookId = 4,
                BookName = "Küçükler",
                IsbnId = 986547,
                NumberOfPages = "365",
                BookSummary = "Güzel bir kitap"
            },
            new Book
            {
                BookId = 5,
                BookName = "Küçükler",
                IsbnId = 120365,
                NumberOfPages = "365",
                BookSummary = "Güzel bir kitap"
            },
            new Book
            {
                BookId = 6,
                BookName = "Küçükler",
                IsbnId = 986325,
                NumberOfPages = "365",
                BookSummary = "Güzel bir kitap"
            },
            new Book
            {
                BookId = 7,
                BookName = "Küçükler",
                IsbnId = 456378,
                NumberOfPages = "365",
                BookSummary = "Güzel bir kitap"
            },
            new Book
            {
                BookId = 8,
                BookName = "Küçükler",
                IsbnId = 986514,
                NumberOfPages = "365",
                BookSummary = "Güzel bir kitap"
            },
            new Book
            {
                BookId = 9,
                BookName = "Küçükler",
                IsbnId = 203654,
                NumberOfPages = "365",
                BookSummary = "Güzel bir kitap"
            },
            new Book
            {
                BookId = 10,
                BookName = "Küçükler",
                IsbnId = 745822,
                NumberOfPages = "365",
                BookSummary = "Güzel bir kitap"
            }
            );
    }
}