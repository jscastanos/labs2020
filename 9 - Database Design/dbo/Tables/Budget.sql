CREATE TABLE [dbo].[Budget]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PersonId] INT NOT NULL, 
    [Amount] MONEY NOT NULL, 
    CONSTRAINT [FK_Budget_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [Person]([Id])
)
