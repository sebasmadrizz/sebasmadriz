using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos.Peliculas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Text.Json;

namespace Web.Pages.Peliculas
{
    public class verPeliculasFavModel : PageModel
    {
        private IConfiguracion _configuracion;
        public IList<PeliculaFavResponse> peliculasFav { get; set; } = default!;
        public verPeliculasFavModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }
        public async Task OnPost(string? username)
        {
            string endpoint = _configuracion.ObtenerMetodo("EndPointsPeliculasFav", "ObtenerPelisFav");
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, string.Format(endpoint, username));
            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();
            if (respuesta.StatusCode == HttpStatusCode.OK)
            {
                var resultado = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                peliculasFav = JsonSerializer.Deserialize<List<PeliculaFavResponse>>(resultado, opciones);

            }

        }
    }
}
