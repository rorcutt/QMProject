CREATE PROCEDURE [dbo].[pr_GetQueriesFromCDS]
(
	@CustomDefinedScreen INT
)
AS
BEGIN

	SELECT DISTINCT
		query.Id,
		query.Name
	FROM Query query
	JOIN CustomDefinedScreen_Query_Mapping map ON map.Query = query.Id
	JOIN CustomDefinedScreen screen ON map.CustomDefinedScreen = screen.Id
	WHERE	query.Active = 1 AND 
			screen.Id = @CustomDefinedScreen			

END
GO