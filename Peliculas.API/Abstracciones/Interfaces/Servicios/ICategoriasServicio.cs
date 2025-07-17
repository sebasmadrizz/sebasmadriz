using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstracciones.Modelos.Servicios.Categorias;
using Abstracciones.Modelos.Servicios.Peliculas;

namespace Abstracciones.Interfaces.Servicios
{
	public interface ICategoriasServicio
	{
		Task<IEnumerable<CategoriasResponse>> ObtenerCategoriasDeSeries();
        Task<IEnumerable<CategoriasResponse>> ObtenerCategoriasDePeliculas();
    }
}
