using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.Authors.Queries;

public class GetAuthorQuery:IRequest<IResponse>
{
    public int AuthorId { get; set; }
    public class GetAuthorQueryHandler:IRequestHandler<GetAuthorQuery,IResponse>
    {
        private readonly IAuthorRepository _authorRepository;

        public GetAuthorQueryHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<IResponse> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.GetAsync(x => x.AuthorId == request.AuthorId);
            return new Response<Author>(author);
        }
    }
}