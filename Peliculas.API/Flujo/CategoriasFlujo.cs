using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos.Servicios.Categorias;


namespace Flujo
{
	public class CategoriasFlujo: ICategoriasFlujo
	{
		private readonly ICategoriasServicio _categoriasServicio;

		public CategoriasFlujo(ICategoriasServicio categoriasServicio)
		{
			_categoriasServicio = categoriasServicio;
		}

		public async Task<IEnumerable<CategoriasResponse>> ObtenerCategoriasDeSeries()
		{
			var categoriasDeSeries = await _categoriasServicio.ObtenerCategoriasDeSeries();

			return categoriasDeSeries;
		}
        public async Task<IEnumerable<CategoriasResponse>> ObtenerCategoriasDePeliculas()
        {
            var categoriasDePeliculas = await _categoriasServicio.ObtenerCategoriasDePeliculas();
            return categoriasDePeliculas;
        }
    }
}
