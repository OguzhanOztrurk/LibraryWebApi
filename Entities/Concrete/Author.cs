using Entities.Base;

namespace Entities.Concrete;

public class Author:IEntity
{
    #region Primary Key

    public int AuthorId { get; set; }

    #endregion

    #region Columns

    public string Name { get; set; }
    public string Surname { get; set; }
    public string YearOfBirth { get; set; }
    public string Life { get; set; }

    #endregion

    #region Foreign Key

    public ICollection<BookAuthor> BookAuthors { get; set; }

    #endregion
}