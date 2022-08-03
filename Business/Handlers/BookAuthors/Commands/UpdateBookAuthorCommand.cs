using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.BookAuthors.Commands;

public class UpdateBookAuthorCommand:IRequest<IResponse>
{
    public int BookAuthorId { get; set; }
    public int AuthorId { get; set; }
    public int BookId { get; set; }
    public class UpdateBookAuthorCommandHandler:IRequestHandler<UpdateBookAuthorCommand,IResponse>
    {
        private readonly IBookAuthorRepository _bookAuthorRepository;

        public UpdateBookAuthorCommandHandler(IBookAuthorRepository bookAuthorRepository)
        {
            _bookAuthorRepository = bookAuthorRepository;
        }

        public async Task<IResponse> Handle(UpdateBookAuthorCommand request, CancellationToken cancellationToken)
        {
            var bookAutherUpdate = _bookAuthorRepository.Get(x => x.BookAuthorId == request.BookAuthorId);
            bookAutherUpdate.AuthorId = request.AuthorId;
            bookAutherUpdate.BookId = request.BookId;
            _bookAuthorRepository.Update(bookAutherUpdate);
            await _bookAuthorRepository.SaveChangesAsync();
            return new Response<BookAuthor>(bookAutherUpdate);
        }
    }
}