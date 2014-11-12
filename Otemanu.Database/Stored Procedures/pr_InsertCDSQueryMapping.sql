CREATE PROCEDURE [dbo].[pr_InsertCDSQueryMapping]
	@CustomDefinedScreenId INT,
	@QueryId INT
AS
BEGIN

	IF NOT EXISTS
	(
		SELECT
			*
		FROM CustomDefinedScreen_Query_Mapping 
		WHERE	CustomDefinedScreen = @CustomDefinedScreenId AND
				Query = @QueryId
	)
	BEGIN
		INSERT INTO CustomDefinedScreen_Query_Mapping
		(
			CustomDefinedScreen,
			Query,
			[Required],
			[Order]
		)
		SELECT
			@CustomDefinedScreenId, 
			@QueryId,
			1,
			(
				SELECT
					ISNULL(MAX([Order]), 0) + 1
				FROM CustomDefinedScreen_Query_Mapping
				WHERE CustomDefinedScreen = @CustomDefinedScreenId AND
						Query = @QueryId
			)

		--TODO: Make sure the ordering of the queries is correct
		
	END
END
GO