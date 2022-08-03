using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.Members.Commands;

public class DeleteMemberCommand:IRequest<IResponse>
{
    public int MemberId { get; set; }
    public class DeleteMemberCommandHandler:IRequestHandler<DeleteMemberCommand,IResponse>
    {
        private readonly IMemberRepository _memberRepository;

        public DeleteMemberCommandHandler(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<IResponse> Handle(DeleteMemberCommand request, CancellationToken cancellationToken)
        {
            var member = await _memberRepository.GetAsync(x => x.MemberId == request.MemberId);
            _memberRepository.Delete(member);
            await _memberRepository.SaveChangesAsync();
            return new Response<Member>(member);
        }
    }
}