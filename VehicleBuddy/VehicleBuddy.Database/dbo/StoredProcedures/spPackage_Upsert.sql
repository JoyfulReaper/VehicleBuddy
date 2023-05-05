CREATE PROCEDURE [dbo].[spPackage_Upsert]
	@PackageId int,
	@FuelTypeId int,
	@Name varchar(50),
	@is4WD bit,
	@isHatchback bit,
	@NumberOfDoors int,
	@NumberOfPassengers int,
	@NumberOfCylinders int,
	@StartYear Datetime2,
	@EndYear DateTime2
AS
BEGIN

	BEGIN TRANSACTION

	UPDATE Package WITH (UPDLOCK, SERIALIZABLE)
	SET
		[FuelTypeId] = @FuelTypeId,
		[Name] = @Name,
		[is4WD] = @is4WD, 
		[isHatchback] = @isHatchback, 
		[NumberOfDoors] = @NumberOfDoors, 
		[NumberOfPassengers] = @NumberOfPassengers, 
		[NumberOfCylinders] = @NumberOfCylinders, 
		[StartYear] = @StartYear,
		[EndYear] = @EndYear
	WHERE
		PackageId = @PackageId

	IF @@ROWCOUNT = 0
	BEGIN
		INSERT INTO Package
		(
			[FuelTypeId], 
			[Name], 
			[is4WD], 
			[isHatchback], 
			[NumberOfDoors], 
			[NumberOfPassengers], 
			[NumberOfCylinders], 
			[StartYear], 
			[EndYear]
		)
		SELECT
			@FuelTypeId, 
			@Name, 
			@is4WD, 
			@isHatchback, 
			@NumberOfDoors, 
			@NumberOfPassengers, 
			@NumberOfCylinders, 
			@StartYear, 
			@EndYear
		
		SELECT SCOPE_IDENTITY();
	END
	ELSE
		SELECT @PackageId;

	COMMIT TRANSACTION
END

