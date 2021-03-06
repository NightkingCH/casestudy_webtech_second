﻿/******************************************************************************
**  Description: Customer which books a hotel
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
CREATE TABLE [app].Kunde
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[AdresseId] INT NOT NULL,
	[Name] NVARCHAR(MAX) NOT NULL,
	CONSTRAINT [PK_Kunde] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Kunde_Adresse] FOREIGN KEY ([AdresseId]) REFERENCES [app].[Adresse] ([Id]),
)
