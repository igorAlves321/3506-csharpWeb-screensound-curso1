using ScreenSound.API.Controle;
using ScreenSound.db;
using ScreenSound.Modelos;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Configura��o para ignorar refer�ncias c�clicas
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Configura��es de servi�os e inje��o de depend�ncia
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ScreenSoundContext>();
builder.Services.AddTransient<DAL<Artista>>();
builder.Services.AddTransient<DAL<Musica>>();

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