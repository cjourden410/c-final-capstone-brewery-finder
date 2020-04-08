
-- Switch to the system (aka master) database
USE master;
GO

-- Delete the DemoDB Database (IF EXISTS)
IF EXISTS(select * from sys.databases where name='DemoDB')
DROP DATABASE DemoDB;
GO

-- Create a new DemoDB Database
CREATE DATABASE DemoDB;
GO

-- Switch to the DemoDB Database
USE DemoDB
GO

BEGIN TRANSACTION;

CREATE TABLE users
(
	id			int			identity(1,1),
	username	varchar(50)	not null,
	password	varchar(50)	not null,
	salt		varchar(50)	not null,
	role		varchar(50)	default('user'),

	constraint pk_users primary key (id)
);

-- Add breweries table
CREATE TABLE breweries
(
	id		    int		    identity(1,1),
	name	    varchar(50)	not null,
	brewer	    varchar(50)	not null,
	userID	    int	        not null,
	username	varchar(50)	not null,
	hours		varchar(100),
	contactInfo varchar(50),
	address     varchar(100),
	history		varchar(200),
	images		varchar(200),
	isActive	bit default (1),

	constraint pk_breweries primary key (id),
    constraint fk_userID FOREIGN KEY (userID) REFERENCES users(id)
);

COMMIT TRANSACTION;