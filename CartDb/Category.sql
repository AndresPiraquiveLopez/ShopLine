CREATE TABLE [dbo].[Category]
(
	[CategoryId] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
	[CategoryName] VARCHAR (50)    NOT NULL DEFAULT ('')
)
