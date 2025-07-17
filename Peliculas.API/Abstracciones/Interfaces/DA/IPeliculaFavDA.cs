    using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.DA
{
    public interface IPeliculaFavDA
    {
        Task<IEnumerable<PeliculaFavResponse>> Obtener(string username);
        Task<PeliculaFavResponse> Obtener(Guid IdPeliculaFav);
        Task<Guid> Agregar(PeliculaFavRequest peliculaFav);
        Task<Guid> Editar(Guid IdPeliculaFav, PeliculaFavRequest peliculaFav);
        Task<Guid> Eliminar(Guid IdPeliculaFav);
    }
}
