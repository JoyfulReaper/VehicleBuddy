CREATE PROCEDURE [dbo].[spVehicle_GetAll]
AS
BEGIN
	SELECT 
		[VehicleId], 
		[MakeId],
		[ModelId],
		[PackageId], 
		[VIN],
		[Year], 
		[isAutomatic],
		[Color], 
		[DateSold], 
		[DateAcquired],
		[Mileage]
	FROM dbo.Vehicle
	WHERE 
		DateDeleted IS NULL
	AND DateSold IS NULL
END