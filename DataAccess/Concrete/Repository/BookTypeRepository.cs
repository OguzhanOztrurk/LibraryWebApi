using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.Repository;

public class BookTypeRepository:EfEntityRepositoryBase<BookType,AppDbContext>,IBookTypeRepository
{
    public BookTypeRepository(AppDbContext context) : base(context)
    {
    }
}