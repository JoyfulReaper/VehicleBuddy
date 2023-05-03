CREATE PROCEDURE [dbo].[spVehicle_GetByVin]
	@VIN VARCHAR(20),
	@IncludeSold BIT = 0
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
		VIN = @VIN
	AND DateDeleted IS NULL
	AND (@IncludeSold = 1 OR DateSold IS NULL)
END