using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos.Servicios.Categorias;


namespace Servicios
{
	public class CategoriasServicio :ICategoriasServicio
	{
		private readonly IConfiguracion _configuracion;
		private readonly IHttpClientFactory _httpClient;

		public CategoriasServicio(IConfiguracion configuracion, IHttpClientFactory httpClient)
		{
			_configuracion = configuracion;
			_httpClient = httpClient;
		}

		public async Task<IEnumerable<CategoriasResponse>> ObtenerCategoriasDeSeries()
		{
			var endPoint = _configuracion.ObtenerMetodo("ApiEndPointsCategoriasDeSeries", "ObtenerCategoriasDeSeries");
			var servicioCategorias = _httpClient.CreateClient("ServicioCategorias");
			var token = _configuracion.ObtenerValor("TokenServicioPeliculas");
			servicioCategorias.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
			var respuesta = await servicioCategorias.GetAsync(endPoint);
			respuesta.EnsureSuccessStatusCode();
			var resultado = await respuesta.Content.ReadAsStringAsync();
			Console.WriteLine("JSON recibido:\n" + resultado);
			var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
			var apiResponse = JsonSerializer.Deserialize<CategoriasApiResponse>(resultado, opciones);
			return apiResponse?.Results ?? new List<CategoriasResponse>();
		}
        public async Task<IEnumerable<CategoriasResponse>> ObtenerCategoriasDePeliculas()
        {
            var endPoint = _configuracion.ObtenerMetodo("ApiEndPointsCategoriasDePeliculas", "ObtenerCategoriasDePeliculas");
            var servicioCategorias = _httpClient.CreateClient("ServicioCategorias");
            var token = _configuracion.ObtenerValor("TokenServicioPeliculas");
            servicioCategorias.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            var respuesta = await servicioCategorias.GetAsync(endPoint);
            respuesta.EnsureSuccessStatusCode();
            var resultado = await respuesta.Content.ReadAsStringAsync();
            Console.WriteLine("JSON recibido:\n" + resultado);
            var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var apiResponse = JsonSerializer.Deserialize<CategoriasApiResponse>(resultado, opciones);
            return apiResponse?.Results ?? new List<CategoriasResponse>();
        }
    }
}
