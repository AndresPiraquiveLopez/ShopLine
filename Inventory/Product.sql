CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
	[CategoryId] INT NOT NULL ,
    [Code] VARCHAR(100) NOT NULL,  
	[Name] VARCHAR(100) NOT NULL,
	[Cost]  DECIMAL (18, 2) NOT NULL DEFAULT 0 ,
	[SellPrice]  DECIMAL (18, 2) NOT NULL DEFAULT 0 ,
	 [Qty] INT NULL DEFAULT 0, 
    CONSTRAINT [FK_CategoryId_ProductCategory] FOREIGN KEY ([CategoryId]) REFERENCES [ProductCategory]([Id])
		
)
