CREATE PROCEDURE [dbo].[pr_DeleteCDSQueryMapping]
	@customDefinedScreenId INT,
	@queryId INT
AS
BEGIN

	IF EXISTS
	(
		SELECT
			*
		FROM CustomDefinedScreen_Query_Mapping 
		WHERE	CustomDefinedScreen = @customDefinedScreenId AND
				Query = @queryId
	)
	BEGIN
		DELETE FROM CustomDefinedScreen_Query_Mapping 
		WHERE	CustomDefinedScreen = @customDefinedScreenId AND
				Query = @queryId

		--TODO: Make sure the ordering of the queries is correct
		
	END
END
GO