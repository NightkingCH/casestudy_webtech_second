﻿CREATE TABLE [app].Land
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[Name] NVARCHAR(MAX) NOT NULL,
	[IsoString] NVARCHAR(10) NOT NULL,
	CONSTRAINT [PK_Land] PRIMARY KEY CLUSTERED ([Id] ASC)
)
