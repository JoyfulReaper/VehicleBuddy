CREATE PROCEDURE [dbo].[spVehicle_Delete]
	@vehicleId int
AS
BEGIN 
	UPDATE Vehicle
	SET DateDeleted = SYSUTCDATETIME()
	WHERE VehicleId = @vehicleId
END

