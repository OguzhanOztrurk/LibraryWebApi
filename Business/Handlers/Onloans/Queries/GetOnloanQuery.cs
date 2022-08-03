using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.Onloans.Queries;

public class GetOnloanQuery:IRequest<IResponse>
{
    public int OnloanId { get; set; }
    public class GetOnloanQueryHandler:IRequestHandler<GetOnloanQuery,IResponse>
    {
        private readonly IOnloanRepository _onloanRepository;

        public GetOnloanQueryHandler(IOnloanRepository onloanRepository)
        {
            _onloanRepository = onloanRepository;
        }

        public async Task<IResponse> Handle(GetOnloanQuery request, CancellationToken cancellationToken)
        {
            var onloan = await _onloanRepository.GetAsync(x => x.OnloanId == request.OnloanId);
            return new Response<Onloan>(onloan);
        }
    }
}