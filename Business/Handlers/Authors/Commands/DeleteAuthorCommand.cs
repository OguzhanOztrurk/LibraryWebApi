using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.Authors.Commands;

public class DeleteAuthorCommand:IRequest<IResponse>
{
    public int AuthorId { get; set; }
    public class DeleteAuthorCommandHandler:IRequestHandler<DeleteAuthorCommand,IResponse>
    {
        private readonly IAuthorRepository _authorRepository;

        public DeleteAuthorCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<IResponse> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.GetAsync(x => x.AuthorId == request.AuthorId);
            _authorRepository.Delete(author);
            await _authorRepository.SaveChangesAsync();
            return new Response<Author>(author);
        }
    }
}