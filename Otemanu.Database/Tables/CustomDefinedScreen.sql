CREATE TABLE [dbo].[CustomDefinedScreen]
(
	[Id]			INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name]			VARCHAR(50) NOT NULL UNIQUE,
	[Description]	VARCHAR(60) NULL,
	[Active]		BIT NOT NULL
)
GO
