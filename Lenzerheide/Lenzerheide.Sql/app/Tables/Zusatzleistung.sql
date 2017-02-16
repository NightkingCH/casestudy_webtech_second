CREATE TABLE [app].Zusatzleistung
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[Beschreibung]	NVARCHAR(MAX) NOT NULL,
	CONSTRAINT [PK_Zusatzleistung] PRIMARY KEY CLUSTERED ([Id] ASC)
)
