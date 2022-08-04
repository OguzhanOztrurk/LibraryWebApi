using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dto;

namespace DataAccess.Abstract;

public interface IUserRepository:IEntityRepository<User>
{
    Task<User> FindByUNameAsync(string userName);
    Task<IEnumerable<UserWithRolesDTO>> GetUserRoleNames(int userId);
    List<UserWithRolesDTO> GetUserRoleNamesList(int userId);
}