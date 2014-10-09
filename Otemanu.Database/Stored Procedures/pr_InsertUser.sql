CREATE PROCEDURE dbo.pr_InsertUser
(
      @Username NVARCHAR(20),
      @Password NVARCHAR(20)
)
AS
BEGIN
      SET NOCOUNT ON
      IF EXISTS(SELECT Username FROM Users WHERE Username = @Username)
      BEGIN
            SELECT -1 --Username already exists.
      END
	  ELSE
      BEGIN
            INSERT INTO Users
            (
				Username,
				[Password],
				CreateDate
			)
            VALUES
            (
				@Username,
				@Password,
				GETDATE()
			)
           
            SELECT SCOPE_IDENTITY() -- UserId                 
     END
END
GO