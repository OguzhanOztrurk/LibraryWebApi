using Core.Wrappers;
using DataAccess.Abstract;
using MediatR;
using Type = Entities.Concrete.Type;

namespace Business.Handlers.Types.Queries;

public class GetTypeQuery:IRequest<IResponse>
{
    public int TypeId { get; set; }
    public class GetTypeQueryHandler:IRequestHandler<GetTypeQuery,IResponse>
    {
        private readonly ITypeRepository _typeRepository;

        public GetTypeQueryHandler(ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        public async Task<IResponse> Handle(GetTypeQuery request, CancellationToken cancellationToken)
        {
            var type = await _typeRepository.GetAsync(x => x.TypeId == request.TypeId);
            return new Response<Type>(type);
        }
    }
}