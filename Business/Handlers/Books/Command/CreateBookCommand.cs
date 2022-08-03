using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.Books.Command;

public class CreateBookCommand:IRequest<IResponse>
{
    public string BookName { get; set; }
    public int IsbnId { get; set; }
    public string NumberOfPages { get; set; }
    public string BookSummary { get; set; }
    public class CreateBookCommandHandler:IRequestHandler<CreateBookCommand,IResponse>
    {
        private readonly IBookRepository _bookRepository;

        public CreateBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IResponse> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            Book addedBook = new Book
            {
                BookName = request.BookName,
                IsbnId = request.IsbnId,
                NumberOfPages = request.NumberOfPages,
                BookSummary = request.BookSummary
            };
            _bookRepository.Add(addedBook);
            await _bookRepository.SaveChangesAsync();
            return new Response<Book>(addedBook);
        }
    }
}