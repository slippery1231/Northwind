using Microsoft.EntityFrameworkCore;
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

app.UseExceptionHandler("/api/error");
app.UseHsts();

app.Run();