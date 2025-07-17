namespace Abstracciones.Modelos.Peliculas
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Imagen { get; set; }
        public string? Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Calificacion { get; set; }
    }
    public class PeliculaFav
    {
        public int Puntuacion { get; set; }
        public string? Comentario { get; set; }
        public int IdPelicula { get; set; }
        public string? Username { get; set; }
    }
    public class PeliculaFavResponse
    {
        public int IdPelicula { get; set; }
        public Guid IdPeliculaFav { get; set; } 
        public string Titulo { get; set; } 
        public string Imagen { get; set; } 
        public string Descripcion { get; set; } 
        public DateTime Fecha { get; set; }
        public int Puntuacion { get; set; }
        public string Comentario { get; set; } 

    }
}
