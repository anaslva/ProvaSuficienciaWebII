using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProvaSuficienciaWebII.DAO;
using ProvaSuficienciaWebII.Data.Context;
using ProvaSuficienciaWebII.Extensions;
using ProvaSuficienciaWebII.Handler;
using ProvaSuficienciaWebII.Handler.Auth;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddScoped <IAuthHandler, AuthHandler>();
builder.Services.AddScoped<IComandaDAO, ComandaDAO>();
builder.Services.AddScoped<IComandasHandler, ComandaHandler>();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Scheme = "Bearer",
        Type = SecuritySchemeType.ApiKey,
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "default",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });

});


builder.Services.AddDbContext<Context>(options => options.UseMySql(
    builder.Configuration.GetConnectionString("Default"),
    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.25-mysql")
    ));

builder.Services.AddAuthenticationConfiguration(builder.Configuration);

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

