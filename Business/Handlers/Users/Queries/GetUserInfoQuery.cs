using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;

namespace Business.Handlers.Users.Queries;

public class GetUserInfoQuery:IRequest<IResponse>
{
    public class GetUserInfoQueryHandler:IRequestHandler<GetUserInfoQuery, IResponse>
    {
        
        private readonly ICurrentRepository _currentRepository;
        private readonly IUserRepository _userRepository;

        public GetUserInfoQueryHandler(IUserRepository userRepository, ICurrentRepository currentRepository)
        {
            _userRepository = userRepository;
            _currentRepository = currentRepository;
        }

        public async Task<IResponse> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
        {
            var userId = _currentRepository.UserId();
            var result = await _userRepository.GetUserInfo(userId);
            return new Response<User>(result);
        }
    }
}