CREATE PROCEDURE [dbo].[pr_GetAllQueries]
AS
BEGIN

	SELECT DISTINCT
		query.Name
	FROM Query query
	WHERE	query.Active = 1		

END
GO