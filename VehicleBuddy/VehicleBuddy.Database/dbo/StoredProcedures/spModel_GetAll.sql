CREATE PROCEDURE [dbo].[spModel_GetAll]

AS
BEGIN
	SELECT
		[ModelId], 
		[Name]
	FROM
		Model
END
