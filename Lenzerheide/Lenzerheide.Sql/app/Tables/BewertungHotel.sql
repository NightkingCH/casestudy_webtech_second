/******************************************************************************
**  Description: Rating for a hotel
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
CREATE TABLE [app].BewertungHotel
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[BewertungId] INT NOT NULL,
	[HotelId] INT NOT NULL,
	[Sterne] INT NOT NULL, -- 1-5
	[Kommentar] NVARCHAR(MAX) NOT NULL,
	CONSTRAINT [PK_BewertungHotel] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_BewertungHotel_Bewertung] FOREIGN KEY ([BewertungId]) REFERENCES [app].[Bewertung] ([Id]),
	CONSTRAINT [FK_BewertungHotel_Hotel] FOREIGN KEY ([HotelId]) REFERENCES [app].[Hotel] ([Id])
)
