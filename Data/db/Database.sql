
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
    [Name] VARCHAR(256) NOT NULL
);

INSERT INTO [dbo].[Roles]([Name]) VALUES('Admin')
INSERT INTO [dbo].[Roles]([Name]) VALUES('Manager')
INSERT INTO [dbo].[Roles]([Name]) VALUES('User')


DROP TABLE IF EXISTS [Permissions];

CREATE TABLE [Permissions](
    Id INT NOT NULL IDENTITY PRIMARY KEY,
    [Name] VARCHAR(256) NOT NULL
);

INSERT INTO [dbo].[Permissions]([Name]) VALUES('Create Scale Ticket')
INSERT INTO [dbo].[Permissions]([Name]) VALUES('View Scale Ticket')
INSERT INTO [dbo].[Permissions]([Name]) VALUES('Edit Scale Ticket')
INSERT INTO [dbo].[Permissions]([Name]) VALUES('Delete Scale Ticket')

DROP TABLE IF EXISTS RoleHasPermissions;

CREATE TABLE RoleHasPermissions(
    RoleId INT NOT NULL,
    PermissionId INT NOT NULL,
    PRIMARY KEY(RoleId, PermissionId)
);

ALTER TABLE RoleHasPermissions ADD CONSTRAINT role_has_permissions_roleId FOREIGN KEY(RoleId) REFERENCES Roles(Id);
ALTER TABLE RoleHasPermissions ADD CONSTRAINT role_has_permissions_permissionId FOREIGN KEY(PermissionId) REFERENCES Permissions(Id);

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
    Username VARCHAR(255) NOT NULL,
    Email VARCHAR(256) NOT NULL,
    Password VARCHAR(256) NOT NULL,
    CreatedOn DATETIME NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedOn DATETIME NULL DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO [dbo].[Users]([Username], [Email], [Password], [CreatedOn], [UpdatedOn]) VALUES('admin', 'admin@scaleapp.com', 'password', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP)
INSERT INTO [dbo].[Users]([Username], [Email], [Password], [CreatedOn], [UpdatedOn]) VALUES('manager', 'manager@scaleapp.com', 'password', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP)
INSERT INTO [dbo].[Users]([Username], [Email], [Password], [CreatedOn], [UpdatedOn]) VALUES('user', 'user@scaleapp.com', 'password', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP)

DROP TABLE IF EXISTS UserHasRoles;

CREATE TABLE UserHasRoles(
    RoleId INT NOT NULL,
    UserId INT NOT NULL,
    PRIMARY KEY(RoleId, UserId)
);

ALTER TABLE UserHasRoles ADD CONSTRAINT user_has_roles_roleId FOREIGN KEY(RoleId) REFERENCES Roles(Id);
ALTER TABLE UserHasRoles ADD CONSTRAINT user_has_roles_userId FOREIGN KEY(UserId) REFERENCES Users(Id);

INSERT INTO [dbo].[UserHasRoles]([RoleId], [UserId]) VALUES(1, 1)
INSERT INTO [dbo].[UserHasRoles]([RoleId], [UserId]) VALUES(2, 2)
INSERT INTO [dbo].[UserHasRoles]([RoleId], [UserId]) VALUES(3, 3)

DROP TABLE IF EXISTS Scale;

CREATE TABLE Scale(
    Id INT CHECK (id > 0) NOT NULL IDENTITY PRIMARY KEY,
    [Name] VARCHAR(256) NOT NULL,
    [Location] VARCHAR(256) NOT NULL,
    ScaleMfg VARCHAR(256) NOT NULL,
    ScaleModel VARCHAR(256) NOT NULL,
    ScaleSerialNo VARCHAR(256) NOT NULL,
    ScaleProperties VARCHAR(256) NOT NULL,
    DateInstalled DATETIME NOT NULL,
    Installer VARCHAR(256) NOT NULL,
    DateCalibrated DATETIME NOT NULL,
    CalibratedBy VARCHAR(256) NOT NULL,
    Notes VARCHAR(max) NOT NULL
);

INSERT INTO [dbo].[Scale]([Name],[Location],[ScaleMfg],[ScaleModel],[ScaleSerialNo],[ScaleProperties],[DateInstalled],[Installer],[DateCalibrated],[CalibratedBy],[Notes])
VALUES('Scale 1', 'Site 1 - Inbound', 'Quality Scales, Inc', 'Weigh Master 100', '123asxdqq2-43i', '{[name=value], [name=value]}', CURRENT_TIMESTAMP, 'Certified Installer 10905', CURRENT_TIMESTAMP, 'Certified Installer 10905', 'Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...')
INSERT INTO [dbo].[Scale]([Name],[Location],[ScaleMfg],[ScaleModel],[ScaleSerialNo],[ScaleProperties],[DateInstalled],[Installer],[DateCalibrated],[CalibratedBy],[Notes])
VALUES('Scale 2', 'Site 1 - Outbound', 'Quality Scales, Inc', 'Weigh Master 100', '123asxdqq2-44i', '{[name=value], [name=value]}', CURRENT_TIMESTAMP, 'Certified Installer 10905', CURRENT_TIMESTAMP, 'Certified Installer 10905', 'Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...')
INSERT INTO [dbo].[Scale]([Name],[Location],[ScaleMfg],[ScaleModel],[ScaleSerialNo],[ScaleProperties],[DateInstalled],[Installer],[DateCalibrated],[CalibratedBy],[Notes])
VALUES('Scale 3', 'Installed On Trailer 100', 'Quality Scales, Inc', 'Weigh On The Go', '432hfgfg-22v', '{[name=value], [name=value]}', CURRENT_TIMESTAMP, 'Certified Trailer Mechanic 7', CURRENT_TIMESTAMP, 'Certified Trailer Mechanic 7', 'Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...')
INSERT INTO [dbo].[Scale]([Name],[Location],[ScaleMfg],[ScaleModel],[ScaleSerialNo],[ScaleProperties],[DateInstalled],[Installer],[DateCalibrated],[CalibratedBy],[Notes])
VALUES('Scale 4', 'Portable Scale', 'Quality Scales, Inc', 'Jump Out Scale Pro', 'zzz333-olered1', '{[name=value], [name=value]}', CURRENT_TIMESTAMP, 'Jumpout Boy 1', CURRENT_TIMESTAMP, 'Jumpout Boy 1', 'Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...')


