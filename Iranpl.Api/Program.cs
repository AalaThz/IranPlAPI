﻿using Iranpl.Api.Controllers;
using Iranpl.ApplicationCore.Services.Implementations;
using Iranpl.ApplicationCore.Services.Intefaces;
using Iranpl.Infrastructure.Data.IranPlDbContext;
using Iranpl.Infrastructure.Repositories;
using Iranpl.Ioc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApiContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("ApiDatabase")));

// Register the Swagger generator, defining 1 or more Swagger documents
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "IranPl API",
        Version = "v1",
        Description = "اطلاعات مناطق جغرافیای ایران API ",
        //TermsOfService = new Uri("https://example.com/terms"),
        //Contact = new OpenApiContact
        //{
        //    Name = "John Walkner",
        //    Email = "John.Walkner@gmail.com",
        //    Url = new Uri("https://twitter.com/jwalkner"),
        //},
        //License = new OpenApiLicense
        //{
        //    Name = "Employee API LICX",
        //    Url = new Uri("https://example.com/license"),
        //}
    });

    // Add more versions if needed
    //c.SwaggerDoc("v2", new OpenApiInfo { Title = "My API", Version = "v2" });

    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
    c.EnableAnnotations();
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

app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        // Add more endpoints for other versions if needed
        //c.SwaggerEndpoint("/swagger/v2/swagger.json", "My API V2");
        c.InjectStylesheet("/assets/swagger-style.css");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
