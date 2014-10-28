CREATE PROCEDURE [dbo].[pr_GetAllCDS]
AS
BEGIN

	SELECT DISTINCT
		Id,
		Name
	FROM CustomDefinedScreen
	WHERE	Active = 1

END
GO