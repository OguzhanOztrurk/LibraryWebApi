using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.BookTypes.Commands;

public class DeleteBookTypeCommand:IRequest<IResponse>
{
    public int BookId { get; set; }
    public int TypeId { get; set; }
    public class DeleteBookTypeCommandHandler:IRequestHandler<DeleteBookTypeCommand,IResponse>
    {
        private readonly IBookTypeRepository _bookTypeRepository;

        public DeleteBookTypeCommandHandler(IBookTypeRepository bookTypeRepository)
        {
            _bookTypeRepository = bookTypeRepository;
        }

        public async Task<IResponse> Handle(DeleteBookTypeCommand request, CancellationToken cancellationToken)
        {
            var bookType = await _bookTypeRepository
                    .GetAsync(x => x.BookId == request.BookId && x.TypeId == request.TypeId);
            _bookTypeRepository.Delete(bookType);
            await _bookTypeRepository.SaveChangesAsync();
            return new Response<BookType>(bookType);
        }
    }
}