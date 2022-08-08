

using Business.Extensions;

using FluentValidation.AspNetCore;
using System.Configuration;
using System.Reflection;
using System.Text;
using DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MMLib.Ocelot.Provider.AppConfiguration;
using MMLib.SwaggerForOcelot.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
Host.CreateDefaultBuilder(args).ConfigureAppConfiguration(config =>
    {
        config.AddOcelotWithSwaggerSupport(options =>
        {
            options.Folder = "OcelotConfiguration";
        });
    })
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseStartup<StartupBase>().UseUrls(new string[] { "http://localhost:2000" });
    });
    
    
 
builder.Configuration.AddJsonFile("ocelot.json",false,true);
    

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

 


//token işlemleri
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
    
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateActor = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuer = false,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:ValidIssiuer"],
        ValidAudience = builder.Configuration["Jwt:ValidAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]))
    };
});

builder.Services.AddAuthorization();
builder.Services.RegisterDatabase(builder.Configuration);
builder.Services.RegisterServices(builder.Configuration);
builder.Services.AddBusinessLayer(builder.Configuration);




builder.Services.AddOcelot(builder.Configuration)
    .AddAppConfiguration();
builder.Services.AddSwaggerForOcelot(builder.Configuration);



builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseSwaggerForOcelotUI(builder.Configuration);

app.UseHttpsRedirection();
app.UseSwagger();

app.UseAuthentication();
app.UseAuthorization();



app.MapControllers();
app.UseSwaggerUI();

app.Run();
