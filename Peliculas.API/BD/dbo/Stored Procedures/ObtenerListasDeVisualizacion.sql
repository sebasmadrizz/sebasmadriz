CREATE PROCEDURE ObtenerListasDeVisualizacion
@username NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        Id,             
        IdPelicula, 
        Prioridad
    FROM ListaDeVisualizacion
    WHERE Username = @username;
END

