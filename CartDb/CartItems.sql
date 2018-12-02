CREATE TABLE [dbo].[CartItems]
(
	[ItemId] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [CartId] VARCHAR(150) NULL, 
    [Quantity] INT NULL DEFAULT 1, 
    [DateCreated] DATE NULL DEFAULT getdate(), 
    [ProductId] INT NULL, 
    CONSTRAINT [FK_CartItems_Products] FOREIGN KEY ([ProductId]) REFERENCES [Products]([ProductId]),
    CONSTRAINT [FK_CartItems_Carts] FOREIGN KEY ([CartId]) REFERENCES [Carts]([CartId])
)
