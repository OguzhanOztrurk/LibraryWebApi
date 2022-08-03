using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.BookTypes.Queries;

public class GetBookTypesQuery:IRequest<IResponse>
{
    public class GetBookTypesQueryHandler:IRequestHandler<GetBookTypesQuery,IResponse>
    {
        private readonly IBookTypeRepository _bookTypeRepository;

        public GetBookTypesQueryHandler(IBookTypeRepository bookTypeRepository)
        {
            _bookTypeRepository = bookTypeRepository;
        }

        public async Task<IResponse> Handle(GetBookTypesQuery request, CancellationToken cancellationToken)
        {
            var bookTypes = await _bookTypeRepository.GetListAsync();
            return new Response<IEnumerable<BookType>>(bookTypes);
        }
    }
}