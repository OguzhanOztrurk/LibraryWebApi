using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dto;

namespace DataAccess.Abstract;

public interface IMemberRepository:IEntityRepository<Member>
{
    Task<MemberDTO> GetMember(int memberId);
    Task<List<BookDTO>> GetBooks(int memberId);
    Task<MemberOfBooksDTO> GetMemberOfBooks(int memberId);
}