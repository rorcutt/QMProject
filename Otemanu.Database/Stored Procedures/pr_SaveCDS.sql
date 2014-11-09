CREATE PROCEDURE [dbo].[pr_SaveCDS]	
	@Name			VARCHAR(50),
	@Description	VARCHAR(60) 
AS
BEGIN
	
	IF NOT EXISTS(SELECT * FROM CustomDefinedScreen WHERE Name = @Name)
	BEGIN
		INSERT INTO CustomDefinedScreen
		(
			Name,
			Description,
			Active
		)
		SELECT
			@Name,
			@Description,
			1

		SELECT 1 AS 'Result' --Inserted
	END
	ELSE
	BEGIN
		UPDATE CustomDefinedScreen
		SET Description = @Description
		WHERE Name = @Name

		SELECT 2 AS 'Result' --Updated
	END

END
GO