using System.Collections.ObjectModel;
using Entities.Base;

namespace Entities.Concrete;

public class Role:IEntity
{
    #region Primary Key

    public int RoleId { get; set; }

    #endregion

    #region Columns

    public string Name { get; set; }

    #endregion

    #region Foreign Key

    public ICollection<UserRole> UserRoles { get; set; } = new Collection<UserRole>();

    #endregion
    
}