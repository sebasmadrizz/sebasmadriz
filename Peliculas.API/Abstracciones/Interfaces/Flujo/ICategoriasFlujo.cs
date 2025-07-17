using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstracciones.Modelos.Servicios.Categorias;


namespace Abstracciones.Interfaces.Flujo
{
	public interface ICategoriasFlujo
	{
		Task<IEnumerable<CategoriasResponse>> ObtenerCategoriasDeSeries();
        Task<IEnumerable<CategoriasResponse>> ObtenerCategoriasDePeliculas();
    }
}
