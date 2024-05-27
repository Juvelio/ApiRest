using ApiRest.Data;
using Entidades.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ApiRest.Controller.v1
{
	[Route("api/[controller]")]
	[ApiController]
	public class PersonasController : ControllerBase
	{
		public List<Persona> listaPersonas;
		private readonly AplicationDbContext _context;

		public PersonasController(AplicationDbContext context)
		{
			_context = context;
		}

		[HttpGet("{id}")]
		public ActionResult<Persona> ObtenerPersona(int id)
		{
			var persona = listaPersonas.Where(x => x.DNI == id).FirstOrDefault();

			if (persona == null)
				return NotFound("No se encontró persona con el id solicitado");

			return persona;
		}

		[HttpGet]
		public async Task<List<Persona>> ObtenerListadoPersona()
		{
			//return listaPersonas;
			var data = await _context.Personas.ToListAsync();
			return data;
		}

		[HttpPost]
		public async Task<ActionResult> Crear(Persona persona)
		{
			await _context.Personas.AddAsync(persona);
			_context.SaveChanges();

			return Ok("Persona se creo correctamente");
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> Modificar(int id, Persona persona)
		{
			var personaDb = await _context.Personas
				.Where(x => x.DNI == id).FirstOrDefaultAsync();

			if (personaDb == null)
				return NotFound("persona no existe");			

			personaDb.Parterno = persona.Parterno;
			personaDb.Materno = persona.Materno;
			personaDb.Nombres = persona.Nombres;
			_context.SaveChanges();

			return Ok("Persona se modifico correctamente");
		}


		[HttpDelete("{id}")]
		public async Task<ActionResult> Eliminar(int id)
		{
			var personaDb = await _context.Personas
				.Where(x => x.DNI == id).FirstOrDefaultAsync();

			if (personaDb == null)
				return NotFound("persona no existe");

			_context.Remove(personaDb);
			_context.SaveChanges();

			return Ok("Persona se elimino correctamente");
		}

	}
}
