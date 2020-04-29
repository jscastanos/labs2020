CREATE PROCEDURE [dbo].[spPurchase_Get]
	@PersonId int
AS
BEGIN
	SELECT pu.*
	FROM Purchase pu
	WHERE pu.PersonId = @PersonId
END
