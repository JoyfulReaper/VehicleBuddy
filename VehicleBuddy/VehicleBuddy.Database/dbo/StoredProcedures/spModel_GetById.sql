CREATE PROCEDURE [dbo].[spModel_GetById]
	@ModelId int
AS
BEGIN
	SELECT
		[ModelId], 
		[Name]
	FROM
		Model
	WHERE
		ModelId = @ModelId;
END