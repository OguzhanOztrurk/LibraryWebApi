
using DataAccess.Concrete.Configurations;
using DataAccess.Concrete.Seed;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Type = Entities.Concrete.Type;

namespace DataAccess.Concrete.EntityFramework.Contexts;

public class AppDbContext:DbContext
{
    protected readonly IConfiguration _configuration;


    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    #region DbSet
    public virtual DbSet<Type> Types { get; set; }
    public virtual DbSet<BookType> BookTypes { get; set; }
    public virtual DbSet<BookAuthor> BookAuthors { get; set; }
    public virtual DbSet<Author> Authors { get; set; }
    public virtual DbSet<Member> Members { get; set; }
    public virtual DbSet<Onloan> Onloans { get; set; }
    public virtual DbSet<Book> Books { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<UserRole> UserRoles { get; set; }
    #endregion
        
        
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        #region Configurations
        new TypeConfiguration().Configure(modelBuilder.Entity<Type>());
        new BookTypeConfiguration().Configure(modelBuilder.Entity<BookType>());
        new BookAuthorConfiguration().Configure(modelBuilder.Entity<BookAuthor>());
        new AuthorConfiguration().Configure(modelBuilder.Entity<Author>());
        new MemberConfiguration().Configure(modelBuilder.Entity<Member>());
        new OnloanConfiguration().Configure(modelBuilder.Entity<Onloan>());
        new BookConfiguration().Configure(modelBuilder.Entity<Book>());
        new UserConfiguration().Configure(modelBuilder.Entity<User>());
        new RoleConfiguration().Configure(modelBuilder.Entity<Role>());
        new UserRoleConfiguration().Configure(modelBuilder.Entity<UserRole>());
        #endregion

        #region Seeds
        new TypeSeed().Configure(modelBuilder.Entity<Type>());
        new BookTypeSeed().Configure(modelBuilder.Entity<BookType>());
        new BookAuthorSeed().Configure(modelBuilder.Entity<BookAuthor>());
        new AuthorSeed().Configure(modelBuilder.Entity<Author>());
        new MemberSeed().Configure(modelBuilder.Entity<Member>());
        new OnloanSeed().Configure(modelBuilder.Entity<Onloan>());
        new BookSeed().Configure(modelBuilder.Entity<Book>());
        #endregion
           
    }
}