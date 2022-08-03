using Entities.Base;

namespace Entities.Concrete;

public class BookType:IEntity
{
    #region Primary Key

    public int BookId { get; set; }
    public int TypeId { get; set; }

    #endregion

    

    #region Foreign Key

    public Book Book { get; set; }
    public Type Type { get; set; }

    #endregion
}