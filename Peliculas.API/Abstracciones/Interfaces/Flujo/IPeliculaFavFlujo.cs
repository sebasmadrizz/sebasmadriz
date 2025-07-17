using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.Flujo
{
    public interface IPeliculaFavFlujo
    {
        Task<IEnumerable<PeliculaFavResponse>> Obtener(string username);
        Task<PeliculaFavResponse> Obtener(Guid idIdPeliculaFav);
        Task<Guid> Agregar(PeliculaFavRequest peliculaFav);
        Task<Guid> Editar(Guid IdPeliculaFav, PeliculaFavRequest peliculaFav);
        Task<Guid> Eliminar(Guid IdPeliculaFav);
        
    }
}
