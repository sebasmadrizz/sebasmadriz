using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
	public class ListaDeVisualizacionBase
	{
		public string Prioridad { get; set; }
	}

	public class ListaDeVisualizacionRequest : ListaDeVisualizacionBase
	{
		public int IdPelicula { get; set; }
		[Required]
		public string Username { get; set; }
	}

	public class ListaDeVisualizacionResponse : ListaDeVisualizacionBase
	{
		public Guid Id { get; set; }
		public int IdPelicula { get; set; }

		[JsonPropertyName("original_title")]
		public string Titulo { get; set; }

		
	}
	public class ListaDeVisualizacionApiResponse
	{
		[JsonPropertyName("original_title")]
		public string Titulo { get; set; }

	}
}
