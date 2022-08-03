using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.Configurations;

public class OnloanConfiguration:IEntityTypeConfiguration<Onloan>
{
    public void Configure(EntityTypeBuilder<Onloan> builder)
    {
        #region Primary Key

        builder.HasKey(x => x.OnloanId);

        #endregion

        #region Columns

        builder.Property(x => x.BookId).IsRequired();
        builder.Property(x => x.MemberId).IsRequired();
        builder.Property(x => x.LendingDate).IsRequired();
        builder.Property(x => x.DeliveryTime).IsRequired();
        builder.Property(x => x.StateEnum);

        #endregion
    }
}