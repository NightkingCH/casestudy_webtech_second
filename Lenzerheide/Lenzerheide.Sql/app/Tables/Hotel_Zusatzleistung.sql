CREATE TABLE [app].Hotel_Zusatzleistung
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[HotelId] INT NOT NULL,
	[ZusatzleistungId] INT NOT NULL,
	CONSTRAINT [PK_Hotel_Zusatzleistung] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Hotel_Zusatzleistung_Hotel] FOREIGN KEY ([HotelId]) REFERENCES [app].[Hotel] ([Id]),
	CONSTRAINT [FK_Hotel_Zusatzleistung_Zusatzleistung] FOREIGN KEY ([ZusatzleistungId]) REFERENCES [app].[Zusatzleistung] ([Id])
)
