CREATE TABLE [dbo].[ProductInventory]
(
	[ProductId] INT NOT NULL, 
    [LocationId] INT NOT NULL, 
    [Count] DECIMAL NULL,
	PRIMARY KEY (ProductId,LocationId)
)
