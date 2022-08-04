using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.Dto;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.Repository;

public class UserRepository:EfEntityRepositoryBase<User,AppDbContext>,IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<User> FindByUNameAsync(string userName)
    {
        return await Context.Users.Include(u => u.UserRoles)
            .ThenInclude(ur => ur.Role)
            .SingleOrDefaultAsync(u => u.UserName == userName);
    }

    public async Task<IEnumerable<UserWithRolesDTO>> GetUserRoleNames(int userId)
    {
        var result = await (from users in Context.Users
            join userRoles in Context.UserRoles
                on users.UserID equals userRoles.UserID
            join role in Context.Roles
                on userRoles.RoleId equals role.RoleId
            where userRoles.UserID == userId
            select new UserWithRolesDTO()
            {
                roleId = role.RoleId,
                Name = role.Name
            }).ToListAsync();
        return result;
    }

    public List<UserWithRolesDTO> GetUserRoleNamesList(int userId)
    {
        var result = (from users in Context.Users
            join userRoles in Context.UserRoles
                on users.UserID equals userRoles.UserID
            join role in Context.Roles
                on userRoles.RoleId equals role.RoleId
            where userRoles.UserID == userId
            select new UserWithRolesDTO()
            {
                Name = role.Name
            }).ToList();
        return result;
    }
}