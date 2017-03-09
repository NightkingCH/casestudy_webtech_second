CREATE TABLE [app].Zimmer
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[HotelId] INT NOT NULL,
	[RaumNummer] INT NOT NULL,
	[AnzahlRaeume] INT NOT NULL,
	[Kategorie] INT NOT NULL, -- 1 Normal, 2 Premium, 3 Presidental
	CONSTRAINT [PK_Zimmer] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Zimmer_Hotel] FOREIGN KEY ([HotelId]) REFERENCES [app].[Hotel] ([Id])
)
