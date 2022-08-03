using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.BookAuthors.Commands;

public class CreateBookAuthorCommand:IRequest<IResponse>
{
    public int AuthorId { get; set; }
    public int BookId { get; set; }
    public class CreateBookAuthorCommandHandler:IRequestHandler<CreateBookAuthorCommand,IResponse>
    {
        private readonly IBookAuthorRepository _bookAuthorRepository;


        public CreateBookAuthorCommandHandler(IBookAuthorRepository bookAuthorRepository)
        {
            _bookAuthorRepository = bookAuthorRepository;
        }

        public async Task<IResponse> Handle(CreateBookAuthorCommand request, CancellationToken cancellationToken)
        {
            BookAuthor bookAuthor = new BookAuthor
            {
                AuthorId = request.AuthorId,
                BookId = request.BookId
            };
            _bookAuthorRepository.Add(bookAuthor);
            await _bookAuthorRepository.SaveChangesAsync();
            return new Response<BookAuthor>(bookAuthor);
        }
    }
}