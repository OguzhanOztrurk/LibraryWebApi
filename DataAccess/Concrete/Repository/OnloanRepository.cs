using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using DataAccess.Concrete.Enum;
using Entities.Concrete;
using Entities.Dto;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.Repository;

public class OnloanRepository:EfEntityRepositoryBase<Onloan,AppDbContext>,IOnloanRepository
{
    public OnloanRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<OnloanDto> GetOnloan(int onloanId)
    {
        var result = await Context.Onloans.Where(x => x.OnloanId == onloanId)
            .Select(x => new OnloanDto()
            {
                OnloanId = x.OnloanId,
                BookId = x.BookId,
                MemberId = x.MemberId,
                LendingDate = x.LendingDate,
                DeliveryTime = x.DeliveryTime,
                StateEnum =  x.StateEnum
            }).FirstAsync();
        return result;
    }

    public async Task<MemberDTO> GetMember(int onloanId)
    {
        var result = await (from onloan in Context.Onloans
            join member in Context.Members on onloan.MemberId equals member.MemberId
            where onloan.OnloanId == onloanId
            select new MemberDTO()
            {
                MemberId = member.MemberId,
                Name = member.Name,
                Lastname = member.Lastname,
                Address = member.Address,
                isActive = member.isActive
            }).FirstAsync();
        return result;
    }

    public async Task<BookDTO> GetBook(int onloanId)
    {
        var result = await (from onloan in Context.Onloans
            join book in Context.Books on onloan.BookId equals book.BookId
            where onloan.OnloanId == onloanId
            select new BookDTO()
            {
                BookId = book.BookId,
                BookName = book.BookName,
                BookSummary = book.BookSummary,
                IsbnId = book.IsbnId,
                NumberOfPages = book.NumberOfPages
            }).FirstAsync();
        return result;
    }

    public async Task<OnloanOfMemberAndBookDTO> GetOnlanOfMemberAndBook(int onloanId)
    {
        var GetOnloanInfo = await GetOnloan(onloanId);
        var GetMemberInfo = await GetMember(onloanId);
        var GetBookInfo = await GetBook(onloanId);

        OnloanOfMemberAndBookDTO result = new OnloanOfMemberAndBookDTO();
        result.OnloanDto = GetOnloanInfo;
        result.MemberDto = GetMemberInfo;
        result.BookDto = GetBookInfo;
        return result;
    }

    public void StateControl(int bookId)
    {
        var result = Context.Onloans.Where(x => x.BookId == bookId).Any(x => x.StateEnum == StateEnum.NotDelivered);
            //Any(_ => _.BookId == bookId && _.StateEnum == StateEnum.WasDelivered);

        if (result)
        {
            throw new Exception("Bu kitap henüz teslim edilmemiştir, lütfen işlemlerinizi kontrol ediniz.");
        }
    }
}