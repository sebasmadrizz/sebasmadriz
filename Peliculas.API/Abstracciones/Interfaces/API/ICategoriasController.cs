using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Abstracciones.Interfaces.API
{
	public interface ICategoriasController
	{
		Task<IActionResult> ObtenerCategoriasDeSeries();
	}
}
