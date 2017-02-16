CREATE TABLE [app].Zimmer
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[RaumNummer] INT NOT NULL,
	[AnzahlRaeume] INT NOT NULL,
	[Kategorie] INT NOT NULL, -- 1 Normal, 2 Premium, 3 Presidental
	CONSTRAINT [PK_Zimmer] PRIMARY KEY CLUSTERED ([Id] ASC)
)
