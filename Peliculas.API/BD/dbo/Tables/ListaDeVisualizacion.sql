CREATE TABLE [dbo].[ListaDeVisualizacion]
(
	[Id]  uniqueIdentifier  PRIMARY KEY ,
	[IdPelicula] INT NOT NULL,
	[Prioridad] NVARCHAR(MAX) NOT NULL, 
    [username] NVARCHAR(100) NOT NULL
	
)



