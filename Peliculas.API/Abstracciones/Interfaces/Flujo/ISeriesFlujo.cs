using Abstracciones.Modelos.Servicios.Series;

namespace Abstracciones.Interfaces.Flujo
{
    public interface ISeriesFlujo
    {
        Task<IEnumerable<SerieResponseEs>> ObtenerSeriesXGenero(int idGenero);

    }
}
