using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Abstracciones.Modelos
{

    public class PeliculaFavBase
    {
        [Required]
        [Range(1, 10, ErrorMessage = "La puntuación debe estar entre 1 y 10")]
        public int Puntuacion { get; set; }

        public string Comentario { get; set; }
    }

    public class PeliculaFavRequest : PeliculaFavBase
    {
        public int IdPelicula { get; set; }

        [Required]
        public string Username { get; set; }
    }

    public class PeliculaFavResponse : PeliculaFavBase
    {
        public int IdPelicula { get; set; }
        public Guid IdPeliculaFav { get; set; }
        public string Titulo { get; set; }
        public string Imagen { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
    }
    public class PeliculaApiResponse
    {
        [JsonPropertyName("original_title")]
        public string Titulo { get; set; }

        [JsonPropertyName("poster_path")]
        public string Imagen { get; set; }

        [JsonPropertyName("overview")]
        public string Descripcion { get; set; }

        [JsonPropertyName("release_date")]
        public DateTime Fecha { get; set; }
    }
}
