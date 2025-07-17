using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase, ISeriesController
    {
        private ISeriesFlujo _seriesFlujo;
        private ILogger<SeriesController> _logger;

        public SeriesController(ISeriesFlujo seriesFlujo, ILogger<SeriesController> logger)
        {
            _seriesFlujo = seriesFlujo;
            _logger = logger;
        }
        [HttpGet("{idGenero}")]
        public async Task<IActionResult> ObtenerSeriesXGenero([FromRoute] int idGenero)
        {
            var resultado = await _seriesFlujo.ObtenerSeriesXGenero(idGenero);
            return Ok(resultado);
        }
    }
}
