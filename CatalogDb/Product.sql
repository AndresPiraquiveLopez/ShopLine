CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [ProductName] VARBINARY(50) NULL, 
    [CategoryId] INT NOT NULL, 
    CONSTRAINT [FK_Product_Category] FOREIGN KEY ([CategoryId]) REFERENCES [Category]([Id])
	
)
