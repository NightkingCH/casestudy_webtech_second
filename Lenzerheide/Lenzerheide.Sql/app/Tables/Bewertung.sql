/******************************************************************************
**  Description: Base table for ratings. Used to rate locations and their services
**
**
**
**  Author: T. Erni
**  Date: 09.03.2017
**
**
*******************************************************************************
**  Change History
*******************************************************************************
**  Date:      Author:         Description:
**  --------    --------------  -----------------------------------------------
******************************************************************************/
CREATE TABLE [app].[Bewertung]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[KundeId] INT NOT NULL,
	[BewertungsTyp] INT NOT NULL, -- 1 = Hotel, 2 = Zimmer
	CONSTRAINT [PK_Bewertung] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Bewertung_Kunde] FOREIGN KEY ([KundeId]) REFERENCES [app].[Kunde] ([Id])
)
