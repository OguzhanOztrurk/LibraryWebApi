using Entities.Base;

namespace Entities.Concrete;

public class BookAuthor:IEntity
{
    #region Primary Key

    public int BookAuthorId { get; set; }

    #endregion

    #region Columns

    public int AuthorId { get; set; }
    public int BookId { get; set; }

    #endregion

    #region Foreign Key

    public Book Book { get; set; }
    public Author Author { get; set; }

    #endregion
}