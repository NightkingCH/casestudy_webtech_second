CREATE TABLE [app].[Bewertung]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[KundeId] INT NOT NULL,
	[BewertungsTyp] INT NOT NULL, -- 1 = Hotel, 2 = Zimmer
	CONSTRAINT [PK_Bewertung] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Bewertung_Kunde] FOREIGN KEY ([KundeId]) REFERENCES [app].[Kunde] ([Id])
)
