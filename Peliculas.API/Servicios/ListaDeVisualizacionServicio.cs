using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Servicios
{
	public class ListaDeVisualizacionServicio: IListaDeVisualizacionServicio
    {
		private readonly IConfiguracion _configuracion;
		private readonly IHttpClientFactory _httpClient;
		private IListaDeVisualizacionDA _listaDeVisualizacionDA;
		public ListaDeVisualizacionServicio(IListaDeVisualizacionDA listaDeVisualizacionDA, IConfiguracion configuracion, IHttpClientFactory httpClient)
		{
			_configuracion = configuracion;
			_httpClient = httpClient;
			_listaDeVisualizacionDA = listaDeVisualizacionDA;
		}

		public async Task<IEnumerable<ListaDeVisualizacionResponse>> ObtenerListaDeVisualizacion(string username)
		{
			var listaDeVisualizacion = await _listaDeVisualizacionDA.Obtener(username);
			var endPoint = _configuracion.ObtenerMetodo("ApiEndPointsPeliculasBuscar", "ObtenerPeliculasPorId");
			var servicioListaDeVisualizacion = _httpClient.CreateClient("servicioListaDeVisualizacion");
			var token = _configuracion.ObtenerValor("TokenServicioPeliculas");
			servicioListaDeVisualizacion.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
			var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
			var tareas = listaDeVisualizacion.Select(async lista =>
			{
				var url = string.Format(endPoint, lista.IdPelicula);
				var respuesta = await servicioListaDeVisualizacion.GetAsync(url);
				respuesta.EnsureSuccessStatusCode();

				var contenido = await respuesta.Content.ReadAsStringAsync();
				var datosApi = JsonSerializer.Deserialize<ListaDeVisualizacionApiResponse>(contenido, opciones);

				return new ListaDeVisualizacionResponse
				{
Id= lista.Id,
					IdPelicula = lista.IdPelicula,
					Titulo = datosApi.Titulo,
					Prioridad = lista.Prioridad
				};
			});

			var resultados = await Task.WhenAll(tareas);
			return resultados;
		}



	}
}
