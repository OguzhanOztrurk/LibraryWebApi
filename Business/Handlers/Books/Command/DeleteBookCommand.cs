using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.Books.Command;

public class DeleteBookCommand:IRequest<IResponse>
{
    public int BookId { get; set; }
    public class DeleteBookCommandHandler:IRequestHandler<DeleteBookCommand,IResponse>
    {
        private readonly IBookRepository _bookRepository;

        public DeleteBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IResponse> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetAsync(x => x.BookId == request.BookId);
            _bookRepository.Delete(book);
            await _bookRepository.SaveChangesAsync();
            return new Response<Book>(book);
        }
    }
}