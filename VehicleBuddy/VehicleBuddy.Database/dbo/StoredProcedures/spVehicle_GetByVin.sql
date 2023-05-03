CREATE PROCEDURE [dbo].[spVehicle_GetByVin]
	@VIN VARCHAR(20),
	@IncludeSold BIT = 0
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
		VIN = @VIN
	AND DateDeleted IS NULL
	AND (@IncludeSold = 1 OR DateSold IS NULL)
END