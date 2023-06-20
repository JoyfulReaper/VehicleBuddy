CREATE PROCEDURE [dbo].[spFuelType_GetAll]
	
AS
BEGIN
	SELECT 
	[FuelTypeId], 
	[Type]
	FROM FuelType
END
