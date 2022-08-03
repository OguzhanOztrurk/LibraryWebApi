using DataAccess.Concrete.Enum;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.Seed;

public class OnloanSeed:IEntityTypeConfiguration<Onloan>
{
    public void Configure(EntityTypeBuilder<Onloan> builder)
    {
        builder.HasData(
            new Onloan
            {
                OnloanId = 1,
                BookId = 1,
                MemberId = 1,
                LendingDate = DateTime.Now,
                DeliveryTime = 15,
                StateEnum = StateEnum.NotDelivered
            },
        new Onloan
            {
                OnloanId = 2,
                BookId = 2,
                MemberId = 2,
                LendingDate = DateTime.Now,
                DeliveryTime = 15,
                StateEnum = StateEnum.NotDelivered
            },
        new Onloan
            {
                OnloanId = 3,
                BookId = 3,
                MemberId = 3,
                LendingDate = DateTime.Now,
                DeliveryTime = 15,
                StateEnum = StateEnum.NotDelivered
            },
        new Onloan
            {
                OnloanId = 4,
                BookId = 4,
                MemberId = 4,
                LendingDate = DateTime.Now,
                DeliveryTime = 15,
                StateEnum = StateEnum.NotDelivered
            },
        new Onloan
            {
                OnloanId = 5,
                BookId = 5,
                MemberId = 5,
                LendingDate = DateTime.Now,
                DeliveryTime = 15,
                StateEnum = StateEnum.NotDelivered
            },
        new Onloan
            {
                OnloanId = 6,
                BookId = 6,
                MemberId = 8,
                LendingDate = DateTime.Now,
                DeliveryTime = 15,
                StateEnum = StateEnum.NotDelivered
            }
            );
    }
}