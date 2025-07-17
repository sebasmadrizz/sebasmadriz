  CREATE TABLE [dbo].[PeliculaFav] (
    [IdPeliculaFav] uniqueIdentifier  PRIMARY KEY,
    [username] NVARCHAR(100) NOT NULL,
    [IdPelicula] INT NOT NULL,
    [Puntuacion] INT NOT NULL,
    [Comentario] NVARCHAR(MAX) NULL
);