using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Models
{
	public class Persona
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int DNI { get; set; }
		public string Nombres { get; set; }
		public string Parterno { get; set; }
		public string Materno { get; set; }
	}
}
