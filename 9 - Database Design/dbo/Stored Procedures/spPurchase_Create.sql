CREATE PROCEDURE [dbo].[spPurchase_Create]
	@PersonId INT,
	@ItemName NVARCHAR(50),
	@Amount MONEY,
	@Quantity INT
AS
BEGIN
	INSERT INTO Purchase (PersonId, ItemName, Amount, Quantity)
	VALUES (@PersonId, @ItemName, @Amount, @Quantity);
END
