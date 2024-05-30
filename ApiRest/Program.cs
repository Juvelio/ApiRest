using ApiRest.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//AUTOMAPPER
builder.Services.AddAutoMapper(typeof(Program));

//ADGREGAR CONTEXTO DE BASE DE DATOS
var cadena = builder.Configuration.GetConnectionString("MiCadenaConexion");
builder.Services.AddDbContext<AplicationDbContext>(o => o.UseSqlServer(cadena));

//CONFIGURACION DE SERVICIO DE ATENTICACION JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(option =>
	{
		option.TokenValidationParameters = new TokenValidationParameters()
		{
			ValidateIssuer = true,
			ValidateAudience = true,
			ValidateLifetime = true,
			ValidateIssuerSigningKey = true,

			ValidIssuer = builder.Configuration["JWT:Issuer"],
			ValidAudience = builder.Configuration["JWT:Audience"],
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:ClaveSecreta"])),
			ClockSkew = TimeSpan.Zero
		};
	});



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
