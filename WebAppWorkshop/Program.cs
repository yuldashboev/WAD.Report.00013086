using Microsoft.EntityFrameworkCore;
using WebAppWorkshop.DAL;
using WebAppWorkshop.Models;
using WebAppWorkshop.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<GeneralDbContext>(
    o => o.UseSqlServer(
        builder.Configuration.GetConnectionString("SqlServerConnection")));
builder.Services.AddScoped<IRepository<Receptionist>, RRepo>();  
builder.Services.AddScoped<IRepository<Appointment>, ARepo>();  

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
