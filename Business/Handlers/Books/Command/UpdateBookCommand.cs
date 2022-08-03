using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.Books.Command;

public class UpdateBookCommand:IRequest<IResponse>
{
    public int BookId { get; set; }
    public string BookName { get; set; }
    public int IsbnId { get; set; }
    public string NumberOfPages { get; set; }
    public string BookSummary { get; set; }
    public class UpdateBookCommandHandler:IRequestHandler<UpdateBookCommand,IResponse>
    {
        private readonly IBookRepository _bookRepository;

        public UpdateBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IResponse> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var bookUpdate = _bookRepository.Get(x => x.BookId == request.BookId);
            bookUpdate.BookName = request.BookName;
            bookUpdate.IsbnId = request.IsbnId;
            bookUpdate.NumberOfPages = request.NumberOfPages;
            bookUpdate.BookSummary = request.BookSummary;
            _bookRepository.Update(bookUpdate);
            await _bookRepository.SaveChangesAsync();
            return new Response<Book>(bookUpdate);
        }
    }
}