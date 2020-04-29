CREATE VIEW [dbo].[Purchased]
	AS 
	SELECT
		p.Id, p.FirstName, p.MiddleName, p.LastName,
		b.Amount,
		b.Amount - SUM(pu.Amount) AS RemainingBudget
	FROM Person p
	INNER JOIN Budget b ON b.PersonId = p.Id
	INNER JOIN Purchase pu ON pu.PersonId = p.Id
	GROUP BY p.Id, p.FirstName, p.MiddleName, p.LastName, b.Amount