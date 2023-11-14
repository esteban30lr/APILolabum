using Lolabum.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LolabumContext>(options =>
{   
    //cambiar configuración servidor
    options.UseSqlServer("Server=database-lolabum.c965ovxctom6.us-east-2.rds.amazonaws.com;Database=lolabum;User Id=admin;Password=Danis4357; MultipleActivateResultSets=true;");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseCors(options =>
{
    options.AllowAnyOrigin();
    options.AllowAnyHeader();
    options.AllowAnyMethod();
});
app.UseAuthorization();

app.MapControllers();

app.Run();
