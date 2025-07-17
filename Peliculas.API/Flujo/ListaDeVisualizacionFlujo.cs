using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos;

namespace Flujo
{
	public class ListaDeVisualizacionFlujo : IListaDeVisualizacionFlujo
	{
		private readonly IListaDeVisualizacionDA _listaDeVisualizacionDA;
		private IListaDeVisualizacionServicio _listaDeVisualizacionServicio;

        public ListaDeVisualizacionFlujo(IListaDeVisualizacionDA listaDeVisualizacionDA, IListaDeVisualizacionServicio listaDeVisualizacionServicio)
		{
			_listaDeVisualizacionDA = listaDeVisualizacionDA;
            _listaDeVisualizacionServicio= listaDeVisualizacionServicio;
        }
		public async Task<Guid> Agregar(ListaDeVisualizacionRequest listaDeVisualizacion)
		{
			return await _listaDeVisualizacionDA.Agregar(listaDeVisualizacion);
		}

		public async Task<Guid> Eliminar(Guid id)
		{
			return await _listaDeVisualizacionDA.Eliminar(id);
		}

		public  async Task<IEnumerable<ListaDeVisualizacionResponse>> Obtener(string username)
		{
			return await _listaDeVisualizacionServicio.ObtenerListaDeVisualizacion(username);
		}

		public async Task<ListaDeVisualizacionResponse> Obtener(Guid Id)
		{
			var lista = await _listaDeVisualizacionDA.Obtener(Id);
			
			return lista;
		}
        public async Task<Guid> Editar(Guid id, ListaDeVisualizacionRequest listaDeVisualizacion)
        {
            return await _listaDeVisualizacionDA.Editar(id, listaDeVisualizacion);
        }
    }
}
