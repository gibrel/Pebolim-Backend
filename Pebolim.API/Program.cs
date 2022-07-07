using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Pebolim.API.Configurations;
using Pebolim.Data.Configurations;
using Pebolim.Data.Context;
using Pebolim.Data.Repositories;
using Pebolim.Domain.Entities;
using Pebolim.Domain.Interfaces;
using Pebolim.Service.Services;
//using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

ConfigureServices(builder.Services);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    //c => {
    //    // Set the comments path for the Swagger JSON and UI.
    //    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    //    c.IncludeXmlComments(xmlPath);
    //}
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<MySQLContext>())
    context?.Database.Migrate();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void ConfigureServices(IServiceCollection services)
{
    services.Configure<MySQLConfiguration>(
        builder.Configuration.GetSection("ConnectionStrings"));

    services.AddSingleton(new MapperConfiguration(config =>
    {
        config.AddProfile<UserMapProfile>();
    }).CreateMapper());

    services.AddDbContext<MySQLContext>();

    builder.Services.AddScoped<IBaseRepository<User>, BaseRepository<User>>();
    builder.Services.AddScoped<IBaseService<User>, BaseService<User>>();
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<IUserService, UserService>();

    services.AddMvc(option => option.EnableEndpointRouting = false)
        .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
}
