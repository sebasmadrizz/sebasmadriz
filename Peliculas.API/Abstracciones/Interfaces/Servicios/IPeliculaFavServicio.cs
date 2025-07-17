using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.Servicios
{
    public interface IPeliculaFavServicio
    {
        Task<IEnumerable<PeliculaFavResponse>> ObtenerPeliculasFav(string username);
        
    }
}
