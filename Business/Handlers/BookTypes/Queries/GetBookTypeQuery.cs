using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.BookTypes.Queries;

public class GetBookTypeQuery:IRequest<IResponse>
{
    public int BookId { get; set; }
    public int TypeId { get; set; }
    public class GetBookTypeQueryHandler:IRequestHandler<GetBookTypeQuery,IResponse>
    {
        private readonly IBookTypeRepository _bookTypeRepository;

        public GetBookTypeQueryHandler(IBookTypeRepository bookTypeRepository)
        {
            _bookTypeRepository = bookTypeRepository;
        }

        public async Task<IResponse> Handle(GetBookTypeQuery request, CancellationToken cancellationToken)
        {
            var bookType = await _bookTypeRepository
                    .GetAsync(x => x.BookId == request.BookId && x.TypeId == request.TypeId);
            return new Response<BookType>(bookType);
        }
    }
}