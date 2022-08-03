using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dto;

namespace DataAccess.Abstract;

public interface IBookRepository:IEntityRepository<Book>
{
    Task<BookDTO> GetBook(int bookId);
    Task<List<TypeDTO>> GetTypes(int bookId);
    Task<BookOfTypesDTO> GetBookTypes(int bookId);
}