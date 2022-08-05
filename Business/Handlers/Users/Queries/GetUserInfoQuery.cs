using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.Users.Queries;

public class GetUserInfoQuery:IRequest<IResponse>
{
    public class GetUserInfoQueryHandler:IRequestHandler<GetUserInfoQuery, IResponse>
    {
        private readonly IUserRepository _userRepository;

        public GetUserInfoQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IResponse> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
        {
            var userId = _userRepository.UserId();
            var result = await _userRepository.GetUserInfo(userId);
            return new Response<User>(result);
        }
    }
}