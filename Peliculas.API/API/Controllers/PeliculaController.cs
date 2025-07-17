using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaController : ControllerBase, IPeliculaController
    {
        private IPeliculaFlujo _peliculaFlujo;
        private ILogger<PeliculaController> _logger;

        public PeliculaController(IPeliculaFlujo peliculaFlujo, ILogger<PeliculaController> logger)
        {
            _peliculaFlujo = peliculaFlujo;
            _logger = logger;
        }
        [HttpGet("{idGenero}")]
        public async Task<IActionResult> ObtenerPeliculasXGenero([FromRoute] int idGenero)
        {
            var resultado = await _peliculaFlujo.ObtenerPeliculasXGenero(idGenero);
            return Ok(resultado);
        }
    }
}
