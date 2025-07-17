using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ListaDeVisualizacionController : ControllerBase, IListaDeVisualizacionController
	{
		private IListaDeVisualizacionFlujo _listaDeVisualizacionFlujo;
		private ILogger<ListaDeVisualizacionController> _logger;

		public ListaDeVisualizacionController(IListaDeVisualizacionFlujo listaDeVisualizacionFlujo, ILogger<ListaDeVisualizacionController> logger)
		{
			_listaDeVisualizacionFlujo = listaDeVisualizacionFlujo;
			_logger = logger;
		}


		[HttpPost]
		public async Task<IActionResult> Agregar([FromBody] ListaDeVisualizacionRequest listaDeVisualizacion)
		{
			var resultado = await _listaDeVisualizacionFlujo.Agregar(listaDeVisualizacion);
			return CreatedAtAction(nameof(Obtener), new { Id = resultado }, null);
		}

		[HttpDelete("{Id}")]
		public async Task<IActionResult> Eliminar([FromRoute] Guid Id)
		{
			if (!await VerificarExisteEnLista(Id))
				return NotFound($"La pelicula/serie no está en lista");
			var resultado = await _listaDeVisualizacionFlujo.Eliminar(Id);
			return NoContent();
		}

		[HttpGet("porUser/{username}")]
		public async Task<IActionResult> Obtener([FromRoute] string username)
		{
			var resultado = await _listaDeVisualizacionFlujo.Obtener(username);
			if (!resultado.Any())
				return NoContent();
			return Ok(resultado);
		}

		[HttpGet("{Id}")]
		public async Task<IActionResult> Obtener([FromRoute] Guid Id)
		{
			if (!await VerificarExisteEnLista(Id))
				return NotFound($"La pelicula/serie no está en lista");
			var resultado = await _listaDeVisualizacionFlujo.Obtener(Id);
			return Ok(resultado);
		}

        [HttpPut("{Id}")]
        public async Task<IActionResult> Editar([FromRoute] Guid Id, [FromBody] ListaDeVisualizacionRequest listaDeVisualizacion)
        {
            if (!await VerificarExisteEnLista(Id))
                return NotFound($"La pelicula/serie ingresada no está en la lista");

            var resultado = await _listaDeVisualizacionFlujo.Editar(Id, listaDeVisualizacion);
            return Ok(new { mensaje = "Película o serie actualizada correctamente", resultado });
        }

		#region helpers
		private async Task<bool> VerificarExisteEnLista(Guid Id)
		{
			var resultadoValidacion = false;
			var resultadoExiste = await _listaDeVisualizacionFlujo.Obtener(Id);
			if (resultadoExiste != null)
				resultadoValidacion = true;
			return resultadoValidacion;
		}
		#endregion
	}

}

