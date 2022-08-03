using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Dto;
using MediatR;

namespace Business.Handlers.Members.Queries;

public class GetMemberOfBooksQuery:IRequest<IResponse>
{
    public int MemberId { get; set; }
    public class GetMemberOfBooksQueryHandler:IRequestHandler<GetMemberOfBooksQuery, IResponse>
    {
        private readonly IMemberRepository _memberRepository;

        public GetMemberOfBooksQueryHandler(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<IResponse> Handle(GetMemberOfBooksQuery request, CancellationToken cancellationToken)
        {
            var result = await _memberRepository.GetMemberOfBooks(request.MemberId);
            return new Response<MemberOfBooksDTO>(result);
        }
    }
}