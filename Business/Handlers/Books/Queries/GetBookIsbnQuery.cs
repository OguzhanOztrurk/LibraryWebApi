using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.Books.Queries;

public class GetBookIsbnQuery:IRequest<IResponse>
{
    public int IsbnId { get; set; }
    public class GetBookIsbnQueryHandler:IRequestHandler<GetBookIsbnQuery,IResponse>
    {
        private readonly IBookRepository _bookRepository;

        public GetBookIsbnQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IResponse> Handle(GetBookIsbnQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetAsync(x => x.IsbnId == request.IsbnId);
            return new Response<Book>(book);
        }
    }
}