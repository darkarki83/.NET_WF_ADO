-- Создаем базу данных

IF DB_ID('Sales') IS NOT NULL
BEGIN
	USE master
    ALTER DATABASE Sales SET single_user with rollback immediate;
    DROP DATABASE Sales;
END
GO

CREATE DATABASE Sales;
GO


-- Делаем созданную базу данных текущей

USE Sales
GO


-- Создаем таблицы

CREATE TABLE Customers
(
    Id bigint NOT NULL PRIMARY KEY,
    Name nvarchar(50)
);
GO

CREATE TABLE Salesmen
(
    Id bigint NOT NULL PRIMARY KEY,
    Name nvarchar(50)
);
GO

CREATE TABLE Sales
(
    Id bigint NOT NULL PRIMARY KEY,
    CustomerFk bigint,
    SalesmanFk bigint,
    Amt int,

	FOREIGN KEY (CustomerFk) REFERENCES Customers(Id)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
	FOREIGN KEY (SalesmanFk) REFERENCES Salesmen(Id)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);
GO


-- Заполняем таблицы

INSERT INTO Customers VALUES (1, N'A');
INSERT INTO Customers VALUES (2, N'B');
INSERT INTO Customers VALUES (3, N'C');
GO

INSERT INTO Salesmen VALUES (1, N'X');
INSERT INTO Salesmen VALUES (2, N'Y');
INSERT INTO Salesmen VALUES (3, N'Z');
GO

INSERT INTO Sales VALUES (1, 1, 1, 10);
INSERT INTO Sales VALUES (2, 1, 1, 20);
INSERT INTO Sales VALUES (3, 2, 1, 30);
INSERT INTO Sales VALUES (4, 2, 2, 40);
INSERT INTO Sales VALUES (5, 3, 1, 50);
INSERT INTO Sales VALUES (6, 3, 3, 60);
GO
