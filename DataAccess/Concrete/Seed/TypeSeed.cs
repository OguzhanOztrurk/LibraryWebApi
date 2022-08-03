using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Type = Entities.Concrete.Type;

namespace DataAccess.Concrete.Seed;

public class TypeSeed:IEntityTypeConfiguration<Type>
{
    public void Configure(EntityTypeBuilder<Type> builder)
    {
        builder.HasData(
            new Type
            {
                TypeId = 1,
                TypeExplanation = "Polisiye",
            },
            new Type
            {
                TypeId = 2,
                TypeExplanation = "Roman",
            },
            new Type
            {
                TypeId = 3,
                TypeExplanation = "Masal",
            },
            new Type
            {
                TypeId = 4,
                TypeExplanation = "Hikaye",
            },
            new Type
            {
                TypeId = 5,
                TypeExplanation = "Tarih",
            },
            new Type
            {
                TypeId = 6,
                TypeExplanation = "Ekonomi",
            },
            new Type
            {
                TypeId = 7,
                TypeExplanation = "Genel Kültür",
            },
            new Type
            {
                TypeId = 8,
                TypeExplanation = "Şiir",
            },
            new Type
            {
                TypeId = 9,
                TypeExplanation = "Makale",
            },
            new Type
            {
                TypeId = 10,
                TypeExplanation = "Sağlık",
            }
            );
    }
}