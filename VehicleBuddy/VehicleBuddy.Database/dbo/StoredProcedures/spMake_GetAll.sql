CREATE PROCEDURE [dbo].[spMake_GetAll]
	
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

END
