CREATE PROCEDURE [dbo].[spFuelType_Delete]
	@FuelTypeId int
AS
BEGIN
	DELETE FROM FuelType
	WHERE FuelTypeId = @FuelTypeId
END