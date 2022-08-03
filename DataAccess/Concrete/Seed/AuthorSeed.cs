using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.Seed;

public class AuthorSeed:IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.HasData(
            new Author
            {
                AuthorId = 1,
                Name = "Ahmet",
                Surname = "Hamdi",
                YearOfBirth = "2002",
                Life = "Trabzonda doğdu ilk kitabı"
            },
            new Author
            {
                AuthorId = 2,
                Name = "Samet",
                Surname = "Uslu",
                YearOfBirth = "1987",
                Life = "Trabzonda doğdu ilk kitabı"
            },
            new Author
            {
                AuthorId = 3,
                Name = "Doğan",
                Surname = "Atalar",
                YearOfBirth = "1965",
                Life = "Trabzonda doğdu ilk kitabı"
            },
            new Author
            {
                AuthorId = 4,
                Name = "Cevher",
                Surname = "Küçük",
                YearOfBirth = "1980",
                Life = "Trabzonda doğdu ilk kitabı"
            },
            new Author
            {
                AuthorId = 5,
                Name = "Nafize",
                Surname = "Tezyürek",
                YearOfBirth = "1957",
                Life = "Trabzonda doğdu ilk kitabı"
            },
            new Author
            {
                AuthorId = 6,
                Name = "ceyhan",
                Surname = "Karslıoğlu",
                YearOfBirth = "1993",
                Life = "Trabzonda doğdu ilk kitabı"
            },
            new Author
            {
                AuthorId = 7,
                Name = "Yusuf",
                Surname = "Hacıoğlu",
                YearOfBirth = "1990",
                Life = "Trabzonda doğdu ilk kitabı"
            },
            new Author
            {
                AuthorId = 8,
                Name = "Ahmet",
                Surname = "Fazıl",
                YearOfBirth = "1986",
                Life = "Trabzonda doğdu ilk kitabı"
            },
            new Author
            {
                AuthorId = 9,
                Name = "selçuk",
                Surname = "Bulut",
                YearOfBirth = "1967",
                Life = "Trabzonda doğdu ilk kitabı"
            },
            new Author
            {
                AuthorId = 10,
                Name = "Arda",
                Surname = "Yılmaz",
                YearOfBirth = "1965",
                Life = "Trabzonda doğdu ilk kitabı"
            }
            );
    }
}