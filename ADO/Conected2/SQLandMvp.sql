CREATE DATABASE Acounting;
GO

-- Делаем созданную базу данных текущей

USE Acounting
GO

-- Создаем таблицу

CREATE TABLE Worker
(
	Id int NOT NULL PRIMARY KEY,
	--IdWorker int Not Null PRIMARY KEY,
	FirstName varchar(50) not null,
	LastName varchar(50) not null,
	Patronymic varchar(50),
	DateBirth date not null,
	HiringNumber int not null,
	DismissalNumber int
);
GO

INSERT INTO Worker (Id, FirstName, LastName, Patronymic, DateBirth, HiringNumber, DismissalNumber)VALUES (1, 'Artem', 'Krol', 'Grigorivich',CAST(N'1983-04-4' AS DATE), 111101, null)
INSERT INTO Worker (Id, FirstName, LastName, Patronymic, DateBirth, HiringNumber, DismissalNumber)VALUES (2, 'Inga', 'Greenberg', 'Grigorivna',CAST(N'1985-03-29' AS DATE), 111102, null)
go

CREATE TABLE Foto
(
	Id int NOT NULL PRIMARY KEY,
	WorkerFK int not null,
	[Name] varchar(100) not null,
	TheFoto image not null,
	foreign key (WorkerFK) references Worker(Id)
);
GO

INSERT INTO Foto (Id, WorkerFK, [Name], TheFoto)VALUES (1, 1, '34.jpg',  
(SELECT *
FROM   OPENROWSET(BULK 'C:\Users\MOB_master\Desktop\programmi oop\SQL\HWAdo2\HWAdo2\bin\Debug\34.jpg', SINGLE_BLOB) IMG_DATA))
INSERT INTO Foto (Id, WorkerFK, [Name], TheFoto)VALUES (2, 2, '02.jpg',  
(SELECT *
FROM   OPENROWSET(BULK 'C:\Users\MOB_master\Desktop\programmi oop\SQL\HWAdo2\HWAdo2\bin\Debug\02.jpg', SINGLE_BLOB) IMG_DATA))

go

 SELECT W.Id, W.FirstName, W.LastName, W.Patronymic, W.DateBirth, W.DateBirth, W.HiringNumber, W.DismissalNumber, Foto.[Name] as AdressFoto, Foto.TheFoto as [image] 
 FROM Worker W, Foto 
 WHERE W.Id = Foto.Id
go
