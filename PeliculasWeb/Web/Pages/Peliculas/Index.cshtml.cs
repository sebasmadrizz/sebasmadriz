using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos.Peliculas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Web.Pages.Peliculas
{
    public class IndexModel : PageModel
    {
        private IConfiguracion _configuracion;
        public IList<Pelicula> peliculas { get; set; } = default!;
        [BindProperty]
        public PeliculaFav peliculaFav { get; set; }

        public IndexModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        public async Task OnPost(int? id)
        {
            string endpoint = _configuracion.ObtenerMetodo("EndPointsPeliculas", "ObtenerPeliculas");
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, string.Format(endpoint, id));
            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();
            if (respuesta.StatusCode == HttpStatusCode.OK)
            {
                var resultado = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                peliculas = JsonSerializer.Deserialize<List<Pelicula>>(resultado, opciones);

            }

        }
        public async Task<IActionResult> OnPostPeliFav()
        {
            if (!TryValidateModel(peliculaFav, nameof(peliculaFav)))
            {
                return Partial("_FormularioModalPeliFav", peliculaFav);
            }


            string endpoint = _configuracion.ObtenerMetodo("EndPointsPeliculasFav", "AgregarPeliFav");
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Post, endpoint);
            var respuesta = await cliente.PostAsJsonAsync(endpoint, peliculaFav);

            if (!respuesta.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Error al guardar el producto.");
                return Partial("_FormularioModalPeliFav", new PeliculaFav());
            }

            return new JsonResult(new { success = true });
        }
        public IActionResult OnGetFormularioModal(int id)
        {
            var peliculaFav = new PeliculaFav { IdPelicula=id};

            return Partial("_FormularioModalPeliFav", peliculaFav);



        }
    }
}