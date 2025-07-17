using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Abstracciones.Modelos.Servicios.Peliculas
{
    public class PeliculaApiBase
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("original_title")]
        public string Titulo { get; set; }

        [JsonPropertyName("poster_path")]
        public string Imagen { get; set; }

        [JsonPropertyName("overview")]
        public string Descripcion { get; set; }

        [JsonPropertyName("release_date")]
        public DateTime Fecha { get; set; }

        [JsonPropertyName("vote_average")]
        public decimal Calificacion { get; set; }
    }

    public class PeliculasApiResponse
    {
        [JsonPropertyName("results")]
        public List<PeliculaApiBase> Results { get; set; }
    }

    public class PeliculaResponseEs
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Imagen { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Calificacion { get; set; }
    }
}


