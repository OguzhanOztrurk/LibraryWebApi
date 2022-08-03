using Entities.Concrete;

namespace Business.Security.Token;

public interface ITokenHandler
{
    AccessToken CreateAccessToken(User user);
    void RevokeRefreshToken(User user);
}