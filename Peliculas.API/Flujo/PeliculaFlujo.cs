using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos;
using Abstracciones.Modelos.Servicios.Peliculas;

namespace Flujo
{
    public class PeliculaFlujo : IPeliculaFlujo
    {
        private readonly IPeliculasServicio _peliculaServicio;

        public PeliculaFlujo(IPeliculasServicio peliculaServicio)
        {
            _peliculaServicio = peliculaServicio;
        }

        public async Task<IEnumerable<PeliculaResponseEs>> ObtenerPeliculasXGenero(int idGenero)
        {
            var pelicula = await _peliculaServicio.ObtenerPeliculasXGenero(idGenero);
            
            return pelicula;
        }
    }
}
