using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos;
using Abstracciones.Modelos.Servicios.Peliculas;
using Abstracciones.Modelos.Servicios.Series;

namespace Flujo
{
    public class SeriesFlujo : ISeriesFlujo
    {
        private readonly ISeriesServicio _seriesServicio;

        public SeriesFlujo(ISeriesServicio seriesServicio)
        {
            _seriesServicio = seriesServicio;
        }

        public async Task<IEnumerable<SerieResponseEs>> ObtenerSeriesXGenero(int idGenero)
        {
            var series = await _seriesServicio.ObtenerSeriesXGenero(idGenero);
            
            return series;
        }
    }
}
