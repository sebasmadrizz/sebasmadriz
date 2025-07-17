﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.Servicios
{
	public interface IListaDeVisualizacionServicio
	{
		Task<IEnumerable<ListaDeVisualizacionResponse>> ObtenerListaDeVisualizacion(string username);
	}
}
