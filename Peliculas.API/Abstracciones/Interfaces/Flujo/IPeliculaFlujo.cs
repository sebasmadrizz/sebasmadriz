using Abstracciones.Modelos.Servicios.Peliculas;

namespace Abstracciones.Interfaces.Flujo
{
    public interface IPeliculaFlujo
    {
        Task<IEnumerable<PeliculaResponseEs>> ObtenerPeliculasXGenero(int idGenero);

    }
}
