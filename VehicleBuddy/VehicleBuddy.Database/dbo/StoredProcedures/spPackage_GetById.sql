CREATE PROCEDURE [dbo].[spPackage_GetById]
	@PackageId int
AS
BEGIN
	SELECT
		[PackageId], 
		[FuelTypeId], 
		[Name], 
		[is4WD], 
		[isHatchback], 
		[NumberOfDoors], 
		[NumberOfPassengers], 
		[NumberOfCylinders], 
		[StartYear], 
		[EndYear]
	FROM
		Package
	WHERE
		PackageId = @PackageId
END
