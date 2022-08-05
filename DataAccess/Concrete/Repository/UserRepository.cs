using System.Security.Claims;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.Repository;

public class UserRepository:EfEntityRepositoryBase<User,AppDbContext>,IUserRepository
{

    private readonly IHttpContextAccessor _httpContextAccessor;
    public UserRepository(AppDbContext context, IHttpContextAccessor httpContextAccessor) : base(context)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<User> FindByUNameAsync(string userName)
    {
        return await Context.Users.Include(u => u.UserRoles)
            .ThenInclude(ur => ur.Role)
            .SingleOrDefaultAsync(u => u.UserName == userName);
    }

    public async Task<IEnumerable<UserWithRolesDTO>> GetUserRoleNames(Guid userId)
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

    public List<UserWithRolesDTO> GetUserRoleNamesList(Guid userId)
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

    public Guid UserId()
    {
        var userId= _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Guid.Parse(userId);
    }

    public string UserRole()
    {
        return _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Role).Value;
    }

    public async Task<User> GetUserInfo(Guid userId)
    {
        var result = await Context.Users.Where(x => x.UserID == userId).FirstAsync();
        return result;
    }
}