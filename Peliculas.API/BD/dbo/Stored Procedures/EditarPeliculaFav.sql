CREATE PROCEDURE EditarPeliculaFav
    @IdPeliculaFav UNIQUEIDENTIFIER,
    @Puntuacion INT,
    @Comentario NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE PeliculaFav
    SET 
        Puntuacion = @Puntuacion,
        Comentario = @Comentario
    WHERE IdPeliculaFav = @IdPeliculaFav
END
