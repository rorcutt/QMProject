CREATE PROCEDURE [dbo].[pr_DeleteCDS]
	@customDefinedScreenId INT
AS
BEGIN

	DELETE FROM CustomDefinedScreen_Query_Mapping
	WHERE CustomDefinedScreen = @customDefinedScreenId

	DELETE FROM CustomDefinedScreen
	WHERE Id = @customDefinedScreenId

END
GO