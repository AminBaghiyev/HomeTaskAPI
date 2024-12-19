using EmployeeManagement.BL.Services.Abstractions;
using EmployeeManagement.BL.Services.Implementations;
using EmployeeManagement.Core.Entities;
using EmployeeManagement.DAL.Contexts;
using EmployeeManagement.DAL.Repositories.Abstractions;
using EmployeeManagement.DAL.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("local"));
    }
);

builder.Services.AddScoped<IRepository<Department>, Repository<Department>>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IRepository<Employee>, Repository<Employee>>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
