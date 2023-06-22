CREATE PROCEDURE [dbo].[spVehicle_GetById]
	@VehicleId INT
AS
BEGIN
	SELECT
	* 
	FROM
		Vehicle v LEFT JOIN
		Make m on m.MakeId = v.MakeId LEFT JOIN
		Model mo on mo.ModelId = v.ModelId LEFT JOIN
		Package p on p.PackageId = v.PackageId
	WHERE
		v.VehicleId = @VehicleId
	AND DateDeleted IS NULL
	AND DateSold IS NULL
END