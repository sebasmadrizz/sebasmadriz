-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE EliminarPeliculaFav
	-- Add the parameters for the stored procedure here
	@IdPeliculaFav uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	begin transaction
DELETE
FROM           PeliculaFav
                 
WHERE        (IdPeliculaFav = @IdPeliculaFav)
SELECT @IdPeliculaFav 
commit transaction
END