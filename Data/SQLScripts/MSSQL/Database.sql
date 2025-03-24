
CREATE DATABASE [ScaleTickets]
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ScaleTickets].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

USE [ScaleTickets]
GO

DROP TABLE IF EXISTS Applications;

CREATE TABLE Applications(
    Id INT NOT NULL IDENTITY PRIMARY KEY,
    [Name] VARCHAR(256) NOT NULL,
    RelativeURI VARCHAR(256) NULL,
    IndexURL VARCHAR(256) NULL,
    DirectoryPath VARCHAR(512) NULL,
    RepositoryUrl VARCHAR(512) NULL,
    ApplicationType VARCHAR(128) NULL,
    CurrentVersion VARCHAR(28) NULL DEFAULT '1.0.0.0',
    CreatedOn DATETIME NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedOn DATETIME NULL DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO [dbo].[Applications]([Name],[RelativeURI],[IndexURL],[DirectoryPath],[RepositoryUrl],[ApplicationType],[CurrentVersion],[CreatedOn],[UpdatedOn])
 VALUES('Admin Dashboard', '/admin','admin/index','/<Path To Directory>','/<URL to repository>','Windows','1.0.0.0',CURRENT_TIMESTAMP,CURRENT_TIMESTAMP)
 INSERT INTO [dbo].[Applications]([Name],[RelativeURI],[IndexURL],[DirectoryPath],[RepositoryUrl],[ApplicationType],[CurrentVersion],[CreatedOn],[UpdatedOn])
 VALUES('Scale UI', '/scaleui','scaleui/index','/<Path To Directory>','/<URL to repository>','Windows','1.0.0.0',CURRENT_TIMESTAMP,CURRENT_TIMESTAMP)
 INSERT INTO [dbo].[Applications]([Name],[RelativeURI],[IndexURL],[DirectoryPath],[RepositoryUrl],[ApplicationType],[CurrentVersion],[CreatedOn],[UpdatedOn])
 VALUES('Web API', '/api','api/index','/<Path To Directory>','/<URL to repository>','WebApi','1.0.0.0',CURRENT_TIMESTAMP,CURRENT_TIMESTAMP)

DROP TABLE IF EXISTS Roles;

CREATE TABLE Roles(
    Id INT NOT NULL IDENTITY PRIMARY KEY,
	[ApplicationId] INT NOT NULL,
    [Name] VARCHAR(256) NOT NULL,
    CreatedOn DATETIME NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedOn DATETIME NULL DEFAULT CURRENT_TIMESTAMP,
	CONSTRAINT FK_Roles_ApplictionID FOREIGN KEY (ApplicationId)
        REFERENCES Applications(Id)
);

INSERT INTO [dbo].[Roles]([ApplicationId], [Name]) VALUES(1, 'Admin')
INSERT INTO [dbo].[Roles]([ApplicationId], [Name]) VALUES(1, 'Manager')
INSERT INTO [dbo].[Roles]([ApplicationId], [Name]) VALUES(1, 'User')
INSERT INTO [dbo].[Roles]([ApplicationId], [Name]) VALUES(2, 'Admin')
INSERT INTO [dbo].[Roles]([ApplicationId], [Name]) VALUES(2, 'Manager')
INSERT INTO [dbo].[Roles]([ApplicationId], [Name]) VALUES(2, 'User')
INSERT INTO [dbo].[Roles]([ApplicationId], [Name]) VALUES(3, 'Admin')
INSERT INTO [dbo].[Roles]([ApplicationId], [Name]) VALUES(3, 'Manager')
INSERT INTO [dbo].[Roles]([ApplicationId], [Name]) VALUES(3, 'User')


DROP TABLE IF EXISTS [Permissions];

CREATE TABLE [Permissions](
    Id INT NOT NULL IDENTITY PRIMARY KEY,
    [Name] VARCHAR(256) NOT NULL,
    CreatedOn DATETIME NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedOn DATETIME NULL DEFAULT CURRENT_TIMESTAMP
);


DROP TABLE IF EXISTS RoleHasPermissions;

CREATE TABLE RoleHasPermissions(
    Id INT NOT NULL IDENTITY PRIMARY KEY,
    RoleId INT NOT NULL,
    PermissionId INT NOT NULL,
    CreatedOn DATETIME NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedOn DATETIME NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT FK_RoleHasPermissions_RoleId FOREIGN KEY (RoleId) REFERENCES Roles(Id),
    CONSTRAINT FK_RoleHasPermissions_PermissionId FOREIGN KEY (PermissionId) REFERENCES Permissions(Id)
);

INSERT INTO [dbo].[RoleHasPermissions]([RoleId], [PermissionId]) VALUES(1, 1)
INSERT INTO [dbo].[RoleHasPermissions]([RoleId], [PermissionId]) VALUES(1, 2)
INSERT INTO [dbo].[RoleHasPermissions]([RoleId], [PermissionId]) VALUES(1, 3)
INSERT INTO [dbo].[RoleHasPermissions]([RoleId], [PermissionId]) VALUES(1, 4)
INSERT INTO [dbo].[RoleHasPermissions]([RoleId], [PermissionId]) VALUES(2, 1)
INSERT INTO [dbo].[RoleHasPermissions]([RoleId], [PermissionId]) VALUES(2, 2)
INSERT INTO [dbo].[RoleHasPermissions]([RoleId], [PermissionId]) VALUES(2, 3)
INSERT INTO [dbo].[RoleHasPermissions]([RoleId], [PermissionId]) VALUES(2, 4)
INSERT INTO [dbo].[RoleHasPermissions]([RoleId], [PermissionId]) VALUES(3, 1)
INSERT INTO [dbo].[RoleHasPermissions]([RoleId], [PermissionId]) VALUES(3, 2)


DROP TABLE IF EXISTS Users;

CREATE TABLE Users(
    Id INT NOT NULL IDENTITY PRIMARY KEY,
    ApplicationId INT NOT NULL,
    RoleId INT NOT NULL,
    Username VARCHAR(256) NOT NULL,
    Email VARCHAR(256) NOT NULL,
    Password VARCHAR(256) NOT NULL,
    CreatedOn DATETIME NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedOn DATETIME NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT FK_Users_ApplicationId FOREIGN KEY (ApplicationId) REFERENCES Applications(Id),
    CONSTRAINT FK_Users_RoleId FOREIGN KEY (RoleId) REFERENCES Roles(Id)    
);

INSERT INTO [dbo].[Users]([ApplicationId], [RoleId],[Username], [Email], [Password], [CreatedOn], [UpdatedOn]) VALUES(1, 1, 'admin', 'admin@scaleapp.com', 'password', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP)
INSERT INTO [dbo].[Users]([ApplicationId], [RoleId],[Username], [Email], [Password], [CreatedOn], [UpdatedOn]) VALUES(1, 2, 'manager', 'manager@scaleapp.com', 'password', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP)
INSERT INTO [dbo].[Users]([ApplicationId], [RoleId],[Username], [Email], [Password], [CreatedOn], [UpdatedOn]) VALUES(1, 3, 'user', 'user@scaleapp.com', 'password', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP)


DROP TABLE IF EXISTS [Locations];

CREATE TABLE [Locations](
	Id INT NOT NULL IDENTITY PRIMARY KEY,
	[Name] VARCHAR(256) NULL,
	[Address1] VARCHAR(256) NULL,
	[Address2] VARCHAR(256) NULL,
	[City] VARCHAR(256) NULL,
	[State] VARCHAR(2) NULL,
	[Zip] VARCHAR(12) NULL,
	[Country] VARCHAR(28) NULL,
	[LatLong] VARCHAR(128) NULL,
	CreatedOn DATETIME NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedOn DATETIME NULL DEFAULT CURRENT_TIMESTAMP,
	Notes VARCHAR(max) NULL
);

INSERT INTO [dbo].[Locations]([Name], [Address1], [Address2], [City], [State], [Zip], [Country], [LatLong], [CreatedOn], [UpdatedOn], [Notes])
VALUES('Site 1 GS', '123 Site Rd.', 'Guard Shack', 'Mobile', 'AL', '36686', 'US', '[123.456, 987.654]', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, 'Scale Site 1 Guard Shack')
INSERT INTO [dbo].[Locations]([Name], [Address1], [Address2], [City], [State], [Zip], [Country], [LatLong], [CreatedOn], [UpdatedOn], [Notes])
VALUES('Site 1 MO', '123 Site Rd.', 'Main Office', 'Mobile', 'AL', '36686', 'US', '[123.456, 987.321]', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, 'Scale Site 1 Main Office')
INSERT INTO [dbo].[Locations]([Name], [Address1], [Address2], [City], [State], [Zip], [Country], [LatLong], [CreatedOn], [UpdatedOn], [Notes])
VALUES('Site 2', '456 State HWY 43.', 'Guard Shack', 'Mt Vernon', 'AL', '36686', 'US', '[102.356, 987.654]', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, 'Scale Site 2 Dirt Pit')

DROP TABLE IF EXISTS Contacts;

CREATE TABLE Contacts(
	Id INT NOT NULL IDENTITY PRIMARY KEY,
	[Name] VARCHAR(256)  NULL,
	[Phone1] VARCHAR(28) NULL,
	[Phone2] VARCHAR(28) NULL,
	[Fax] VARCHAR(28)    NULL,
	[Email1] VARCHAR(128) NULL,
	[Email2] VARCHAR(128) NULL,
	[Url] VARCHAR(128)    NULL,
	[LocationId] INT NULL,
    CreatedOn DATETIME NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedOn DATETIME NULL DEFAULT CURRENT_TIMESTAMP,
	LastContacted DATETIME NULL DEFAULT CURRENT_TIMESTAMP,
	Notes VARCHAR(max) NULL,
    CONSTRAINT FK_Contacts_LocationId FOREIGN KEY (LocationId) REFERENCES Locations(Id)
);

INSERT INTO [dbo].[Contacts]([Name], [Phone1], [Phone2], [Fax], [Email1], [Email2], [Url], [LocationId], [CreatedOn], [UpdatedOn], [LastContacted], [Notes])
VALUES('John Smith', '(123)456-7890', '(123)456-7891', '(123)456-7892', 'jsmite@site1.com', 'jsmith@outlook.com', 'facebook.com/jsmith', 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, 'Scale Site 1 Guard')
INSERT INTO [dbo].[Contacts]([Name], [Phone1], [Phone2], [Fax], [Email1], [Email2], [Url], [LocationId], [CreatedOn], [UpdatedOn], [LastContacted], [Notes])
VALUES('James Smith', '(123)456-7890', '(123)456-7891', '(123)456-7892', 'jasmith@site1.com', 'jasmith@outlook.com', 'facebook.com/jasmith', 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, 'Scale Site 1 Manager')
INSERT INTO [dbo].[Contacts]([Name], [Phone1], [Phone2], [Fax], [Email1], [Email2], [Url], [LocationId], [CreatedOn], [UpdatedOn], [LastContacted], [Notes])
VALUES('Jim Smith', '(123)456-7894', '(123)456-7895', '(123)456-7896', 'jimsmith@site1.com', 'jimsmith@outlook.com', 'facebook.com/jimsmith', 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, 'Scale Site 2 Guard')


DROP TABLE IF EXISTS Customers;

/* TODO: Add AccountId */
CREATE TABLE Customers(
	Id INT NOT NULL IDENTITY PRIMARY KEY,
	[Name] VARCHAR(256)  NULL,
	LocationId INT NULL,
	ContactId INT NULL,
    CreatedOn DATETIME NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedOn DATETIME NULL DEFAULT CURRENT_TIMESTAMP,
	Notes VARCHAR(max) NULL,
    CONSTRAINT FK_Customers_LocationId FOREIGN KEY (LocationId) REFERENCES Locations(Id),
    CONSTRAINT FK_Customers_ContactId FOREIGN KEY (ContactId) REFERENCES Contacts(Id)
);


INSERT INTO [dbo].[Customers]([Name],[LocationId],[ContactId],[CreatedOn],[UpdatedOn],[Notes])
VALUES('Customer 1', 1, 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, 'Customer 1')

DROP TABLE IF EXISTS Scales;

CREATE TABLE Scales(
    Id INT CHECK (id > 0) NOT NULL IDENTITY PRIMARY KEY,
    [Name] VARCHAR(256) NOT NULL,
    [LocationId] INT NOT NULL,
    ScaleMfg VARCHAR(256) NOT NULL,
    ScaleModel VARCHAR(256) NOT NULL,
    ScaleSerialNo VARCHAR(256) NOT NULL,
    ScaleProperties VARCHAR(256) NOT NULL,
    DateInstalled DATETIME NOT NULL,
    Installer VARCHAR(256) NOT NULL,
    DateCalibrated DATETIME NOT NULL,
    CalibratedBy VARCHAR(256) NOT NULL,
    Notes VARCHAR(max) NOT NULL,
    CONSTRAINT FK_Scales_LocationId FOREIGN KEY (LocationId) REFERENCES Locations(Id)
);

INSERT INTO [dbo].[Scales]([Name],[LocationId],[ScaleMfg],[ScaleModel],[ScaleSerialNo],[ScaleProperties],[DateInstalled],[Installer],[DateCalibrated],[CalibratedBy],[Notes])
VALUES('Scale 1', 1, 'Quality Scales, Inc', 'Weigh Master 100', '123asxdqq2-43i', '{[name=value], [name=value]}', CURRENT_TIMESTAMP, 'Certified Installer 10905', CURRENT_TIMESTAMP, 'Certified Installer 10905', 'Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...')
INSERT INTO [dbo].[Scales]([Name],[LocationId],[ScaleMfg],[ScaleModel],[ScaleSerialNo],[ScaleProperties],[DateInstalled],[Installer],[DateCalibrated],[CalibratedBy],[Notes])
VALUES('Scale 2', 1, 'Quality Scales, Inc', 'Weigh Master 100', '123asxdqq2-44i', '{[name=value], [name=value]}', CURRENT_TIMESTAMP, 'Certified Installer 10905', CURRENT_TIMESTAMP, 'Certified Installer 10905', 'Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...')
INSERT INTO [dbo].[Scales]([Name],[LocationId],[ScaleMfg],[ScaleModel],[ScaleSerialNo],[ScaleProperties],[DateInstalled],[Installer],[DateCalibrated],[CalibratedBy],[Notes])
VALUES('Scale 3', 3, 'Quality Scales, Inc', 'Weigh On The Go', '432hfgfg-22v', '{[name=value], [name=value]}', CURRENT_TIMESTAMP, 'Certified Trailer Mechanic 7', CURRENT_TIMESTAMP, 'Certified Trailer Mechanic 7', 'Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...')
INSERT INTO [dbo].[Scales]([Name],[LocationId],[ScaleMfg],[ScaleModel],[ScaleSerialNo],[ScaleProperties],[DateInstalled],[Installer],[DateCalibrated],[CalibratedBy],[Notes])
VALUES('Scale 4', 3, 'Quality Scales, Inc', 'Jump Out Scale Pro', 'zzz333-olered1', '{[name=value], [name=value]}', CURRENT_TIMESTAMP, 'Jumpout Boy 1', CURRENT_TIMESTAMP, 'Jumpout Boy 1', 'Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...')


DROP TABLE IF EXISTS ScaleTickets;

CREATE TABLE ScaleTickets(
    Id INT NOT NULL IDENTITY PRIMARY KEY,
    ScaleId INT NOT NULL,
    CreatedOn DATETIME NULL DEFAULT CURRENT_TIMESTAMP,
    CreatedBy INT NOT NULL,
	CustomerId INT NOT NULL,
    TruckId VARCHAR(256) NOT NULL,
    DriverId VARCHAR(256) NOT NULL,
    WeightTare INT NOT NULL,
    WeightNet INT NOT NULL,
    WeightGross INT NOT NULL,
    VehicleType INT NOT NULL,
    Notes VARCHAR(max) NOT NULL,
    CONSTRAINT FK_ScaleTickets_ScaleId FOREIGN KEY (ScaleId) REFERENCES Scales(Id)
);

INSERT INTO [dbo].[ScaleTickets]([ScaleId],[CreatedOn],[CreatedBy],[CustomerId],[TruckId],[DriverId],[WeightTare],[WeightNet],[WeightGross],[VehicleType],[Notes])
VALUES(1, CURRENT_TIMESTAMP, 3, 1, 'Good Ole Rig #5, Trl# 100', 'Justin Case', 6500, 12007, 10003, 1, 'Empty Trl Check In')
INSERT INTO [dbo].[ScaleTickets]([ScaleId],[CreatedOn],[CreatedBy],[CustomerId],[TruckId],[DriverId],[WeightTare],[WeightNet],[WeightGross],[VehicleType],[Notes])
VALUES(2, CURRENT_TIMESTAMP, 3, 1, 'Good Ole Rig #5, Trl# 100', 'Justin Case', 11999, 33999, 33999, 1, 'Headed Out, Right at the limit!')
INSERT INTO [dbo].[ScaleTickets]([ScaleId],[CreatedOn],[CreatedBy],[CustomerId],[TruckId],[DriverId],[WeightTare],[WeightNet],[WeightGross],[VehicleType],[Notes])
VALUES(3, CURRENT_TIMESTAMP, 3, 1, 'Good Ole Rig #5, Trl# 100', 'Justin Case', 11999, 33979, 33959, 1, 'Keeping A check while in route! Burned a bit of fuel!')
INSERT INTO [dbo].[ScaleTickets]([ScaleId],[CreatedOn],[CreatedBy],[CustomerId],[TruckId],[DriverId],[WeightTare],[WeightNet],[WeightGross],[VehicleType],[Notes])
VALUES(1, CURRENT_TIMESTAMP, 3, 1, 'The Brown Pete, Trk #53107, Trl# 102', 'Phil Dees', 5000, 10000, 10000, 1, 'Empty Trl Check In')
INSERT INTO [dbo].[ScaleTickets]([ScaleId],[CreatedOn],[CreatedBy],[CustomerId],[TruckId],[DriverId],[WeightTare],[WeightNet],[WeightGross],[VehicleType],[Notes])
VALUES(2, CURRENT_TIMESTAMP, 3, 1, 'The Brown Pete, Trk #53107, Trl# 102', 'Phil Dees', 11007, 33765, 29781, 1, 'Headed Out, All Good')
INSERT INTO [dbo].[ScaleTickets]([ScaleId],[CreatedOn],[CreatedBy],[CustomerId],[TruckId],[DriverId],[WeightTare],[WeightNet],[WeightGross],[VehicleType],[Notes])
VALUES(1, CURRENT_TIMESTAMP, 3, 1, 'POS Trk #275, Trl# 105', 'Sal Tyass', 5000, 10000, 10000, 1, 'Empty Trl Check In')
INSERT INTO [dbo].[ScaleTickets]([ScaleId],[CreatedOn],[CreatedBy],[CustomerId],[TruckId],[DriverId],[WeightTare],[WeightNet],[WeightGross],[VehicleType],[Notes])
VALUES(1, CURRENT_TIMESTAMP, 3, 1, 'POS Trk #275, Trl# 105', 'Sal Tyass', 12001, 34001, 34001, 1, 'Overweight! Remove rocks and reweigh!')