CREATE TABLE [app].BewertungZimmer
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[BewertungId] INT NOT NULL,
	[ZimmerId] INT NOT NULL,
	[Sterne] INT NOT NULL, -- 1-5
	[Kommentar] NVARCHAR(MAX) NOT NULL,
	CONSTRAINT [PK_BewertungZimmer] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_BewertungZimmer_Bewertung] FOREIGN KEY ([BewertungId]) REFERENCES [app].[Bewertung] ([Id]),
	CONSTRAINT [FK_BewertungZimmer_Zimmer] FOREIGN KEY ([ZimmerId]) REFERENCES [app].[Zimmer] ([Id])
)
