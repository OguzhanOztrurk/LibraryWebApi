using Core.Wrappers;
using DataAccess.Abstract;
using MediatR;
using Type = Entities.Concrete.Type;

namespace Business.Handlers.Types.Queries;

public class GetTypesQuery:IRequest<IResponse>
{
    public class GetTypesQueryHandler:IRequestHandler<GetTypesQuery,IResponse>
    {
        private readonly ITypeRepository _typeRepository;

        public GetTypesQueryHandler(ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        public async Task<IResponse> Handle(GetTypesQuery request, CancellationToken cancellationToken)
        {
            var types = await _typeRepository.GetListAsync();
            return new Response<IEnumerable<Type>>(types);
        }
    }
}