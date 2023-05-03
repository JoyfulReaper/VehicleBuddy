CREATE PROCEDURE [dbo].[spVehicle_GetById]
	@VehicleId INT
AS
BEGIN
	SELECT 
		v.*,
		m.*,
		mo.*,
		p.*
	FROM
		dbo.Vehicle v INNER JOIN
		dbo.Make m ON v.MakeId = v.MakeId INNER JOIN
		dbo.Model mo ON v.ModelId = mo.ModelId INNER JOIN
		dbo.Package p ON v.PackageId = p.PackageId
	WHERE
		VehicleId = @VehicleId
	AND DateDeleted IS NULL
	AND DateSold IS NULL
END