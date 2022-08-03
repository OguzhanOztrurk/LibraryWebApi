using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.Dto;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.Repository;

public class AuthorRepository:EfEntityRepositoryBase<Author,AppDbContext>,IAuthorRepository
{
    public AuthorRepository(AppDbContext context) : base(context)
    {
        
    }


    public async Task<AuthorDTO> GetAuthorInfo(int authorId)
    {
        var result = await Context.Authors.Where(x => x.AuthorId == authorId)
            .Select(x => new AuthorDTO()
            {
                AuthorId = x.AuthorId,
                Name = x.Name,
                Surname = x.Surname,
                YearOfBirth = x.YearOfBirth,
                Life = x.Life

            }).FirstAsync();
        return result;
    }

    public async Task<List<BookDTO>> GetAuthorBooks(int authorId)
    {
        var result = await (from bookAuthor in Context.BookAuthors
            join book in Context.Books on bookAuthor.BookId equals book.BookId
            where bookAuthor.AuthorId==authorId
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

    public async Task<AuthorOfBooksDTO> GetAuthorOfBooks(int authorId)
    {
        var AuthorInfo =await GetAuthorInfo(authorId);
        var BookInfo =await GetAuthorBooks(authorId);

        AuthorOfBooksDTO result = new AuthorOfBooksDTO();
        result.Author = AuthorInfo;
        result.Books = (List<BookDTO>)BookInfo;

        return result;
    }
}