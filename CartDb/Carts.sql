CREATE TABLE [dbo].[Carts]
(
	[CartId] VARCHAR(150) NOT NULL PRIMARY KEY,
	[UserId] VARCHAR(150),
	[DateCreated] DATE NULL DEFAULT getdate()
)
