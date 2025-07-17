using System.Text.Json.Serialization;

namespace Abstracciones.Modelos.Servicios.Series
{
    public class SeriesBase
    {
       
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("original_name")]
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

    public class SerieResponseEs
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Imagen { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Calificacion { get; set; }
    }


    public class SeriesApiResponse
    {
        [JsonPropertyName("results")]
        public List<SeriesBase> Results { get; set; }
    }
}
