CREATE PROCEDURE [dbo].[spVehicle_GetById]
	@VehicleId INT
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
	FROM
		dbo.Vehicle
	WHERE
		VehicleId = @VehicleId
	AND DateDeleted IS NULL
	AND DateSold IS NULL
END