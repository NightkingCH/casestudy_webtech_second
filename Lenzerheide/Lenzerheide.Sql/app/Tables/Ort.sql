﻿/******************************************************************************
**  Description: City table, so we don't store the same information over and over.
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
CREATE TABLE [app].Ort
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[Name] NVARCHAR(MAX) NOT NULL,
	[PLZ] NVARCHAR(20) NOT NULL, -- London has string	
	CONSTRAINT [PK_Ort] PRIMARY KEY CLUSTERED ([Id] ASC)
)
