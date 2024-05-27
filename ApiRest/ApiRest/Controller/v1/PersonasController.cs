using Entidades.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiRest.Controller.v1
{
	[Route("api/[controller]")]
	[ApiController]
	public class PersonasController : ControllerBase
	{
		public List<Persona> listaPersonas;
		public PersonasController()
		{
			listaPersonas = new List<Persona>()
			{
				new Persona{ DNI = 47833864, Parterno = "MIRANDA", Materno = "LUNA", Nombres = "JUVELIO" },
				new Persona{ DNI = 47620509, Parterno = "CANDIA", Materno = "CHACMANA", Nombres = "MELISA" },
				new Persona{ DNI =12345678, Parterno = "MEDINA", Materno="TICONA", Nombres="Jimy"},
				new Persona{ DNI = 12345679, Parterno = "GARCÍA", Materno = "RAMÍREZ", Nombres = "MARÍA" },
				new Persona{ DNI = 23456780, Parterno = "LOPEZ", Materno = "FERNANDEZ", Nombres = "CARLOS" },
				new Persona{ DNI = 34567891, Parterno = "RODRIGUEZ", Materno = "GONZÁLEZ", Nombres = "LAURA" },
				new Persona{ DNI = 45678902, Parterno = "MARTÍNEZ", Materno = "PÉREZ", Nombres = "PEDRO" },
				new Persona{ DNI = 56789013, Parterno = "SÁNCHEZ", Materno = "LÓPEZ", Nombres = "ANA" },
				new Persona{ DNI = 67890124, Parterno = "GÓMEZ", Materno = "MARTÍNEZ", Nombres = "JORGE" },
				new Persona{ DNI = 78901235, Parterno = "HERNÁNDEZ", Materno = "RODRÍGUEZ", Nombres = "ISABEL" },
				new Persona{ DNI = 89012346, Parterno = "DÍAZ", Materno = "SÁNCHEZ", Nombres = "DAVID" },
				new Persona{ DNI = 90123457, Parterno = "TORRES", Materno = "GÓMEZ", Nombres = "SOFÍA" },
				new Persona{ DNI = 12345789, Parterno = "RAMÍREZ", Materno = "HERNÁNDEZ", Nombres = "MIGUEL" },
				new Persona{ DNI = 23457890, Parterno = "GONZÁLEZ", Materno = "DÍAZ", Nombres = "JULIA" },
				new Persona{ DNI = 34578901, Parterno = "FERNÁNDEZ", Materno = "TORRES", Nombres = "PABLO" },
				new Persona{ DNI = 45689012, Parterno = "PÉREZ", Materno = "RAMÍREZ", Nombres = "ANA" },
				new Persona{ DNI = 56790123, Parterno = "SANTIAGO", Materno = "SÁNCHEZ", Nombres = "LUIS" },
				new Persona{ DNI = 67891234, Parterno = "VÁZQUEZ", Materno = "GONZÁLEZ", Nombres = "MARINA" },
				new Persona{ DNI = 78902345, Parterno = "GARCÍA", Materno = "MARTÍNEZ", Nombres = "JOSÉ" },
				new Persona{ DNI = 89013456, Parterno = "LOZANO", Materno = "SANTIAGO", Nombres = "ELENA" },
				new Persona{ DNI = 90134567, Parterno = "MENDOZA", Materno = "FERNÁNDEZ", Nombres = "RICARDO" },
				new Persona{ DNI = 12346890, Parterno = "CASTILLO", Materno = "GÓMEZ", Nombres = "ANDREA" },
				new Persona{ DNI = 23458901, Parterno = "RUIZ", Materno = "PÉREZ", Nombres = "ANTONIO" }
			};
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
		public List<Persona> ObtenerListadoPersona()
		{
			return listaPersonas;
		}
	}
}
