/******************************************************************************
**  Description: Postal address to locate a customer
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
CREATE TABLE [app].[Adresse]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[OrtId] INT NOT NULL, 
	[LandId] INT NOT NULL,
	[Strasse] NVARCHAR(MAX) NOT NULL,
	[Hausnummer] NVARCHAR(10) NOT NULL,
	CONSTRAINT [PK_Adresse] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Adresse_Ort] FOREIGN KEY ([OrtId]) REFERENCES [app].[Ort] ([Id]),
	CONSTRAINT [FK_Adresse_Land] FOREIGN KEY ([LandId]) REFERENCES [app].[Land] ([Id]),
)
