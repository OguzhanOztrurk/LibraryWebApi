using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.Dto;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.Repository;

public class MemberRepository:EfEntityRepositoryBase<Member, AppDbContext>,IMemberRepository
{
    public MemberRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<MemberDTO> GetMember(int memberId)
    {
        var result = await Context.Members.Where(x => x.MemberId == memberId)
            .Select(x => new MemberDTO()
            {
                MemberId = x.MemberId,
                Name = x.Name,
                Lastname = x.Lastname,
                Address = x.Address,
                isActive = x.isActive
            }).FirstAsync();
        return result;
    }

    public async Task<List<BookDTO>> GetBooks(int memberId)
    {
        var result = await (from onloan in Context.Onloans
            join book in Context.Books on onloan.BookId equals book.BookId
            where onloan.MemberId == memberId
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

    public async Task<MemberOfBooksDTO> GetMemberOfBooks(int memberId)
    {
        var getMemberInfo =await GetMember(memberId);
        var getBooksInfo =await GetBooks(memberId);

        MemberOfBooksDTO result = new MemberOfBooksDTO();
        result.MemberDto = getMemberInfo;
        result.BookDtos = (List<BookDTO>)getBooksInfo;
        return result;
    }
}