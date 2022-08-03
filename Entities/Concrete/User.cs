using Entities.Base;

namespace Entities.Concrete;

public partial class User:IEntity
{
    #region Primary Key

    public int Id { get; set; }

    #endregion

    #region Columns

    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string SurName { get; set; }
    public string RefreshToken { get; set; }
    public DateTime? RefreshTokenEndDate { get; set; }

    #endregion
}