using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaFavController : ControllerBase, IPeliculaFavController
    {
        private IPeliculaFavFlujo _peliculaFavFlujo;
        private ILogger<PeliculaFavController> _logger;

        public PeliculaFavController(IPeliculaFavFlujo peliculaFavFlujo, ILogger<PeliculaFavController> logger)
        {
            _peliculaFavFlujo = peliculaFavFlujo;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Agregar([FromBody]PeliculaFavRequest peliculaFav)
        {
                var resultado = await _peliculaFavFlujo.Agregar(peliculaFav);
                return CreatedAtAction(nameof(Obtener), new { IdPeliculaFav = resultado }, null);
        }

        [HttpPut("{IdPeliculaFav}")]
        public async Task<IActionResult> Editar([FromRoute]Guid IdPeliculaFav, [FromBody]PeliculaFavRequest peliculaFav)
        {
            if (!await VerificarPeliculaExiste(IdPeliculaFav))
                return NotFound("la pelicula no existe");
            var resultado = await _peliculaFavFlujo.Editar(IdPeliculaFav, peliculaFav);
            return Ok(resultado);
        }


        [HttpDelete("{IdPeliculaFav}")]
        public async Task<IActionResult> Eliminar([FromRoute]Guid IdPeliculaFav)
        {
            if (!await VerificarPeliculaExiste(IdPeliculaFav))
                return NotFound("la pelicula no existe");
            var resultado = await _peliculaFavFlujo.Eliminar(IdPeliculaFav);
            return NoContent();
        }


        [HttpGet("porUser/{username}")]
        public async Task<IActionResult> Obtener([FromRoute]string username)
        {
            var resultado = await _peliculaFavFlujo.Obtener(username);
            if (!resultado.Any())
                return NoContent();
            return Ok(resultado);
        }

        [HttpGet("porId/{IdPeliculaFav}")]

        public async Task<IActionResult> Obtener([FromRoute] Guid IdPeliculaFav)
        {
            var resultado = await _peliculaFavFlujo.Obtener(IdPeliculaFav);
            return Ok(resultado);
        }


        private async Task<bool> VerificarPeliculaExiste(Guid IdPeliculaFav)
        {
            var ResultadoValidacion = false;
            var resultadoPeliculaExiste = await _peliculaFavFlujo.Obtener(IdPeliculaFav);
            if (resultadoPeliculaExiste != null)
                ResultadoValidacion = true;
            return ResultadoValidacion;
        }

    }

}
