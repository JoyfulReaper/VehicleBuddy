CREATE PROCEDURE [dbo].[spPackage_GetAll]

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
END
