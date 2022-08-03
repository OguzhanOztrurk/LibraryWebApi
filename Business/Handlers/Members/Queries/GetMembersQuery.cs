using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.Members.Queries;

public class GetMembersQuery:IRequest<IResponse>
{
    public class GetMembersQueryHandler:IRequestHandler<GetMembersQuery,IResponse>
    {
        private readonly IMemberRepository _memberRepository;

        public GetMembersQueryHandler(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<IResponse> Handle(GetMembersQuery request, CancellationToken cancellationToken)
        {
            var members = await _memberRepository.GetListAsync();
            return new Response<IEnumerable<Member>>(members);
        }
    }
}