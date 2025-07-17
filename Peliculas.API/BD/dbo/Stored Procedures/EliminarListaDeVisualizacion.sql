CREATE PROCEDURE EliminarListaDeVisualizacion 
	@Id UNIQUEIDENTIFIER

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Begin Transaction
		Delete 
		FROM ListaDeVisualizacion 
		Where (ListaDeVisualizacion.Id=@Id)
		select @Id
	commit transaction
END