CREATE TABLE [dbo].[Location]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL,
	[Description] VARCHAR(100) NULL, 
	[Active] BIT NOT NULL, 
	[NotifyUsers] BIT NOT NULL
)
GO
