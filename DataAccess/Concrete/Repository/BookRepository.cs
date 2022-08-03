using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.Dto;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.Repository;

public class BookRepository:EfEntityRepositoryBase<Book, AppDbContext>,IBookRepository
{
    public BookRepository(AppDbContext context) : base(context)
    {
    }


    public async Task<BookDTO> GetBook(int bookId)
    {
        var result = await Context.Books.Where(x => x.BookId == bookId)
            .Select(x => new BookDTO()
            {
                BookId = x.BookId,
                BookName = x.BookName,
                BookSummary = x.BookSummary,
                IsbnId = x.IsbnId,
                NumberOfPages = x.NumberOfPages
            }).FirstAsync();
        return result;
    }

    public async Task<List<TypeDTO>> GetTypes(int bookId)
    {
        var result = await (from bookType in Context.BookTypes
            join type in Context.Types on bookType.TypeId equals type.TypeId
            where bookType.BookId == bookId
            select new TypeDTO()
            {
                TypeId = type.TypeId,
                TypeExplanation = type.TypeExplanation
            }).ToListAsync();
        return result;
    }

    public async Task<BookOfTypesDTO> GetBookTypes(int bookId)
    {
        var GetBookInfo =await GetBook(bookId);
        var GetTypesInfo =await GetTypes(bookId);

        BookOfTypesDTO result = new BookOfTypesDTO();
        result.BookDto = GetBookInfo;
        result.TypeDtos = (List<TypeDTO>)GetTypesInfo;
        return result;
    }
}