using ApiRest.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//ADGREGAR CONTEXTO DE BASE DE DATOS
var cadena = builder.Configuration.GetConnectionString("MiCadenaConexion");
builder.Services.AddDbContext<AplicationDbContext>(o => o.UseSqlServer(cadena));

//AGREGAR SERVICIOS AL CONTENEDOR
builder.Services.AddControllers();

//COFIGURACION PARA SWAGGER (DOCUMENTACION)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

//SWAGGER
app.UseSwagger();
app.UseSwaggerUI();

//CONFIGURAR LA CANALIZACION DES SOLICITUDES HTTP.
app.MapControllers();
app.Run();
