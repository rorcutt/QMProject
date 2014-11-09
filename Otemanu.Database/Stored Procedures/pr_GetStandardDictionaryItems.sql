CREATE PROCEDURE [dbo].[pr_GetStandardDictionaryItems]
	@tableName VARCHAR(100)
AS
BEGIN
	
	DECLARE @selectStatement NVARCHAR(MAX)

	SET @selectStatement = 'SELECT Name FROM ' + @tableName

	EXEC sp_executesql @selectStatement

END
GO