using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.Flujo
{
	public interface IListaDeVisualizacionFlujo
	{
		
		Task<IEnumerable<ListaDeVisualizacionResponse>> Obtener(string username);
		Task<ListaDeVisualizacionResponse> Obtener(Guid id);
		Task<Guid> Agregar(ListaDeVisualizacionRequest listaDeVisualizacion);
		Task<Guid> Editar(Guid id, ListaDeVisualizacionRequest listaDeVisualizacion);
		Task<Guid> Eliminar(Guid id);
	}
}
