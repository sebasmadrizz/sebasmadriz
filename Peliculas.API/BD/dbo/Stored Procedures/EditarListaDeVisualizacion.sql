CREATE PROCEDURE EditarListaDeVisualizacion
	@Id UNIQUEIDENTIFIER,
	@Prioridad NVARCHAR(50)
AS
BEGIN
	UPDATE ListaDeVisualizacion
	SET Prioridad = @Prioridad
	WHERE Id = @Id
END

