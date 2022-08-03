using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.Repository;

public class BookAuthorRepository:EfEntityRepositoryBase<BookAuthor,AppDbContext>,IBookAuthorRepository
{
    public BookAuthorRepository(AppDbContext context) : base(context)
    {
    }
}