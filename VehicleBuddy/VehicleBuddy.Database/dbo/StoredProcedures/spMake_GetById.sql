CREATE PROCEDURE [dbo].[spMake_GetById]
	@MakeId int
AS
BEGIN
	SELECT 
		[MakeId], 
		[Name], 
		[Country], 
		[CustomerSupportPhoneNumber], 
		[CustomerSupportEmailAddress]

	FROM
		Make

	WHERE
		MakeId = @MakeId

END