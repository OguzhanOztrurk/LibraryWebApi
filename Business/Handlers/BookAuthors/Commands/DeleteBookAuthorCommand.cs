using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.BookAuthors.Commands;

public class DeleteBookAuthorCommand:IRequest<IResponse>
{
    public int BookAuthorId { get; set; }
    
    public class DeleteBookAuthorCommandHandler:IRequestHandler<DeleteBookAuthorCommand,IResponse>
    {
        private readonly IBookAuthorRepository _bookAuthorRepository;

        public DeleteBookAuthorCommandHandler(IBookAuthorRepository bookAuthorRepository)
        {
            _bookAuthorRepository = bookAuthorRepository;
        }

        public async Task<IResponse> Handle(DeleteBookAuthorCommand request, CancellationToken cancellationToken)
        {
            var bookAuthor = await _bookAuthorRepository.GetAsync(x => x.BookAuthorId == request.BookAuthorId);
            _bookAuthorRepository.Delete(bookAuthor);
            await _bookAuthorRepository.SaveChangesAsync();
            return new Response<BookAuthor>(bookAuthor);
        }
    }
}