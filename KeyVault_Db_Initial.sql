DROP DATABASE IF EXISTS KeyVaultDB;
CREATE DATABASE KeyVaultDB;
USE KeyVaultDB;

CREATE TABLE Vault
(
  Id uniqueidentifier NOT NULL PRIMARY KEY,
  Name varchar(max) NOT NULL,
  IsDeleted bit DEFAULT 0 NOT NULL
);
GO

CREATE TABLE Secret
(
  Id uniqueidentifier NOT NULL PRIMARY KEY,
  Vault_Id uniqueidentifier NOT NULL FOREIGN KEY REFERENCES Vault(Id),
  Name varchar(max) NOT NULL,
  Created datetime NOT NULL,
  CreatedBy varchar(max) NOT NULL
);
GO

CREATE TABLE SecretValue
(
  Id uniqueidentifier NOT NULL PRIMARY KEY,
  Secret_Id uniqueidentifier NOT NULL FOREIGN KEY REFERENCES Secret(Id),
  ExpirationDate datetime,
  ActivationDate datetime,
  IsEnabled bit DEFAULT 1 NOT NULL,
  Value varbinary(128) NOT NULL
)
GO

CREATE TABLE SecretValueLog
(
  Id int NOT NULL PRIMARY KEY,
  Created datetime NOT NULL,
  LastOperationTimestamp datetime NOT NULL,
  CreatedBy varchar(max) NOT NULL,
  ModifiedBy varchar(max) NOT NULL,
  Secret_Id uniqueidentifier NOT NULL FOREIGN KEY REFERENCES Secret(Id),
  SecretValue_Id uniqueidentifier NOT NULL FOREIGN KEY REFERENCES SecretValue(Id)
)
GO

CREATE TABLE Policy
(
    Id uniqueidentifier NOT NULL PRIMARY KEY,
    Name varchar(max) NOT NULL,
)
GO

CREATE TABLE VaultPolicy(
  Id uniqueidentifier NOT NULL PRIMARY KEY,
  Policy_Id uniqueidentifier NOT NULL FOREIGN KEY REFERENCES Policy(Id),
  Vault_Id uniqueidentifier NOT NULL FOREIGN KEY REFERENCES Vault(Id),
  Object_Id uniqueidentifier NOT NULL
)
GO

INSERT INTO Vault (Id, name, IsDeleted)
VALUES ('7ff3f28a-4780-43ce-bbfd-cf8e652c9cd3', 'TEST_VAULT', 0)