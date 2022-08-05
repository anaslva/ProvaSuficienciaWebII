using Microsoft.EntityFrameworkCore;
using ProvaSuficienciaWebII.Data.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<Context>(options => options.UseMySql(
    "server=localhost;initial catalog=PROVA_WEB;uid=root;pwd=Oliver1902",
    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.25-mysql")
    ));
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
