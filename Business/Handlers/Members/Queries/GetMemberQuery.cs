using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.Members.Queries;

public class GetMemberQuery:IRequest<IResponse>
{
    public int MemberId { get; set; }
    public class GetMemberQueryHandler:IRequestHandler<GetMemberQuery,IResponse>
    {
        private readonly IMemberRepository _memberRepository;

        public GetMemberQueryHandler(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<IResponse> Handle(GetMemberQuery request, CancellationToken cancellationToken)
        {
            var member = await _memberRepository.GetAsync(x => x.MemberId == request.MemberId);
            return new Response<Member>(member);
        }
    }
}