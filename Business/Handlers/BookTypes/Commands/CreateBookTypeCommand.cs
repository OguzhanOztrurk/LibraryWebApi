using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.BookTypes.Commands;

public class CreateBookTypeCommand:IRequest<IResponse>
{
    public int BookId { get; set; }
    public int TypeId { get; set; }
    public class CreateBookTypeCommandHandler:IRequestHandler<CreateBookTypeCommand,IResponse>
    {
        private readonly IBookTypeRepository _bookTypeRepository;

        public CreateBookTypeCommandHandler(IBookTypeRepository bookTypeRepository)
        {
            _bookTypeRepository = bookTypeRepository;
        }

        public async Task<IResponse> Handle(CreateBookTypeCommand request, CancellationToken cancellationToken)
        {
            BookType bookType = new BookType
            {
                BookId = request.BookId,
                TypeId = request.TypeId
            };
            _bookTypeRepository.Add(bookType);
            await _bookTypeRepository.SaveChangesAsync();
            return new Response<BookType>(bookType);
        }
    }
}