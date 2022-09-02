using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Pebolim.WebAPI.Configurations;
using Pebolim.Data.Configurations;
using Pebolim.Data.Context;
using Pebolim.Data.Repositories;
using Pebolim.Domain.Entities;
using Pebolim.Domain.Interfaces;
using Pebolim.Service.Configurations;
using Pebolim.Service.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

ConfigureServices(builder.Services);

builder.Services.AddControllers().AddNewtonsoftJson( o =>
{
    o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<DatabaseContext>())
    context?.Database.Migrate();

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();

void ConfigureServices(IServiceCollection services)
{
    services.Configure<WebApiConfigurations>(
        builder.Configuration.GetSection("Settings"));

    services.Configure<DatabaseConfiguration>(
        builder.Configuration.GetSection("ConnectionStrings"));

    services.AddSingleton(new MapperConfiguration(config =>
    {
        config.AddProfile<ProfileMapProfile>();
        config.AddProfile<TeamMapProfile>();
        config.AddProfile<UserMapProfile>();
    }).CreateMapper());

    services.AddDbContext<DatabaseContext>();

    builder.Services.AddScoped<IBaseRepository<User>, BaseRepository<User>>();
    builder.Services.AddScoped<IBaseService<User>, BaseService<User>>();
    builder.Services.AddScoped<IBaseRepository<UserProfile>, BaseRepository<UserProfile>>();
    builder.Services.AddScoped<IBaseService<UserProfile>, BaseService<UserProfile>>();
    builder.Services.AddScoped<IBaseRepository<Team>, BaseRepository<Team>>();
    builder.Services.AddScoped<IBaseService<Team>, BaseService<Team>>();
    builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
    builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
    builder.Services.AddScoped<IProfileRegisterRepository, ProfileRegisterRepository>();
    builder.Services.AddScoped<IProfileRegisterService, ProfileRegisterService>();
    builder.Services.AddScoped<ITeamManagementRepository, TeamManagementRepository>();
    builder.Services.AddScoped<ITeamManagementService, TeamManagementService>();

    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer( o =>
    {
        var settings = new WebApiConfigurations();
        o.TokenValidationParameters = new TokenValidationParameters()
        {
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(settings.BearerKey ?? "alternative-bearer-key")),
            ValidateIssuerSigningKey = true,
            ValidateAudience = false,
            ValidateIssuer = false
        };
    });

    services.AddMvc(option => option.EnableEndpointRouting = false)
        .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
}
