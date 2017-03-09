/******************************************************************************
**  Description: Hotel which the customer wishes to stay
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
CREATE TABLE [app].Hotel
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[AdresseId] INT NOT NULL,
	[Name] NVARCHAR(MAX) NOT NULL,	
	CONSTRAINT [PK_Hotel] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Hotel_Adresse] FOREIGN KEY ([AdresseId]) REFERENCES [app].[Adresse] ([Id]),
)
