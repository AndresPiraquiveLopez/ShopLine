CREATE TABLE [dbo].[ProductCategory]
(
	[Id] INT NOT NULL PRIMARY KEY 	IDENTITY (1,1),
	[Category]  VARCHAR (50)    NOT NULL DEFAULT ('')
)
