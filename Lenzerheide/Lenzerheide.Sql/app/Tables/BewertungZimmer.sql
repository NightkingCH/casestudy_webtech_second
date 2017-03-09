/******************************************************************************
**  Description: Rating for a specific room from a specific hotel
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
