using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.Onloans.Queries;

public class GetOnloansQuery:IRequest<IResponse>
{
    public class GetOnloansQueryHandler:IRequestHandler<GetOnloansQuery,IResponse>
    {
        private readonly IOnloanRepository _onloanRepository;

        public GetOnloansQueryHandler(IOnloanRepository onloanRepository)
        {
            _onloanRepository = onloanRepository;
        }

        public async Task<IResponse> Handle(GetOnloansQuery request, CancellationToken cancellationToken)
        {
            var onloans = await _onloanRepository.GetListAsync();
            return new Response<IEnumerable<Onloan>>(onloans);
        }
    }
}