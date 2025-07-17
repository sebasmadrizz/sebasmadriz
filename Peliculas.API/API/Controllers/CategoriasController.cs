using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{	
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriasController : ControllerBase, ICategoriasController
	{
		private ICategoriasFlujo _categoriasFlujo;
		private ILogger<CategoriasController> _logger;
		public CategoriasController(ICategoriasFlujo categoriasFlujo, ILogger<CategoriasController> logger)
		{
			_categoriasFlujo = categoriasFlujo;
			_logger = logger;
		}
		[HttpGet("series")]
		public async Task<IActionResult> ObtenerCategoriasDeSeries()
		{
			var resultado = await _categoriasFlujo.ObtenerCategoriasDeSeries();
			return Ok(resultado);
		}

        [HttpGet("peliculas")]
        public async Task<IActionResult> ObtenerCategoriasDePeliculas()
        {
            var resultado = await _categoriasFlujo.ObtenerCategoriasDePeliculas();
            return Ok(resultado);
        }
    }
	
	}
