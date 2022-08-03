using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.Authors.Queries;

public class GetAuthersQuery:IRequest<IResponse>
{
    public class GetAuthersQueryHandler:IRequestHandler<GetAuthersQuery,IResponse>
    {
        private readonly IAuthorRepository _authorRepository;

        public GetAuthersQueryHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<IResponse> Handle(GetAuthersQuery request, CancellationToken cancellationToken)
        {
            var authors = await _authorRepository.GetListAsync();
            return new Response<IEnumerable<Author>>(authors);
        }
    }
}