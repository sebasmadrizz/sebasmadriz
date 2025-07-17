using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos;
using System.Text.Json;

namespace Servicios
{
    public class PeliculaFavServicio : IPeliculaFavServicio
    {
        private readonly IConfiguracion _configuracion;
        private readonly IHttpClientFactory _httpClient;
        private IPeliculaFavDA _peliculaFavDA;

        public PeliculaFavServicio(IPeliculaFavDA peliculaFavDA,IConfiguracion configuracion, IHttpClientFactory httpClient)
        {
            _configuracion = configuracion;
            _httpClient = httpClient;
            _peliculaFavDA = peliculaFavDA;
        }

        public async Task<IEnumerable<PeliculaFavResponse>> ObtenerPeliculasFav(string username)
        {
            var peliculasFavTask = ObtenerListaPeliculasFav(username);
            var endPoint = _configuracion.ObtenerMetodo("ApiEndPointsPeliculasBuscar", "ObtenerPeliculasPorId");
            var servicioPeliculaFav = _httpClient.CreateClient("servicioPeliculaFav");
            var token = _configuracion.ObtenerValor("TokenServicioPeliculas");
            servicioPeliculaFav.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var resultados = await ObtenerListaTareas(peliculasFavTask, servicioPeliculaFav, endPoint, opciones);
            return resultados;
        }
        private async Task<IEnumerable<PeliculaFavResponse>> ObtenerListaTareas(Task<IEnumerable<PeliculaFavResponse>> peliculasFavTask, HttpClient servicioPeliculaFav, string endPoint, JsonSerializerOptions opciones)
        {
            var peliculasFav = await peliculasFavTask;
            var tareas = peliculasFav.Select(async pelicula =>
            {
                var url = string.Format(endPoint, pelicula.IdPelicula);
                var respuesta = await servicioPeliculaFav.GetAsync(url);
                respuesta.EnsureSuccessStatusCode();
                var contenido = await respuesta.Content.ReadAsStringAsync();
                var datosApi = JsonSerializer.Deserialize<PeliculaApiResponse>(contenido, opciones);
                return new PeliculaFavResponse
                {
                    IdPelicula = pelicula.IdPelicula,
                    IdPeliculaFav = pelicula.IdPeliculaFav,
                    Puntuacion = pelicula.Puntuacion,
                    Comentario = pelicula.Comentario,
                    Titulo = datosApi.Titulo,
                    Imagen = datosApi.Imagen,
                    Descripcion = datosApi.Descripcion,
                    Fecha = datosApi.Fecha
                };
            });

            return await Task.WhenAll(tareas);
        }
        private async Task<IEnumerable<PeliculaFavResponse>> ObtenerListaPeliculasFav(string username)
        {
            return await _peliculaFavDA.Obtener(username);
        }





    }
}
