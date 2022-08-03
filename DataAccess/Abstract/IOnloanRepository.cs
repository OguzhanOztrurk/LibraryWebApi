using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dto;

namespace DataAccess.Abstract;

public interface IOnloanRepository:IEntityRepository<Onloan>
{
    Task<OnloanDto> GetOnloan(int onloanId);
    Task<MemberDTO> GetMember(int onloanId);
    Task<BookDTO> GetBook(int onloanId);
    Task<OnloanOfMemberAndBookDTO> GetOnlanOfMemberAndBook(int onloanId);
    void StateControl(int bookId);
}