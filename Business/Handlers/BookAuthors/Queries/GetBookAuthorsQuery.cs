using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.BookAuthors.Queries;

public class GetBookAuthorsQuery:IRequest<IResponse>
{
    public class GetBookAuthorsQueryHandler:IRequestHandler<GetBookAuthorsQuery,IResponse>
    {
        private readonly IBookAuthorRepository _bookAuthorRepository;

        public GetBookAuthorsQueryHandler(IBookAuthorRepository bookAuthorRepository)
        {
            _bookAuthorRepository = bookAuthorRepository;
        }

        public async Task<IResponse> Handle(GetBookAuthorsQuery request, CancellationToken cancellationToken)
        {
            var bookAuthors = await _bookAuthorRepository.GetListAsync();
            return new Response<IEnumerable<BookAuthor>>(bookAuthors);
        }
    }
}