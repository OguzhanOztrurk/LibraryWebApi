using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.Authors.Commands;

public class CreateAuthorCommand:IRequest<IResponse>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string YearOfBirth { get; set; }
    public string Life { get; set; }
    public class CreateAuthorCommandHandler:IRequestHandler<CreateAuthorCommand,IResponse>
    {
        private readonly IAuthorRepository _authorRepository;

        public CreateAuthorCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<IResponse> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            Author addedAuthor = new Author
            {
                Name = request.Name,
                Surname = request.Surname,
                YearOfBirth = request.YearOfBirth,
                Life = request.Life
            };
            _authorRepository.Add(addedAuthor);
            await _authorRepository.SaveChangesAsync();
            return new Response<Author>(addedAuthor);
        }
    }
}