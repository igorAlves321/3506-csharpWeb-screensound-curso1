using ScreenSound.db;
using ScreenSound.Modelos;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.controle;

var builder = WebApplication.CreateBuilder(args);

// Configura��o para ignorar refer�ncias c�clicas
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Configura��es de servi�os e inje��o de depend�ncia
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ScreenSoundContext>();  // Inje��o do contexto do banco de dados
builder.Services.AddTransient<DAL<Artista>>();        // Inje��o do DAL para Artista
builder.Services.AddTransient<DAL<Musica>>();         // Inje��o do DAL para Musica

var app = builder.Build();

// Configura��o do Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Chamando os m�todos de extens�o para adicionar os endpoints
app.AddEndPointsArtistas();
app.AddEndPointsMusicas();

app.Run();