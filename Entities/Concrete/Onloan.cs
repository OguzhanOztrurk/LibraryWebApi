using DataAccess.Concrete.Enum;
using Entities.Base;

namespace Entities.Concrete;

public class Onloan:IEntity
{
    #region Primary Key

    public int OnloanId { get; set; }

    #endregion

    #region Columns

    public int BookId { get; set; }
    public int MemberId { get; set; }
    public DateTime LendingDate { get; set; }
    public int DeliveryTime { get; set; }
    public StateEnum StateEnum { get; set; }

    #endregion

    #region Foreign Key

    public Member Member { get; set; }
    public Book Book { get; set; }

    #endregion
}