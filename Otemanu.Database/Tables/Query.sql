﻿CREATE TABLE [dbo].[Query]
(
	[Id]			INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name]			VARCHAR(50) NOT NULL UNIQUE,
	[Description]	VARCHAR(60) NULL,
	[Active]		BIT NOT NULL,
	[Type]			VARCHAR(20) NOT NULL,
	[SubType]		VARCHAR(20) NULL,
	[Label]			VARCHAR(120) NULL,
	CONSTRAINT [FK_Query_QueryType] FOREIGN KEY([Type]) REFERENCES [QueryType]([Type]),
	CONSTRAINT [FK_Query_SubType] FOREIGN KEY([SubType]) REFERENCES [StandardDictionaryType]([Type])
)
GO