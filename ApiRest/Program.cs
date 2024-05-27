using ApiRest.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//ADGREGAR CONTEXTO DE BASE DE DATOS
var cadena = builder.Configuration.GetConnectionString("MiCadenaConexion");
builder.Services.AddDbContext<AplicationDbContext>(o => o.UseSqlServer(cadena));

//AGREGAR SERVICIOS AL CONTENEDOR
builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

//CONFIGURAR LA CANALIZACION DES SOLICITUDES HTTP.
app.MapControllers();
app.Run();
