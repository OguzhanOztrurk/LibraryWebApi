using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dto;

namespace DataAccess.Abstract;

public interface IAuthorRepository:IEntityRepository<Author>
{
    Task<AuthorDTO> GetAuthorInfo(int authorId);
    Task<List<BookDTO>> GetAuthorBooks(int authorId);
    Task<AuthorOfBooksDTO> GetAuthorOfBooks(int authorId);
}