using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.BookAuthors.Queries;

public class GetBookAuthorQuery:IRequest<IResponse>
{
    public int BookAuthorId { get; set; }
    public class GetBookAuthorQueryHandler:IRequestHandler<GetBookAuthorQuery,IResponse>
    {
        private readonly IBookAuthorRepository _bookAuthorRepository;

        public GetBookAuthorQueryHandler(IBookAuthorRepository bookAuthorRepository)
        {
            _bookAuthorRepository = bookAuthorRepository;
        }

        public async Task<IResponse> Handle(GetBookAuthorQuery request, CancellationToken cancellationToken)
        {
            var bookAuthor = await _bookAuthorRepository.GetAsync(x => x.BookAuthorId == request.BookAuthorId);
            return new Response<BookAuthor>(bookAuthor);
        }
    }
}