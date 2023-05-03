CREATE PROCEDURE [dbo].[spVehicle_Upsert]
	@VehicleId INT,
	@MakeId INT,
	@ModelId INT,
	@PackageId INT,
	@VIN VARCHAR(20),
	@Year INT,
	@isAutomatic BIT,
	@Color VARCHAR(50),
	@DateSold DATETIME2(7),
	@DateAcquired DATETIME2(7),
	@Mileage INT
AS
BEGIN

	BEGIN TRANSACTION

	UPDATE dbo.Vehicle WITH (UPDLOCK, SERIALIZABLE)
	SET
		[MakeId] = @MakeId,
		[ModelId] = @ModelId,
		[PackageId] = @PackageId,
		[VIN] = @VIN,
		[Year] = @Year,
		[isAutomatic] = @isAutomatic,
		[Color] = @Color,
		[DateSold] = @DateSold,
		[DateAcquired] = @DateAcquired,
		[Mileage] = @Mileage
	WHERE
		VehicleId = @VehicleId;

	IF @@ROWCOUNT = 0
	BEGIN
		INSERT INTO dbo.Vehicle
		(
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
		)
		VALUES
		(
			@MakeId,
			@ModelId,
			@PackageId,
			@VIN,
			@Year,
			@isAutomatic,
			@Color,
			@DateSold,
			@DateAcquired,
			@Mileage
		);

		SELECT SCOPE_IDENTITY();
	END
	ELSE
		SELECT @VehicleId;


	COMMIT TRANSACTION

END