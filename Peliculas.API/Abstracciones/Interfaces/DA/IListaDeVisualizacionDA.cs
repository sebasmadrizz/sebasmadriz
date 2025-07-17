using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.DA
{
	public interface IListaDeVisualizacionDA
	{
		Task<IEnumerable<ListaDeVisualizacionResponse>> Obtener(string username);
		Task<ListaDeVisualizacionResponse> Obtener(Guid Id);
		Task<Guid> Agregar(ListaDeVisualizacionRequest listaDeVisualizacion);
		Task<Guid> Editar(Guid Id, ListaDeVisualizacionRequest listaDeVisualizacion);
		Task<Guid> Eliminar(Guid Id);

    }
}
