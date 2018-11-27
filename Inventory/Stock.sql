CREATE TABLE [dbo].[Stock]
(
	[StockId] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [ProductId] INT NULL, 
    [Qty] INT NULL,
	CONSTRAINT [FK_ProductId_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product]([ProductId])
)
