using Microsoft.EntityFrameworkCore;
using MinimalApi.DTOs;
using MinimalApi.Infraestrutura.Db;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DbContexto>(options => {
    options.UseMySql(
        builder.Configuration.GetConnectionString("mysql")
        ,ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("mysql")) 
    );
});

var app = builder.Build();



app.MapGet("/", () => "Hello World!");

app.MapPost("/login", (LoginDTO loginDTO) => 
{
    // Login logic here
    if (loginDTO.Email == "adm@teste.com" && loginDTO.Senha == "123456"){
        return Results.Ok("Login realizado com sucesso");
    } else {
        return Results.Unauthorized();
    }
});


app.Run();

