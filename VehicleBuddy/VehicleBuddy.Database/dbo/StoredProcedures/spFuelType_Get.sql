CREATE PROCEDURE [dbo].[spFuelType_Get]
	@FuelTypeId int
AS
	SELECT [FuelTypeId], [Type]
	FROM
		FuelType
	WHERE FuelTypeId = @FuelTypeId
