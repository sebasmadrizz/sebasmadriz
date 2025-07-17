using Abstracciones.Modelos.Servicios.Series;

namespace Abstracciones.Interfaces.Servicios
{
    public interface ISeriesServicio
    {
        Task<IEnumerable<SerieResponseEs>> ObtenerSeriesXGenero(int idGenero);
    }
}
