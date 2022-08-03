using Entities.Base;

namespace Entities.Concrete;

public class Type:IEntity
{
    #region Primary Key

    public int TypeId { get; set; }

    #endregion

    #region Columns

    public string TypeExplanation { get; set; }

    #endregion

    #region Foreign Key

    public ICollection<BookType> BookTypes { get; set; }

    #endregion
}