using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DA
{
	public class ListaDeVisualizacionDA : IListaDeVisualizacionDA
	{
		private IRepositorioDapper _repositorioDapper;
		private SqlConnection _sqlConnection;

		public ListaDeVisualizacionDA(IRepositorioDapper repositorioDapper)
		{
			_repositorioDapper = repositorioDapper;
			_sqlConnection = _repositorioDapper.ObtenerRepositorio();
		}

		public async Task<Guid> Agregar(ListaDeVisualizacionRequest listaDeVisualizacion)
		{
			string query = @"AgregarListaDeVisualizacion";
			var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
			{
				Id = Guid.NewGuid(),
				IdPelicula = listaDeVisualizacion.IdPelicula,
				Prioridad=listaDeVisualizacion.Prioridad,
				Username = listaDeVisualizacion.Username,

			});
			return resultadoConsulta;
		}


        public async Task<Guid> Editar(Guid Id, ListaDeVisualizacionRequest listaDeVisualizacion)
        {
            await verificarExisteEnLista(Id);

            string query = @"EditarListaDeVisualizacion"; 

            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Id,
                Prioridad = listaDeVisualizacion.Prioridad
            });

            return resultadoConsulta;
        }


        public async Task<Guid> Eliminar(Guid Id)
		{
			await verificarExisteEnLista(Id);
			string query = @"EliminarListaDeVisualizacion";
			var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
			{
				Id = Id

			});
			return resultadoConsulta;
		}

		public async Task<IEnumerable<ListaDeVisualizacionResponse>> Obtener(string username)
		{
			string query = @"ObtenerListasDeVisualizacion";
			var resultadoConsulta = await _sqlConnection.QueryAsync<ListaDeVisualizacionResponse>(query,
				 new { Username = username });
			return resultadoConsulta;
		}

		public async Task<ListaDeVisualizacionResponse> Obtener(Guid Id)
		{
			string query = @"ObtenerListaDeVisualizacion";
			var resultadoConsulta = await _sqlConnection.QueryAsync<ListaDeVisualizacionResponse>(query, new { Id = Id });
			return resultadoConsulta.FirstOrDefault();
		}



		#region Helpers
		private async Task verificarExisteEnLista(Guid Id)
		{
			ListaDeVisualizacionResponse? resultadoConsulta = await Obtener(Id);
			if (resultadoConsulta == null)
				throw new Exception("La pelicula/serie no está en lista");
		}
		#endregion
	}
}
