CREATE PROCEDURE ObtenerListaDeVisualizacion
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        Id, 
        IdPelicula,
        Prioridad
        
    FROM ListaDeVisualizacion
    WHERE Id = @Id;
END
