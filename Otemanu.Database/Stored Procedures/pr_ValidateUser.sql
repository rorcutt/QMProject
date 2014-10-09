CREATE PROCEDURE dbo.pr_ValidateUser
(
      @Username NVARCHAR(20),
      @Password NVARCHAR(20)
)
AS
BEGIN
	SET NOCOUNT ON    

    IF EXISTS(SELECT 1 FROM Users WHERE Username = @Username AND [Password] = @Password)
    BEGIN
            UPDATE Users
            SET LastLoginDate = GETDATE()
            WHERE Username = @Username

            SELECT
				Id
			FROM Users
			WHERE Username = @Username -- User is valid
    END
	BEGIN
		SELECT -1 --Username or password invalid
    END
END
GO