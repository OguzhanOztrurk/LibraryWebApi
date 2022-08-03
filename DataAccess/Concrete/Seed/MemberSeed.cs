using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.Seed;

public class MemberSeed:IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.HasData(
            new Member
            {
                MemberId = 1,
                Name = "Ahmet",
                Lastname = "Revi",
                Address = "Trabzon",
                isActive = true
            },
            new Member
            {
                MemberId = 2,
                Name = "Cemil",
                Lastname = "Korkmaz",
                Address = "Trabzon",
                isActive = true
            },
            new Member
            {
                MemberId = 3,
                Name = "Ahmet",
                Lastname = "Salihoğlu",
                Address = "Trabzon",
                isActive = true
            },
            new Member
            {
                MemberId = 4,
                Name = "Serkan",
                Lastname = "Ağaoğlu",
                Address = "Trabzon",
                isActive = true
            },
            new Member
            {
                MemberId = 5,
                Name = "Zeynep",
                Lastname = "Durak",
                Address = "Trabzon",
                isActive = true
            },
            new Member
            {
                MemberId = 6,
                Name = "Özgür",
                Lastname = "Pınar",
                Address = "Trabzon",
                isActive = true
            },
            new Member
            {
                MemberId = 7,
                Name = "Cemile",
                Lastname = "Olgun",
                Address = "Trabzon",
                isActive = true
            },
            new Member
            {
                MemberId = 8,
                Name = "Mehmet",
                Lastname = "Civelek",
                Address = "Trabzon",
                isActive = true
            },
            new Member
            {
                MemberId = 9,
                Name = "Dursun",
                Lastname = "Akkaya",
                Address = "Trabzon",
                isActive = true
            },
            new Member
            {
                MemberId = 10,
                Name = "Fazlı",
                Lastname = "Kurumlu",
                Address = "Trabzon",
                isActive = true
            }
            );
    }
}