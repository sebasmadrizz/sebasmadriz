
using System.Text.Json.Serialization;



namespace Abstracciones.Modelos.Servicios.Categorias
{
	public class CategoriasBase
	{

		[JsonPropertyName("name")]
		public string Nombre { get; set; }
	}
	public class CategoriasResponse
	{

		[JsonPropertyName("name")]
		public string Nombre { get; set; }
	}
	// Clase contenedora para la respuesta de la API
	public class CategoriasApiResponse
	{
		[JsonPropertyName("genres")]
		public List<CategoriasResponse> Results { get; set; }
	}
}

