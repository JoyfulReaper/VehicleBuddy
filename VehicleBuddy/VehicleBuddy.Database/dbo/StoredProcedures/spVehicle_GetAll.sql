CREATE PROCEDURE [dbo].[spVehicle_GetAll]
AS
BEGIN
	SELECT 
		v.*,
		m.*,
		mo.*,
		p.*
	FROM 
		dbo.Vehicle v INNER JOIN
		dbo.Make m ON v.MakeId = m.MakeId INNER JOIN
		dbo.Model mo ON v.ModelId = mo.ModelId INNER JOIN
		dbo.Package p ON v.PackageId = p.PackageId

	WHERE 
		DateDeleted IS NULL
	AND DateSold IS NULL;
END