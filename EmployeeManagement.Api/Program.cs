using EmployeeManagement.Infrastructure;
using EmployeeManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddApplication();

builder.Services.AddInfrastructure(
    builder.Configuration);

/*
builder.Services.AddDbContext<EmployeeDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));
*/
var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();