using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos;

namespace Flujo
{
    public class PeliculasFavFlujo : IPeliculaFavFlujo
    {
        private readonly IPeliculaFavDA _peliculaFavDA;
        private readonly IPeliculaFavServicio _peliculaFavServicio;


        public PeliculasFavFlujo(IPeliculaFavDA peliculaFavDA, IPeliculaFavServicio peliculaFavServicio)
        {
            _peliculaFavDA = peliculaFavDA;
            _peliculaFavServicio = peliculaFavServicio;


        }

        public async Task<Guid> Agregar(PeliculaFavRequest peliculaFav)
        {
            return await _peliculaFavDA.Agregar(peliculaFav);
        }

        public async Task<Guid> Editar(Guid IdPeliculaFav, PeliculaFavRequest peliculaFav)
        {
            return await _peliculaFavDA.Editar(IdPeliculaFav, peliculaFav);
        }

        public async Task<Guid> Eliminar(Guid IdPeliculaFav)
        {
            return await _peliculaFavDA.Eliminar(IdPeliculaFav);
        }

        public async Task<IEnumerable<PeliculaFavResponse>> Obtener(string username)
        {
            return await _peliculaFavServicio.ObtenerPeliculasFav(username);
            
        }

        public async Task<PeliculaFavResponse> Obtener(Guid IdPeliculaFav)
        {
            return await _peliculaFavDA.Obtener(IdPeliculaFav);
        }
    }
}
