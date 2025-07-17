CREATE PROCEDURE AgregarPeliculaFav
	-- Add the parameters for the stored procedure here
	@IdPeliculaFav UNIQUEIDENTIFIER,
	@username NVARCHAR(100),
	@IdPelicula int,
	@Puntuacion  int,
	@Comentario  varchar(MAX)
	
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	BEGIN TRANSACTION;
INSERT INTO [dbo].PeliculaFav
           (IdPeliculaFav,
		   username,
		   IdPelicula
           ,Puntuacion
           ,Comentario)
     VALUES
           (@IdPeliculaFav,
		   @username,
		   @IdPelicula,
	@Puntuacion 
	,@Comentario)
	SELECT @IdPeliculaFav
	COMMIT TRANSACTION;
END