using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dto;

namespace DataAccess.Abstract;

public interface IUserRepository:IEntityRepository<User>
{
    Task<User> FindByUNameAsync(string userName);
    Task<IEnumerable<UserWithRolesDTO>> GetUserRoleNames(Guid userId);
    List<UserWithRolesDTO> GetUserRoleNamesList(Guid userId);

    Guid UserId();

    string UserRole();

    Task<User> GetUserInfo(Guid userId);
}