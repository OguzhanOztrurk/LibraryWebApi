using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.Repository;

public class RoleRepository:EfEntityRepositoryBase<Role,AppDbContext>,IRoleRepository
{
    public RoleRepository(AppDbContext context) : base(context)
    {
    }
}