using Abstracciones.Modelos.Servicios.Peliculas;

namespace Abstracciones.Interfaces.Servicios
{
    public interface IPeliculasServicio
    {
        Task<IEnumerable<PeliculaResponseEs>> ObtenerPeliculasXGenero(int idGenero);

    }
}
