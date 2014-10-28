CREATE TABLE [dbo].[CustomDefinedScreen_Query_Mapping]
(
	[CustomDefinedScreen]	INT NOT NULL,
	[Query]					INT	NOT NULL,
	[Required]				BIT NOT NULL,
	[Order]					INT NOT NULL,
	PRIMARY KEY ([CustomDefinedScreen], [Query]),
	CONSTRAINT [FK_Mapping_CustomDefinedScreen] FOREIGN KEY([CustomDefinedScreen]) REFERENCES [CustomDefinedScreen] ([Id]),
	CONSTRAINT [FK_Mapping_Query] FOREIGN KEY([CustomDefinedScreen]) REFERENCES [Query] ([Id])
)
GO
