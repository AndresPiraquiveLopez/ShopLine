CREATE TABLE [dbo].[Products]
(
	[ProductId] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [CategoryId] INT NULL, 
    [ProductName] VARCHAR(50) NULL, 
    [ImagePath] VARCHAR(50) NULL, 
    [UnitPrice] DECIMAL(18, 2) NULL DEFAULT 0, 
    CONSTRAINT [FK_Categories_Products] FOREIGN KEY ([CategoryId]) REFERENCES [Categories]([CategoryId])

)
