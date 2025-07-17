using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Abstracciones.Interfaces.API
{
	public interface IListaDeVisualizacionController
	{
		
		Task<IActionResult> Agregar(ListaDeVisualizacionRequest listaDeVisualizacion);

		Task<IActionResult> Obtener(string username);

		Task<IActionResult> Obtener(Guid id);

        Task<IActionResult> Editar(Guid id, ListaDeVisualizacionRequest listaDeVisualizacion);
		Task<IActionResult> Eliminar(Guid id);

	}
}
