using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos.Servicios.Peliculas;
using Abstracciones.Modelos.Servicios.Series;
using System.Numerics;
using System.Text.Json;

namespace Servicios
{
    public class SeriesServicio : ISeriesServicio
    {
        private readonly IConfiguracion _configuracion;
        private readonly IHttpClientFactory _httpClient;

        public SeriesServicio(IConfiguracion configuracion, IHttpClientFactory httpClient)
        {
            _configuracion = configuracion;
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<SerieResponseEs>> ObtenerSeriesXGenero(int idGenero)
        {
            var endPoint = _configuracion.ObtenerMetodo("ApiEndPointsSeries", "ObtenerSeries");
            var servicioSeries = _httpClient.CreateClient("ServicioSeries");
            var token = _configuracion.ObtenerValor("TokenServicioPeliculas");
            servicioSeries.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            var respuesta = await servicioSeries.GetAsync(string.Format(endPoint, idGenero));
            respuesta.EnsureSuccessStatusCode();
            var resultado = await respuesta.Content.ReadAsStringAsync();
            var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var apiResponse = JsonSerializer.Deserialize<SeriesApiResponse>(resultado, opciones);
            var seriesEnEspañol = apiResponse?.Results?.Select(p => new SerieResponseEs
            {
                Id = p.Id,
                Titulo = p.Titulo,
                Imagen = p.Imagen,
                Descripcion = p.Descripcion,
                Fecha = p.Fecha,
                Calificacion = p.Calificacion
            });

            return seriesEnEspañol ?? new List<SerieResponseEs>();
        }
    }
}
