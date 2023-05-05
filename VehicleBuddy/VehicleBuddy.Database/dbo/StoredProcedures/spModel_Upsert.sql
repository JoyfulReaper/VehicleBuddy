CREATE PROCEDURE [dbo].[spModel_Upsert]
	@ModelId int,
	@Name varchar(50)
AS
BEGIN
	
	BEGIN TRANSACTION

	UPDATE Model WITH (UPDLOCK, SERIALIZABLE)
	SET
		[Name] = @Name 
	WHERE
		ModelId = @ModelId

	IF @@ROWCOUNT = 0
	BEGIN
		INSERT INTO Model
		(
			[Name]
		)
		VALUES
		(
			@Name
		);

		SELECT SCOPE_IDENTITY();
	END
	ELSE
		SELECT @ModelId;

	COMMIT TRANSACTION

END
