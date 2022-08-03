using DataAccess.Concrete.EntityFramework;
using Entities.Dto;
using Type = Entities.Concrete.Type;

namespace DataAccess.Abstract;

public interface ITypeRepository:IEntityRepository<Type>
{
    Task<TypeDTO> GetType(int typeId);
    Task<List<BookDTO>> GetBooks(int typeId);
    Task<TypeWithBookDTO> GetTypeWithBook(int typeId);
}