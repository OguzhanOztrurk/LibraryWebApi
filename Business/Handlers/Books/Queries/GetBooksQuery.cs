using Core.Wrappers;
using DataAccess.Abstract;
using MediatR;
using Entities.Concrete;

namespace Business.Handlers.Books.Queries;

public class GetBooksQuery:IRequest<IResponse>
{
    public class GetBooksQueryHandler:IRequestHandler<GetBooksQuery, IResponse>
    {
        private readonly IBookRepository _bookRepository;

        public GetBooksQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IResponse> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetListAsync();
            return new Response<IEnumerable<Book>>(books);
        }
    }
}