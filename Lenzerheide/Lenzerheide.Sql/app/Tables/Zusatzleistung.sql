/******************************************************************************
**  Description: Special offers table, so we don't store the same information over and over.
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
CREATE TABLE [app].Zusatzleistung
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[Beschreibung]	NVARCHAR(MAX) NOT NULL,
	CONSTRAINT [PK_Zusatzleistung] PRIMARY KEY CLUSTERED ([Id] ASC)
)
