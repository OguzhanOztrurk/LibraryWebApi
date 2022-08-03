using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.Authors.Commands;

public class UpdateAuthorCommand:IRequest<IResponse>
{
    public int AuthorId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string YearOfBirth { get; set; }
    public string Life { get; set; }
    public class UpdateAuthorCommandHandler:IRequestHandler<UpdateAuthorCommand,IResponse>
    {
        private readonly IAuthorRepository _authorRepository;

        public UpdateAuthorCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<IResponse> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var authorUpdate = _authorRepository.Get(x => x.AuthorId == request.AuthorId);
            authorUpdate.Name = request.Name;
            authorUpdate.Surname = request.Surname;
            authorUpdate.YearOfBirth = request.YearOfBirth;
            authorUpdate.Life = request.Life;
            _authorRepository.Update(authorUpdate);
            await _authorRepository.SaveChangesAsync();
            return new Response<Author>(authorUpdate);
        }
    }
}