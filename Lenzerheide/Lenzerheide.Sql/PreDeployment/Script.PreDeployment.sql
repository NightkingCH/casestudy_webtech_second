/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

-- http://stackoverflow.com/questions/11620/how-do-you-kill-all-current-connections-to-a-sql-server-2005-database
-- kill all connections!
USE MASTER
GO

ALTER DATABASE [$(DatabaseName)] SET SINGLE_USER WITH ROLLBACK IMMEDIATE
GO

ALTER DATABASE [$(DatabaseName)] SET MULTI_USER
GO

USE [$(DatabaseName)]

-- Prüfung der referentiellen Integrität deaktivieren
EXEC sp_MSforeachtable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL' 
GO 

-- Delete table
-- Quoted_Identifier deaktivieren um keine Meldung zu bekommen 
EXEC sp_MSforeachtable 'SET QUOTED_IDENTIFIER ON DELETE FROM ?' 
GO 

-- Prüfung der referentiellen Integrität wieder aktivieren
EXEC sp_MSforeachtable 'ALTER TABLE ? CHECK CONSTRAINT ALL' 
GO 

-- Reset Identity-Spalten   
EXEC sp_MSforeachtable '  
IF OBJECTPROPERTY(object_id(''?''), ''TableHasIdentity'') = 1  
DBCC CHECKIDENT (''?'', RESEED, 0)  
'  
GO

EXEC sp_MSforeachtable '  
IF OBJECTPROPERTY(object_id(''?''), ''TableHasIdentity'') = 1  
DBCC CHECKIDENT (''?'', RESEED, 0)  
'  
GO