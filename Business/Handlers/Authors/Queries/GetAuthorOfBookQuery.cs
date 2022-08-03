using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Dto;
using MediatR;

namespace Business.Handlers.Authors.Queries;

public class GetAuthorOfBookQuery:IRequest<IResponse>
{
    public int AuthorId { get; set; }
    public class GetAuthorOfBookQueryHandler:IRequestHandler<GetAuthorOfBookQuery,IResponse>
    {
        private readonly IAuthorRepository _authorRepository;

        public GetAuthorOfBookQueryHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }


        public async Task<IResponse> Handle(GetAuthorOfBookQuery request, CancellationToken cancellationToken)
        {
            var result = await _authorRepository.GetAuthorOfBooks(request.AuthorId);
            return new Response<AuthorOfBooksDTO>(result);
        }
    }
}