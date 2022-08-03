using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using MediatR;

namespace Business.Handlers.Books.Queries;

public class BookOfTypesQuery:IRequest<IResponse>
{
    public int BookId { get; set; }
    public class BookOfTypesQueryHandler:IRequestHandler<BookOfTypesQuery,IResponse>
    {
        private readonly IBookRepository _bookRepository;

        public BookOfTypesQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IResponse> Handle(BookOfTypesQuery request, CancellationToken cancellationToken)
        {
            var result = await _bookRepository.GetBookTypes(request.BookId);
            return new Response<BookOfTypesDTO>(result);
        }
    }
}