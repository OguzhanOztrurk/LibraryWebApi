using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Dto;
using MediatR;

namespace Business.Handlers.Onloans.Queries;

public class GetOnloanOfMemberAndBookQuery:IRequest<IResponse>
{
    public int OnloanId { get; set; }
    public class GetOnloanOfMemberAndBookQueryHandler:IRequestHandler<GetOnloanOfMemberAndBookQuery, IResponse>
    {
        private readonly IOnloanRepository _onloanRepository;

        public GetOnloanOfMemberAndBookQueryHandler(IOnloanRepository onloanRepository)
        {
            _onloanRepository = onloanRepository;
        }

        public async Task<IResponse> Handle(GetOnloanOfMemberAndBookQuery request, CancellationToken cancellationToken)
        {
            var result = await _onloanRepository.GetOnlanOfMemberAndBook(request.OnloanId);
            return new Response<OnloanOfMemberAndBookDTO>(result);
        }
    }
}