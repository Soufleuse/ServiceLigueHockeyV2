using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ServiceLigueHockey.Data;
//using Pomelo.EntityFrameworkCore.MySql.Extensions;

var builder = WebApplication.CreateBuilder(args);

string monAllowSpecificOrigin = "monAllowSpecificOrigin";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ServiceLigueHockeyContext>(options => {
    var connectionString = builder.Configuration.GetConnectionString("mysqlConnection");
    if(string.IsNullOrEmpty(connectionString))
    {
        throw new System.Exception("La chaine de connexion est vide.");
    }

    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddCors(options => {
    options.AddPolicy(name: monAllowSpecificOrigin,
        builder => {
            builder.WithOrigins("http://localhost:4900", "https://localhost:4900", "https://localhost:7166", "https://127.0.0.1:4900");
            builder.WithHeaders("Content-Type");
            builder.WithMethods("*");
            //builder.WithMethods("POST","GET","PUT","OPTIONS");
        });
});

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
