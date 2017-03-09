/******************************************************************************
**  Description: Separated login table to esnure the SR-Principal.
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
CREATE TABLE [app].[Login]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[KundeId] INT NOT NULL,
	[EMail] NVARCHAR(100) NOT NULL,
	[PasswordHash] NVARCHAR(512) NOT NULL,
	CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Login_Kunde] FOREIGN KEY ([KundeId]) REFERENCES [app].[Kunde] ([Id])
)
