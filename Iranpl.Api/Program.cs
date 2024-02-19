using Iranpl.Api.Controllers;
using Iranpl.ApplicationCore.Services.Implementations;
using Iranpl.ApplicationCore.Services.Intefaces;
using Iranpl.Infrastructure.Data.IranPlDbContext;
using Iranpl.Infrastructure.Repositories;
using Iranpl.Ioc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApiContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("ApiDatabase")));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Employee API",
        Version = "v1",
        Description = "An API to perform Employee operations",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "John Walkner",
            Email = "John.Walkner@gmail.com",
            Url = new Uri("https://twitter.com/jwalkner"),
        },
        License = new OpenApiLicense
        {
            Name = "Employee API LICX",
            Url = new Uri("https://example.com/license"),
        }
    });
});

#region Ioc
//builder.Services.RegisterServices(builder.Configuration);
builder.Services.AddScoped<IStateRepository, StateReository>();
builder.Services.AddScoped<StateService>();

builder.Services.AddScoped<ITownshipRepository, TownshipRepository>();
builder.Services.AddScoped<TownshipService>();

builder.Services.AddScoped<IPartRepository , PartRepository>();
builder.Services.AddScoped<PartService>();

builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<CityService>();

builder.Services.AddScoped<IVillageRepository, VillageRepository>();
builder.Services.AddScoped<VillageService>();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
