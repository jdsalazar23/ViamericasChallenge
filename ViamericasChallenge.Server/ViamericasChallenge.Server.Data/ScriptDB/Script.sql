CREATE DATABASE ViamericasChallenge;
GO
USE ViamericasChallenge
GO

/* usr_challenge */
CREATE USER usr_challenge FOR LOGIN usr_challenge WITH DEFAULT_SCHEMA=dbo
GO
ALTER ROLE db_owner ADD MEMBER usr_challenge
GO
ALTER ROLE db_datareader ADD MEMBER usr_challenge
GO
ALTER ROLE db_datawriter ADD MEMBER usr_challenge
GO
/* Table dbo.City */
CREATE TABLE dbo.City(
	CityId int IDENTITY(1,1) NOT NULL,
	Name varchar(50) NOT NULL);
GO	
ALTER TABLE dbo.City ADD CONSTRAINT PK_City PRIMARY KEY (CityId);
GO
/* Table dbo.State */
CREATE TABLE dbo.State(
	StateId int IDENTITY(1,1) NOT NULL,
	Name varchar(50) NOT NULL);
GO	
ALTER TABLE dbo.State ADD CONSTRAINT PK_State PRIMARY KEY (StateId);
GO
/* Table dbo.Status */
CREATE TABLE dbo.Status(
	StatusId int IDENTITY(1,1) NOT NULL,
	Name varchar(50) NOT NULL);
GO	
ALTER TABLE dbo.Status ADD CONSTRAINT PK_Status PRIMARY KEY (StatusId);
GO
/* Table dbo.Agency */
CREATE TABLE dbo.Agency(
	AgencyId varchar(10) NOT NULL,
	Name varchar(50) NOT NULL,
	StatusId int NOT NULL,
	CityId int NOT NULL,
	StateId int NOT NULL);
GO	
ALTER TABLE dbo.Agency ADD CONSTRAINT PK_Agency PRIMARY KEY (AgencyId);
GO
ALTER TABLE dbo.Agency  WITH CHECK ADD  CONSTRAINT FK_Agency_City FOREIGN KEY(CityId)
REFERENCES dbo.City (CityId)
GO
ALTER TABLE dbo.Agency CHECK CONSTRAINT FK_Agency_City
GO
ALTER TABLE dbo.Agency  WITH CHECK ADD  CONSTRAINT FK_Agency_State FOREIGN KEY(StateId)
REFERENCES dbo.State (StateId)
GO
ALTER TABLE dbo.Agency CHECK CONSTRAINT FK_Agency_State
GO
ALTER TABLE dbo.Agency  WITH CHECK ADD  CONSTRAINT FK_Agency_Status FOREIGN KEY(StatusId)
REFERENCES dbo.Status (StatusId)
GO
ALTER TABLE dbo.Agency CHECK CONSTRAINT FK_Agency_Status
GO
