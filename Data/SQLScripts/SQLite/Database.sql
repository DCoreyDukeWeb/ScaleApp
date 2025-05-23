
CREATE DATABASE [ScaleTickets]
 

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
then
CALL `ScaleTickets`.`sp_fulltext_database`(p_action = 'enable');
end if;
 

USE `ScaleTickets`;
 

DROP TABLE IF EXISTS Applications;

-- SQLINES FOR EVALUATION USE ONLY (14 DAYS)
CREATE TABLE Applications(
    Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `Name` VARCHAR(256) NOT NULL,
    RelativeURI VARCHAR(256) NULL,
    IndexURL VARCHAR(256) NULL,
    DirectoryPath VARCHAR(512) NULL,
    RepositoryUrl VARCHAR(512) NULL,
    ApplicationType VARCHAR(128) NULL,
    CurrentVersion VARCHAR(28) NULL DEFAULT '1.0.0.0',
    CreatedOn DATETIME(3) NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedOn DATETIME(3) NULL DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO `Applications`(`Name`,`RelativeURI`,`IndexURL`,`DirectoryPath`,`RepositoryUrl`,`ApplicationType`,`CurrentVersion`,`CreatedOn`,`UpdatedOn`)
 VALUES('Admin Dashboard', '/admin','admin/index','/<Path To Directory>','/<URL to repository>','Windows','1.0.0.0',CURRENT_TIMESTAMP,CURRENT_TIMESTAMP);
 INSERT INTO `Applications`(`Name`,`RelativeURI`,`IndexURL`,`DirectoryPath`,`RepositoryUrl`,`ApplicationType`,`CurrentVersion`,`CreatedOn`,`UpdatedOn`)
 VALUES('Scale UI', '/scaleui','scaleui/index','/<Path To Directory>','/<URL to repository>','Windows','1.0.0.0',CURRENT_TIMESTAMP,CURRENT_TIMESTAMP);
 INSERT INTO `Applications`(`Name`,`RelativeURI`,`IndexURL`,`DirectoryPath`,`RepositoryUrl`,`ApplicationType`,`CurrentVersion`,`CreatedOn`,`UpdatedOn`)
 VALUES('Web API', '/api','api/index','/<Path To Directory>','/<URL to repository>','WebApi','1.0.0.0',CURRENT_TIMESTAMP,CURRENT_TIMESTAMP);

DROP TABLE IF EXISTS Roles;

CREATE TABLE Roles(
    Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `Name` VARCHAR(256) NOT NULL
);

INSERT INTO `Roles`(`Name`) VALUES('Admin');
INSERT INTO `Roles`(`Name`) VALUES('Manager');
INSERT INTO `Roles`(`Name`) VALUES('User');


DROP TABLE IF EXISTS `Permissions`;

CREATE TABLE `Permissions`(
    Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `Name` VARCHAR(256) NOT NULL
);

INSERT INTO `Permissions`(`Name`) VALUES('Create Scale Ticket');
INSERT INTO `Permissions`(`Name`) VALUES('View Scale Ticket');
INSERT INTO `Permissions`(`Name`) VALUES('Edit Scale Ticket');
INSERT INTO `Permissions`(`Name`) VALUES('Delete Scale Ticket');

DROP TABLE IF EXISTS RoleHasPermissions;

CREATE TABLE RoleHasPermissions(
    RoleId INT NOT NULL,
    PermissionId INT NOT NULL,
    PRIMARY KEY(RoleId, PermissionId)
);

ALTER TABLE RoleHasPermissions ADD CONSTRAINT role_has_permissions_roleId FOREIGN KEY(RoleId) REFERENCES Roles(Id);
ALTER TABLE RoleHasPermissions ADD CONSTRAINT role_has_permissions_permissionId FOREIGN KEY(PermissionId) REFERENCES Permissions(Id);

INSERT INTO `RoleHasPermissions`(`RoleId`, `PermissionId`) VALUES(1, 1);
INSERT INTO `RoleHasPermissions`(`RoleId`, `PermissionId`) VALUES(1, 2);
INSERT INTO `RoleHasPermissions`(`RoleId`, `PermissionId`) VALUES(1, 3);
INSERT INTO `RoleHasPermissions`(`RoleId`, `PermissionId`) VALUES(1, 4);
INSERT INTO `RoleHasPermissions`(`RoleId`, `PermissionId`) VALUES(2, 1);
INSERT INTO `RoleHasPermissions`(`RoleId`, `PermissionId`) VALUES(2, 2);
INSERT INTO `RoleHasPermissions`(`RoleId`, `PermissionId`) VALUES(2, 3);
INSERT INTO `RoleHasPermissions`(`RoleId`, `PermissionId`) VALUES(2, 4);
INSERT INTO `RoleHasPermissions`(`RoleId`, `PermissionId`) VALUES(3, 1);
INSERT INTO `RoleHasPermissions`(`RoleId`, `PermissionId`) VALUES(3, 2);


DROP TABLE IF EXISTS Users;

CREATE TABLE Users(
    Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    Username VARCHAR(255) NOT NULL,
    Email VARCHAR(256) NOT NULL,
    Password VARCHAR(256) NOT NULL,
    CreatedOn DATETIME(3) NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedOn DATETIME(3) NULL DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO `Users`(`Username`, `Email`, `Password`, `CreatedOn`, `UpdatedOn`) VALUES('admin', 'admin@scaleapp.com', 'password', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);
INSERT INTO `Users`(`Username`, `Email`, `Password`, `CreatedOn`, `UpdatedOn`) VALUES('manager', 'manager@scaleapp.com', 'password', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);
INSERT INTO `Users`(`Username`, `Email`, `Password`, `CreatedOn`, `UpdatedOn`) VALUES('user', 'user@scaleapp.com', 'password', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);

DROP TABLE IF EXISTS UserHasRoles;

CREATE TABLE UserHasRoles(
    RoleId INT NOT NULL,
    UserId INT NOT NULL,
    PRIMARY KEY(RoleId, UserId)
);

ALTER TABLE UserHasRoles ADD CONSTRAINT user_has_roles_roleId FOREIGN KEY(RoleId) REFERENCES Roles(Id);
ALTER TABLE UserHasRoles ADD CONSTRAINT user_has_roles_userId FOREIGN KEY(UserId) REFERENCES Users(Id);

INSERT INTO `UserHasRoles`(`RoleId`, `UserId`) VALUES(1, 1);
INSERT INTO `UserHasRoles`(`RoleId`, `UserId`) VALUES(2, 2);
INSERT INTO `UserHasRoles`(`RoleId`, `UserId`) VALUES(3, 3);

DROP TABLE IF EXISTS `Locations`;

CREATE TABLE `Locations`(
	Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	`Name` VARCHAR(256) NULL,
	`Address1` VARCHAR(256) NULL,
	`Address2` VARCHAR(256) NULL,
	`City` VARCHAR(256) NULL,
	`State` VARCHAR(2) NULL,
	`Zip` VARCHAR(12) NULL,
	`Country` VARCHAR(28) NULL,
	`LatLong` VARCHAR(128) NULL,
	CreatedOn DATETIME(3) NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedOn DATETIME(3) NULL DEFAULT CURRENT_TIMESTAMP,
	Notes LONGTEXT NULL
);

INSERT INTO `Locations`(`Name`, `Address1`, `Address2`, `City`, `State`, `Zip`, `Country`, `LatLong`, `CreatedOn`, `UpdatedOn`, `Notes`)
VALUES('Site 1 GS', '123 Site Rd.', 'Guard Shack', 'Mobile', 'AL', '36686', 'US', '[123.456, 987.654]', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, 'Scale Site 1 Guard Shack');
INSERT INTO `Locations`(`Name`, `Address1`, `Address2`, `City`, `State`, `Zip`, `Country`, `LatLong`, `CreatedOn`, `UpdatedOn`, `Notes`)
VALUES('Site 1 MO', '123 Site Rd.', 'Main Office', 'Mobile', 'AL', '36686', 'US', '[123.456, 987.321]', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, 'Scale Site 1 Main Office');
INSERT INTO `Locations`(`Name`, `Address1`, `Address2`, `City`, `State`, `Zip`, `Country`, `LatLong`, `CreatedOn`, `UpdatedOn`, `Notes`)
VALUES('Site 2', '456 State HWY 43.', 'Guard Shack', 'Mt Vernon', 'AL', '36686', 'US', '[102.356, 987.654]', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, 'Scale Site 2 Dirt Pit');

DROP TABLE IF EXISTS Contacts;

CREATE TABLE Contacts(
	Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	`Name` VARCHAR(256)  NULL,
	`Phone1` VARCHAR(28) NULL,
	`Phone2` VARCHAR(28) NULL,
	`Fax` VARCHAR(28)    NULL,
	`Email1` VARCHAR(128) NULL,
	`Email2` VARCHAR(128) NULL,
	`Url` VARCHAR(128)    NULL,
	`LocationId` INT NULL,
    CreatedOn DATETIME(3) NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedOn DATETIME(3) NULL DEFAULT CURRENT_TIMESTAMP,
	LastContacted DATETIME(3) NULL DEFAULT CURRENT_TIMESTAMP,
	Notes LONGTEXT NULL
);

INSERT INTO `Contacts`(`Name`, `Phone1`, `Phone2`, `Fax`, `Email1`, `Email2`, `Url`, `LocationId`, `CreatedOn`, `UpdatedOn`, `LastContacted`, `Notes`)
VALUES('John Smith', '(123)456-7890', '(123)456-7891', '(123)456-7892', 'jsmite@site1.com', 'jsmith@outlook.com', 'facebook.com/jsmith', 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, 'Scale Site 1 Guard');
INSERT INTO `Contacts`(`Name`, `Phone1`, `Phone2`, `Fax`, `Email1`, `Email2`, `Url`, `LocationId`, `CreatedOn`, `UpdatedOn`, `LastContacted`, `Notes`)
VALUES('James Smith', '(123)456-7890', '(123)456-7891', '(123)456-7892', 'jasmith@site1.com', 'jasmith@outlook.com', 'facebook.com/jasmith', 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, 'Scale Site 1 Manager');
INSERT INTO `Contacts`(`Name`, `Phone1`, `Phone2`, `Fax`, `Email1`, `Email2`, `Url`, `LocationId`, `CreatedOn`, `UpdatedOn`, `LastContacted`, `Notes`)
VALUES('Jim Smith', '(123)456-7894', '(123)456-7895', '(123)456-7896', 'jimsmith@site1.com', 'jimsmith@outlook.com', 'facebook.com/jimsmith', 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, 'Scale Site 2 Guard');


DROP TABLE IF EXISTS Customers;

/* SQLINES DEMO *** ntId */
CREATE TABLE Customers(
	Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	`Name` VARCHAR(256)  NULL,
	LocationId INT NULL,
	ContactId INT NULL,
    CreatedOn DATETIME(3) NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedOn DATETIME(3) NULL DEFAULT CURRENT_TIMESTAMP,
	Notes LONGTEXT NULL
);

ALTER TABLE Customers ADD CONSTRAINT customer_location_id FOREIGN KEY(LocationId) REFERENCES Locations(Id);
ALTER TABLE Customers ADD CONSTRAINT customer_contact_id FOREIGN KEY(ContactId) REFERENCES Contacts(Id);

INSERT INTO `Customers`(`Name`,`LocationId`,`ContactId`,`CreatedOn`,`UpdatedOn`,`Notes`)
VALUES('Customer 1', 1, 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, 'Customer 1');

DROP TABLE IF EXISTS Scales;

CREATE TABLE Scales(
    Id INT CHECK (id > 0) NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `Name` VARCHAR(256) NOT NULL,
    `LocationId` INT NOT NULL,
    ScaleMfg VARCHAR(256) NOT NULL,
    ScaleModel VARCHAR(256) NOT NULL,
    ScaleSerialNo VARCHAR(256) NOT NULL,
    ScaleProperties VARCHAR(256) NOT NULL,
    DateInstalled DATETIME(3) NOT NULL,
    Installer VARCHAR(256) NOT NULL,
    DateCalibrated DATETIME(3) NOT NULL,
    CalibratedBy VARCHAR(256) NOT NULL,
    Notes LONGTEXT NOT NULL
);

ALTER TABLE Scales ADD CONSTRAINT scale_location_id FOREIGN KEY(LocationId) REFERENCES Locations(Id);

INSERT INTO `Scales`(`Name`,`LocationId`,`ScaleMfg`,`ScaleModel`,`ScaleSerialNo`,`ScaleProperties`,`DateInstalled`,`Installer`,`DateCalibrated`,`CalibratedBy`,`Notes`)
VALUES('Scale 1', 1, 'Quality Scales, Inc', 'Weigh Master 100', '123asxdqq2-43i', '{[name=value], [name=value]}', CURRENT_TIMESTAMP, 'Certified Installer 10905', CURRENT_TIMESTAMP, 'Certified Installer 10905', 'Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...');
INSERT INTO `Scales`(`Name`,`LocationId`,`ScaleMfg`,`ScaleModel`,`ScaleSerialNo`,`ScaleProperties`,`DateInstalled`,`Installer`,`DateCalibrated`,`CalibratedBy`,`Notes`)
VALUES('Scale 2', 1, 'Quality Scales, Inc', 'Weigh Master 100', '123asxdqq2-44i', '{[name=value], [name=value]}', CURRENT_TIMESTAMP, 'Certified Installer 10905', CURRENT_TIMESTAMP, 'Certified Installer 10905', 'Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...');
INSERT INTO `Scales`(`Name`,`LocationId`,`ScaleMfg`,`ScaleModel`,`ScaleSerialNo`,`ScaleProperties`,`DateInstalled`,`Installer`,`DateCalibrated`,`CalibratedBy`,`Notes`)
VALUES('Scale 3', 3, 'Quality Scales, Inc', 'Weigh On The Go', '432hfgfg-22v', '{[name=value], [name=value]}', CURRENT_TIMESTAMP, 'Certified Trailer Mechanic 7', CURRENT_TIMESTAMP, 'Certified Trailer Mechanic 7', 'Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...');
INSERT INTO `Scales`(`Name`,`LocationId`,`ScaleMfg`,`ScaleModel`,`ScaleSerialNo`,`ScaleProperties`,`DateInstalled`,`Installer`,`DateCalibrated`,`CalibratedBy`,`Notes`)
VALUES('Scale 4', 3, 'Quality Scales, Inc', 'Jump Out Scale Pro', 'zzz333-olered1', '{[name=value], [name=value]}', CURRENT_TIMESTAMP, 'Jumpout Boy 1', CURRENT_TIMESTAMP, 'Jumpout Boy 1', 'Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...');


DROP TABLE IF EXISTS ScaleTickets;

CREATE TABLE ScaleTickets(
    Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    ScaleId INT NOT NULL,
    CreatedOn DATETIME(3) NULL DEFAULT CURRENT_TIMESTAMP,
    CreatedBy INT NOT NULL,
	CustomerId INT NOT NULL,
    TruckId VARCHAR(255) NOT NULL,
    DriverId VARCHAR(255) NOT NULL,
    WeightTare INT NOT NULL,
    WeightNet INT NOT NULL,
    WeightGross INT NOT NULL,
    VehicleType INT NOT NULL,
    Notes LONGTEXT NOT NULL
);

ALTER TABLE ScaleTickets ADD CONSTRAINT scale_ticket_scale_id FOREIGN KEY(ScaleId) REFERENCES Scale(Id);
ALTER TABLE ScaleTickets ADD CONSTRAINT scale_ticket_created_by FOREIGN KEY(CreatedBy) REFERENCES Users(Id);

INSERT INTO `ScaleTickets`(`ScaleId`,`CreatedOn`,`CreatedBy`,`CustomerId`,`TruckId`,`DriverId`,`WeightTare`,`WeightNet`,`WeightGross`,`VehicleType`,`Notes`)
VALUES(1, CURRENT_TIMESTAMP, 3, 1, 'Good Ole Rig #5, Trl# 100', 'Justin Case', 6500, 12007, 10003, 1, 'Empty Trl Check In');
INSERT INTO `ScaleTickets`(`ScaleId`,`CreatedOn`,`CreatedBy`,`CustomerId`,`TruckId`,`DriverId`,`WeightTare`,`WeightNet`,`WeightGross`,`VehicleType`,`Notes`)
VALUES(2, CURRENT_TIMESTAMP, 3, 1, 'Good Ole Rig #5, Trl# 100', 'Justin Case', 11999, 33999, 33999, 1, 'Headed Out, Right at the limit!');
INSERT INTO `ScaleTickets`(`ScaleId`,`CreatedOn`,`CreatedBy`,`CustomerId`,`TruckId`,`DriverId`,`WeightTare`,`WeightNet`,`WeightGross`,`VehicleType`,`Notes`)
VALUES(3, CURRENT_TIMESTAMP, 3, 1, 'Good Ole Rig #5, Trl# 100', 'Justin Case', 11999, 33979, 33959, 1, 'Keeping A check while in route! Burned a bit of fuel!');
INSERT INTO `ScaleTickets`(`ScaleId`,`CreatedOn`,`CreatedBy`,`CustomerId`,`TruckId`,`DriverId`,`WeightTare`,`WeightNet`,`WeightGross`,`VehicleType`,`Notes`)
VALUES(1, CURRENT_TIMESTAMP, 3, 1, 'The Brown Pete, Trk #53107, Trl# 102', 'Phil Dees', 5000, 10000, 10000, 1, 'Empty Trl Check In');
INSERT INTO `ScaleTickets`(`ScaleId`,`CreatedOn`,`CreatedBy`,`CustomerId`,`TruckId`,`DriverId`,`WeightTare`,`WeightNet`,`WeightGross`,`VehicleType`,`Notes`)
VALUES(2, CURRENT_TIMESTAMP, 3, 1, 'The Brown Pete, Trk #53107, Trl# 102', 'Phil Dees', 11007, 33765, 29781, 1, 'Headed Out, All Good');
INSERT INTO `ScaleTickets`(`ScaleId`,`CreatedOn`,`CreatedBy`,`CustomerId`,`TruckId`,`DriverId`,`WeightTare`,`WeightNet`,`WeightGross`,`VehicleType`,`Notes`)
VALUES(1, CURRENT_TIMESTAMP, 3, 1, 'POS Trk #275, Trl# 105', 'Sal Tyass', 5000, 10000, 10000, 1, 'Empty Trl Check In');
INSERT INTO `ScaleTickets`(`ScaleId`,`CreatedOn`,`CreatedBy`,`CustomerId`,`TruckId`,`DriverId`,`WeightTare`,`WeightNet`,`WeightGross`,`VehicleType`,`Notes`)
VALUES(1, CURRENT_TIMESTAMP, 3, 1, 'POS Trk #275, Trl# 105', 'Sal Tyass', 12001, 34001, 34001, 1, 'Overweight! Remove rocks and reweigh!');