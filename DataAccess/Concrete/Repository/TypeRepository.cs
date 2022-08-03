using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Dto;
using Microsoft.EntityFrameworkCore;
using Type = Entities.Concrete.Type;

namespace DataAccess.Concrete.Repository;

public class TypeRepository:EfEntityRepositoryBase<Type,AppDbContext>,ITypeRepository
{
    public TypeRepository(AppDbContext context) : base(context)
    {
    }


    public async Task<TypeDTO> GetType(int typeId)
    {
        var type = await Context.Types.Where(x => x.TypeId == typeId)
            .Select(x => new TypeDTO()
            {
                TypeId = x.TypeId,
                TypeExplanation = x.TypeExplanation
            }).FirstAsync();
        return type;
    }

    public async Task<List<BookDTO>> GetBooks(int typeId)
    {
        var result = await (from bookType in Context.BookTypes
            join book in Context.Books on bookType.BookId equals book.BookId
            where bookType.TypeId == typeId
            select new BookDTO()
            {
                BookId = book.BookId,
                BookName = book.BookName,
                BookSummary = book.BookSummary,
                IsbnId = book.IsbnId,
                NumberOfPages = book.NumberOfPages
            }).ToListAsync();
        return result;
    }

    public async Task<TypeWithBookDTO> GetTypeWithBook(int typeId)
    {
        var getTypeInfo = await GetType(typeId);
        var getBookInfo =await GetBooks(typeId);

        TypeWithBookDTO result = new TypeWithBookDTO();
        result.TypeDto = getTypeInfo;
        result.BookDtos = (List<BookDTO>)getBookInfo;
        return result;
    }
}