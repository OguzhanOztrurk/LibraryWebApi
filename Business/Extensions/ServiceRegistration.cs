



using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;

using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;

using DataAccess.Abstract;
using DataAccess.Concrete.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

using Configuration = Castle.Windsor.Installer.Configuration;

namespace Business.Extensions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection RegisterDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("connectionStr"),
                    sqlOptions =>
                    {
                        sqlOptions
                            .EnableRetryOnFailure(
                                maxRetryCount: 1,
                                maxRetryDelay: TimeSpan.FromSeconds(10),
                                errorNumbersToAdd: null);
                    });
                // options.EnableSensitiveDataLogging();
                // options.EnableDetailedErrors();
            }, ServiceLifetime.Transient, ServiceLifetime.Singleton);
        }
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                    .AddTransient<IBookRepository,BookRepository>()
                    .AddTransient<IAuthorRepository,AuthorRepository>()
                    .AddTransient<IBookAuthorRepository,BookAuthorRepository>()
                    .AddTransient<IBookTypeRepository,BookTypeRepository>()
                    .AddTransient<IMemberRepository,MemberRepository>()
                    .AddTransient<IOnloanRepository,OnloanRepository>()
                    .AddTransient<ITypeRepository,TypeRepository>()
                    .AddTransient<IUserRepository,UserRepository>()
                    .AddTransient<IRoleRepository,RoleRepository>()
                    .AddTransient<IUserRoleRepository,UserRoleRepository>()
                    .AddTransient<ICurrentRepository,CurrentRepository>()
                ;
            
        }
        public static void AddBusinessLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly())
                 .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
        
    }
}
