CREATE TABLE [dbo].[CartItem]
(
	[ItemId] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [CartId] INT NULL, 
    [Quantity] INT NULL, 
    [DateCreated] DATE NULL DEFAULT getdate(), 
    [ProductId] INT NULL, 
    CONSTRAINT [FK_CartItem_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product]([ProductId]),
)
