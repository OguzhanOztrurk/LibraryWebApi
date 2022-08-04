using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.Repository;

public class UserRoleRepository:EfEntityRepositoryBase<UserRole,AppDbContext>,IUserRoleRepository
{
    public UserRoleRepository(AppDbContext context) : base(context)
    {
    }
}