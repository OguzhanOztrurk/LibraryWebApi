using Entities.Base;

namespace Entities.Concrete;

public class Book:IEntity
{
    #region Primary Key

    public int BookId { get; set; }

    #endregion

    #region Columns

    public string BookName { get; set; }
    public int IsbnId { get; set; }
    public string NumberOfPages { get; set; }
    public string BookSummary { get; set; }

    #endregion

    #region Foreign Key

    public ICollection<BookType> BookTypes { get; set; }
    public ICollection<BookAuthor> BookAuthors { get; set; }
    public ICollection<Onloan> Onloans { get; set; }

    #endregion
}