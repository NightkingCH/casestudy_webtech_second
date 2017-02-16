CREATE TABLE [app].Reservation
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[ZimmerId] INT NOT NULL,
	[KundeId] INT NOT NULL,
	[ReservationsZeitpunkt] DATETIME2(7) NOT NULL,
	[ErstelltAm] DATETIME2(7) NOT NULL DEFAULT(GETDATE()),
	CONSTRAINT [PK_Reservation] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Reservation_Zimmer] FOREIGN KEY ([ZimmerId]) REFERENCES [app].[Zimmer] ([Id]),
	CONSTRAINT [FK_Reservation_Kunde] FOREIGN KEY ([KundeId]) REFERENCES [app].[Kunde] ([Id])
)
