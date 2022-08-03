using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.Books.Queries;

public class GetBookQuery:IRequest<IResponse>
{
    public int BookId { get; set; }
    public class GetBookQueryHandler:IRequestHandler<GetBookQuery,IResponse>
    {
        private readonly IBookRepository _bookRepository;

        public GetBookQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IResponse> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetAsync(x => x.BookId == request.BookId);
            return new Response<Book>(book);
        }
    }
}