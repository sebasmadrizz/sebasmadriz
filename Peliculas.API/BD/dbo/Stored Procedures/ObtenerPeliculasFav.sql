CREATE PROCEDURE ObtenerPeliculasFav
@username NVARCHAR(100)
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
    IdPeliculaFav,
    IdPelicula,
    Puntuacion,
    Comentario
FROM PeliculaFav
WHERE Username = @Username
                 
END