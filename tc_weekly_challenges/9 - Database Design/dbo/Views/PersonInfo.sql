CREATE VIEW [dbo].[PersonInfo]
	AS 
	SELECT [p].[Id], [p].[FirstName], [p].[MiddleName], [p].[LastName], [a].[StreetName], [a].[City], [a].[Province]
	FROM Person p
	LEFT JOIN Address a ON a.PersonId = p.Id
