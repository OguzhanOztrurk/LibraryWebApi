using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.Members.Commands;

public class CreateMemberCommand:IRequest<IResponse>
{
    public string Name { get; set; }
    public string Lastname { get; set; }
    public string Address { get; set; }
    public bool isActive { get; set; }
    public class CreateMemberCommandHandler:IRequestHandler<CreateMemberCommand, IResponse>
    {
        private readonly IMemberRepository _memberRepository;
        

        public CreateMemberCommandHandler(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
            
        }

        public async Task<IResponse> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
        {

            
            Member addedMember = new Member
            {
                Name = request.Name,
                Lastname = request.Lastname,
                Address = request.Address,
                isActive = request.isActive
            };
            _memberRepository.Add(addedMember);
            await _memberRepository.SaveChangesAsync();
            return new Response<Member>(addedMember);
        }
    }
}