using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.Members.Commands;

public class UpdateMemberCommand:IRequest<IResponse>
{
    public int MemberId { get; set; }
    public string Name { get; set; }
    public string Lastname { get; set; }
    public string Address { get; set; }
    public bool isActive { get; set; }
    
    public class UpdateMemberCommandHandler:IRequestHandler<UpdateMemberCommand,IResponse>
    {
        private readonly IMemberRepository _memberRepository;

        public UpdateMemberCommandHandler(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<IResponse> Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
        {
            var memberUpdate = _memberRepository.Get(x => x.MemberId == request.MemberId);
            memberUpdate.Name = request.Name;
            memberUpdate.Lastname = request.Lastname;
            memberUpdate.Address = request.Address;
            memberUpdate.isActive = request.isActive;
            _memberRepository.Update(memberUpdate);
            await _memberRepository.SaveChangesAsync();
            return new Response<Member>(memberUpdate);
        }
    }
}