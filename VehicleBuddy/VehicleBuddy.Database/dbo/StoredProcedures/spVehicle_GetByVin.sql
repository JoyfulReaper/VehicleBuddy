CREATE PROCEDURE [dbo].[spVehicle_GetByVin]
	@VIN VARCHAR(20),
	@IncludeSold BIT = 0
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
		v.VIN = @VIN
	AND DateDeleted IS NULL
	AND (@IncludeSold = 1 OR DateSold IS NULL)
END