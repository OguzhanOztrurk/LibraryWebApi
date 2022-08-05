using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using Entities.Base;

namespace Entities.Concrete;

public class User:IEntity
{
    #region Primary Key

    public Guid UserID { get; set; }

    #endregion

    #region Columns

    public string UserName { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    [JsonIgnore] public byte[] PasswordHash { get; set; }
    [JsonIgnore] public byte[] PasswordSalt { get; set; }

    #endregion

    #region Foreign Key

    [JsonIgnore] public ICollection<UserRole> UserRoles { get; set; } = new Collection<UserRole>();

    #endregion
}