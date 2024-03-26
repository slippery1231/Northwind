using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Northwind.ExceptionHandler;
using Northwind.Models;
using Northwind.Models.Mapper;
using Northwind.Repositories.Implement;
using Northwind.Services.Implement;
using Northwind.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
builder.Services.AddDbContext<NorthwindContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("DbContext"));
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddTransient<ICustomerBl, CustomerBl>();
builder.Services.AddTransient<DbRepository, DbRepository>();

// AutoMapper register
builder.Services.AddAutoMapper(typeof(EntityMappingProfile));


var app = builder.Build();

app.MapGet("/", () => "BackendApi Started");


// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
        var exception = exceptionHandlerPathFeature.Error;

        if (exception is CustomerNotFoundException)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await context.Response.WriteAsync(CustomerNotFoundException.ErrorMessage);
        }
        else
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(exception.Message);
        }
    });
});

app.Run();