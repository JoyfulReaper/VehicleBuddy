CREATE PROCEDURE [dbo].[spMake_Upsert]
	@MakeId int,
	@Name varchar(50),
	@Country varchar(50),
	@CustomerSupportPhoneNumber nvarchar(20),
	@CustomerSupportEmailAddress nvarchar(150)

AS
BEGIN
	
	BEGIN TRANSACTION

	UPDATE Make WITH (UPDLOCK, SERIALIZABLE)
	SET
		[Name] = @Name,
		[Country] = @Country,
		[CustomerSupportPhoneNumber] = @CustomerSupportPhoneNumber,
		[CustomerSupportEmailAddress] = @CustomerSupportEmailAddress
	WHERE
		MakeId = @MakeId

	IF @@ROWCOUNT = 0
	BEGIN
		INSERT INTO Make
		(
			[Name],
			[Country],
			[CustomerSupportPhoneNumber],
			[CustomerSupportEmailAddress]
		)
		VALUES
		(
			@Name,
			@Country,
			@CustomerSupportPhoneNumber,
			@CustomerSupportEmailAddress
		);

		SELECT SCOPE_IDENTITY();
	END
	ELSE
		SELECT @MakeId;

	COMMIT TRANSACTION

END
