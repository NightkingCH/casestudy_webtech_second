CREATE TABLE [app].Zimmer_Zusatzleistung
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[ZimmerId] INT NOT NULL,
	[ZusatzleistungId] INT NOT NULL,
	CONSTRAINT [PK_Zimmer_Zusatzleistung] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Zimmer_Zusatzleistung_Zimmer] FOREIGN KEY ([ZimmerId]) REFERENCES [app].[Zimmer] ([Id]),
	CONSTRAINT [FK_Zimmer_Zusatzleistung_Zusatzleistung] FOREIGN KEY ([ZusatzleistungId]) REFERENCES [app].[Zusatzleistung] ([Id])
)
