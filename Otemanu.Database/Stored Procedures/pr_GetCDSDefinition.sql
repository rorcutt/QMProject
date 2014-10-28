CREATE PROCEDURE [dbo].[pr_GetCDSDefinition]
(
	@CustomDefinedScreen INT
)
AS
BEGIN

	SELECT
		Label,
		querytype.Type
	FROM CustomDefinedScreen screen 
	JOIN CustomDefinedScreen_Query_Mapping map ON screen.Id = map.CustomDefinedScreen
	JOIN Query query ON map.Query = query.Id
	JOIN QueryType querytype ON query.[Type] = querytype.[Type]
	WHERE	screen.Id = @CustomDefinedScreen AND
			query.Active = 1
	ORDER BY map.[Order]

END
GO