CREATE TABLE [dbo].[Category]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [CategoryName] VARBINARY(50) NULL, 
    [CatalogId] INT NOT NULL, 
    CONSTRAINT [FK_Category_Catalog] FOREIGN KEY ([CatalogId]) REFERENCES [Catalog]([Id])
)
