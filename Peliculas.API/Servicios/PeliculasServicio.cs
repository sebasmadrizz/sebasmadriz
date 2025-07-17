using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos.Servicios.Peliculas;
using System.Numerics;
using System.Text.Json;

namespace Servicios
{
    public class PeliculasServicio : IPeliculasServicio
    {
        private readonly IConfiguracion _configuracion;
        private readonly IHttpClientFactory _httpClient;

        public PeliculasServicio(IConfiguracion configuracion, IHttpClientFactory httpClient)
        {
            _configuracion = configuracion;
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<PeliculaResponseEs>> ObtenerPeliculasXGenero(int idGenero)
        {
            var endPoint = _configuracion.ObtenerMetodo("ApiEndPointsPeliculas", "ObtenerPeliculas");
            var servicioPelicula = _httpClient.CreateClient("ServicioPelicula");
            var token = _configuracion.ObtenerValor("TokenServicioPeliculas");
            servicioPelicula.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            var respuesta = await servicioPelicula.GetAsync(string.Format(endPoint, idGenero));
            respuesta.EnsureSuccessStatusCode();
            var resultado = await respuesta.Content.ReadAsStringAsync();
            var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var apiResponse = JsonSerializer.Deserialize<PeliculasApiResponse>(resultado, opciones);

            var peliculasEnEspañol = apiResponse?.Results?.Select(p => new PeliculaResponseEs
            {
                Id = p.Id,
                Titulo = p.Titulo,
                Imagen = p.Imagen,
                Descripcion = p.Descripcion,
                Fecha = p.Fecha,
                Calificacion = p.Calificacion
            });

            return peliculasEnEspañol ?? new List<PeliculaResponseEs>();
        }






    }


}
