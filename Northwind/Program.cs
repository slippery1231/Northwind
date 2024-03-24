using Northwind.Services.Implement;
using Northwind.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<ICustomerBl,CustomerBl>();

var app = builder.Build();

app.MapGet("/", () => "BackendApi Started");


// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
