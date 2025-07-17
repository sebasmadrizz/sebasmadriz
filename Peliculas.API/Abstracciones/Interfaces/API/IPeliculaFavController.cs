using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Abstracciones.Interfaces.API
{
    public interface IPeliculaFavController
    {
        Task<IActionResult> Obtener(string username);
        Task<IActionResult> Obtener(Guid IdPeliculaFav);
        Task<IActionResult> Agregar(PeliculaFavRequest peliculaFav);
        Task<IActionResult> Editar(Guid IdPeliculaFav, PeliculaFavRequest peliculaFav);
        Task<IActionResult> Eliminar(Guid IdPeliculaFav);
    }
}
