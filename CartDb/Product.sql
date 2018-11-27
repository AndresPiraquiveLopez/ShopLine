CREATE TABLE [dbo].[Product]
(
	[ProductId] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [CategoryId] INT NULL, 
    [ProductName] VARCHAR(50) NULL, 
    [ImagePath] VARCHAR(50) NULL, 
    [UnitPrice] DECIMAL(18, 2) NULL DEFAULT 0, 
    CONSTRAINT [FK_Category_Product] FOREIGN KEY ([CategoryId]) REFERENCES [Category]([CategoryId])

)
