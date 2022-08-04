using Entities.Base;

namespace Entities.Concrete;

public class UserRole:IEntity
{
    #region Primary Key

    public int Id { get; set; }

    #endregion

    #region Columns

    public int UserID { get; set; }
    public int RoleId { get; set; }

    #endregion

    #region Foreign Key

    public User User { get; set; }
    public Role Role { get; set; }

    #endregion
    
}