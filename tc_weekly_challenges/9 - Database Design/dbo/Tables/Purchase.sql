CREATE TABLE [dbo].[Purchase]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PersonId] INT NOT NULL, 
    [ItemName] NVARCHAR(50) NOT NULL, 
    [Amount] MONEy NOT NULL,
    [Quantity] INT NULL DEFAULT 1, 
    CONSTRAINT [FK_Purchase_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [Person]([Id]), 
)
