using System;
using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Azure.Identity;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DA
{
    public class PeliculaFavDA : IPeliculaFavDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        public PeliculaFavDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorio();
        }

        public async Task<Guid> Agregar(PeliculaFavRequest peliculaFav)
        {
            string query = @"AgregarPeliculaFav";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                IdPeliculaFav = Guid.NewGuid(),
                Username = peliculaFav.Username,
                IdPelicula = peliculaFav.IdPelicula,
                Puntuacion = peliculaFav.Puntuacion,
                Comentario = peliculaFav.Comentario
            });
            return resultadoConsulta;
        }

        public async Task<Guid> Editar(Guid IdPeliculaFav, PeliculaFavRequest peliculaFav)
        {
            await VerificarPeliculaExiste(IdPeliculaFav);
            string query = @"EditarPeliculaFav";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                IdPeliculaFav = IdPeliculaFav,
                Puntuacion = peliculaFav.Puntuacion,
                Comentario = peliculaFav.Comentario
            });
            return resultadoConsulta;
        }

        public async Task<Guid> Eliminar(Guid IdPeliculaFav)
        {
            await VerificarPeliculaExiste(IdPeliculaFav);
            string query = @"EliminarPeliculaFav";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                IdPeliculaFav = IdPeliculaFav
            });
            return resultadoConsulta;
        }

        public async Task<IEnumerable<PeliculaFavResponse>> Obtener(string username)
        {
            string query = @"ObtenerPeliculasFav";
            var resultadoConsulta = await _sqlConnection.QueryAsync<PeliculaFavResponse>(query,
                 new { Username = username });
            return resultadoConsulta;
        }

        public async Task<PeliculaFavResponse> Obtener(Guid IdPeliculaFav)
        {
            string query = @"ObtenerPeliculaFav";
            var resultadoConsulta = await _sqlConnection.QueryAsync<PeliculaFavResponse>(query,
                new { IdPeliculaFav = IdPeliculaFav });
            return resultadoConsulta.FirstOrDefault();
        }
        private async Task VerificarPeliculaExiste(Guid IdPeliculaFav)
        {
            PeliculaFavResponse? resutadoConsultaPelicula = await Obtener(IdPeliculaFav);
            if (resutadoConsultaPelicula == null)
                throw new Exception("no se encontro la pelicula");
        }
    }
}
