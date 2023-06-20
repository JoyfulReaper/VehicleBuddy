CREATE PROCEDURE [dbo].[spFuelType_Upsert]
	@FuelTypeId int,
	@Type varchar(50)
AS
BEGIN
	
	BEGIN TRANSACTION

	UPDATE dbo.FuelType WITH (UPDLOCK, SERIALIZABLE)
	SET
		[Type] = @Type
	WHERE
		FuelTypeId = @FuelTypeId

	IF @@ROWCOUNT = 0
	BEGIN
		INSERT INTO dbo.FuelType
		(
			[Type]
		)
		VALUES
		(
			@Type
		);
		
		SELECT SCOPE_IDENTITY();
	END
	ELSE
		SELECT @FuelTypeId;

	COMMIT TRANSACTION
END
