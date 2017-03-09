/******************************************************************************
**  Description: Country table, so we don't store the same information over and over.
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
CREATE TABLE [app].Land
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[Name] NVARCHAR(MAX) NOT NULL,
	[IsoString] NVARCHAR(10) NOT NULL,
	CONSTRAINT [PK_Land] PRIMARY KEY CLUSTERED ([Id] ASC)
)
