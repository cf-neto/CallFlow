using CallFlow.Models;
using CallFlow.Data;
using CallFlow.DTOs;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

// using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Adiciona controllers
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Adicionar EF Corecom MySql
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 0))
    );
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
    app.MapOpenApi();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
