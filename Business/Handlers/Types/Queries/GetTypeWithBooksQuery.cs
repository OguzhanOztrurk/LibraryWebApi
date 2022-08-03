using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Dto;
using MediatR;

namespace Business.Handlers.Types.Queries;

public class GetTypeWithBooksQuery:IRequest<IResponse>
{
    public int TypeId { get; set; }
    public class GetTypeWithBooksQueryHandler:IRequestHandler<GetTypeWithBooksQuery,IResponse>
    {
        private readonly ITypeRepository _typeRepository;

        public GetTypeWithBooksQueryHandler(ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }


        public async Task<IResponse> Handle(GetTypeWithBooksQuery request, CancellationToken cancellationToken)
        {
            var result = await _typeRepository.GetTypeWithBook(request.TypeId);
            return new Response<TypeWithBookDTO>(result);
        }
    }
}