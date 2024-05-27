var builder = WebApplication.CreateBuilder(args);

//AGREGAR SERVICIOS AL CONTENEDOR
builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

//CONFIGURAR LA CANALIZACION DES SOLICITUDES HTTP.
app.MapControllers();
app.Run();
