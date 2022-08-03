using Entities.Base;

namespace Entities.Concrete;

public class Member:IEntity
{
    #region Primary Key

    public int MemberId { get; set; }

    #endregion

    #region Columns

    public string Name { get; set; }
    public string Lastname { get; set; }
    public string Address { get; set; }
    public bool isActive { get; set; }

    #endregion

    #region Foreign Key

    public ICollection<Onloan> Onloans { get; set; }

    #endregion
}