DROP TABLE IF EXISTS ScaleTicket;

CREATE TABLE ScaleTicket(
    Id INT NOT NULL IDENTITY PRIMARY KEY,
    ScaleId INT NOT NULL,
    CreatedOn DATETIME NULL DEFAULT CURRENT_TIMESTAMP,
    CreatedBy INT NOT NULL,
    TruckId VARCHAR(255) NOT NULL,
    DriverId VARCHAR(255) NOT NULL,
    WeightDriveAxle INT NOT NULL,
    WeightSteerAxle INT NOT NULL,
    WeightTrailerAxle INT NOT NULL,
    VehicleType INT NOT NULL,
    Notes VARCHAR(max) NOT NULL
);

ALTER TABLE ScaleTicket ADD CONSTRAINT scale_ticket_scale_id FOREIGN KEY(ScaleId) REFERENCES Scale(Id);
ALTER TABLE ScaleTicket ADD CONSTRAINT scale_ticket_created_by FOREIGN KEY(CreatedBy) REFERENCES Users(Id);

INSERT INTO [dbo].[ScaleTicket]([ScaleId],[CreatedOn],[CreatedBy],[TruckId],[DriverId],[WeightDriveAxle],[WeightSteerAxle],[WeightTrailerAxle],[VehicleType],[Notes])
VALUES(1, CURRENT_TIMESTAMP, 3, 'Good Ole Rig #5, Trl# 100', 'Justin Case', 6500, 12007, 10003, 1, 'Empty Trl Check In')
INSERT INTO [dbo].[ScaleTicket]([ScaleId],[CreatedOn],[CreatedBy],[TruckId],[DriverId],[WeightDriveAxle],[WeightSteerAxle],[WeightTrailerAxle],[VehicleType],[Notes])
VALUES(2, CURRENT_TIMESTAMP, 3, 'Good Ole Rig #5, Trl# 100', 'Justin Case', 11999, 33999, 33999, 1, 'Headed Out, Right at the limit!')
INSERT INTO [dbo].[ScaleTicket]([ScaleId],[CreatedOn],[CreatedBy],[TruckId],[DriverId],[WeightDriveAxle],[WeightSteerAxle],[WeightTrailerAxle],[VehicleType],[Notes])
VALUES(3, CURRENT_TIMESTAMP, 3, 'Good Ole Rig #5, Trl# 100', 'Justin Case', 11999, 33979, 33959, 1, 'Keeping A check while in route! Burned a bit of fuel!')
INSERT INTO [dbo].[ScaleTicket]([ScaleId],[CreatedOn],[CreatedBy],[TruckId],[DriverId],[WeightDriveAxle],[WeightSteerAxle],[WeightTrailerAxle],[VehicleType],[Notes])
VALUES(1, CURRENT_TIMESTAMP, 3, 'The Brown Pete, Trk #53107, Trl# 102', 'Phil Dees', 5000, 10000, 10000, 1, 'Empty Trl Check In')
INSERT INTO [dbo].[ScaleTicket]([ScaleId],[CreatedOn],[CreatedBy],[TruckId],[DriverId],[WeightDriveAxle],[WeightSteerAxle],[WeightTrailerAxle],[VehicleType],[Notes])
VALUES(2, CURRENT_TIMESTAMP, 3, 'The Brown Pete, Trk #53107, Trl# 102', 'Phil Dees', 11007, 33765, 29781, 1, 'Headed Out, All Good')
INSERT INTO [dbo].[ScaleTicket]([ScaleId],[CreatedOn],[CreatedBy],[TruckId],[DriverId],[WeightDriveAxle],[WeightSteerAxle],[WeightTrailerAxle],[VehicleType],[Notes])
VALUES(1, CURRENT_TIMESTAMP, 3, 'POS Trk #275, Trl# 105', 'Sal Tyass', 5000, 10000, 10000, 1, 'Empty Trl Check In')
INSERT INTO [dbo].[ScaleTicket]([ScaleId],[CreatedOn],[CreatedBy],[TruckId],[DriverId],[WeightDriveAxle],[WeightSteerAxle],[WeightTrailerAxle],[VehicleType],[Notes])
VALUES(1, CURRENT_TIMESTAMP, 3, 'POS Trk #275, Trl# 105', 'Sal Tyass', 12001, 34001, 34001, 1, 'Overweight! Remove rocks and reweigh!')