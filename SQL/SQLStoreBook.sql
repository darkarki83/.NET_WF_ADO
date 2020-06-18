CREATE DATABASE BookStore;
GO

-- ������ ��������� ���� ������ �������

USE BookStore
GO

-- ������� �������

CREATE TABLE Store
(
	Id int NOT NULL PRIMARY KEY,
	--IdWorker int Not Null PRIMARY KEY,
	Code int,
	New bit,
	Name varchar(255),
	Price money,
	--Izd varchar(255),
	Pages int,
	[Format] varchar(255),
	[Date] date,
	--Pressrun int,
	Themes varchar(255),
	Category varchar(255)
);
GO

-- ��������� �������

INSERT Store (Id, Code, New, Name, Price, Izd, Pages, [Format], [Date], Pressrun, Themes, Category) VALUES (1, 4704, 0, N'����������� ������ �� ������������ ����������: 3� ���., ���.', 17.4000, N'BHV ����', 640, N'70�100/16', CAST(N'2000-02-23' AS date), 10000, N'������������� �� � �����', N'��������')
INSERT Store (Id, Code, New, Name, Price, Izd, Pages, [Format], [Date], Pressrun, Themes, Category) VALUES (2, 5110, 0, N'���������� �������� �����������. ������������ ��', 15.5100, N'BHV �.-���������', 400, N'70�100/16', CAST(N'2000-07-24' AS date), 5000, N'������������� �� � �����', N'��������')
INSERT Store (Id, Code, New, Name, Price, Izd, Pages, [Format], [Date], Pressrun, Themes, Category) VALUES (3, 4316, 0, N'������ ������ �� ��', 19.9100, N'BHV �.-���������', 440, N'70�100/16', CAST(N'2004-01-11' AS date), 3000, N'������������� �� � �����', N'��������')
INSERT Store (Id, Code, New, Name, Price, Izd, Pages, [Format], [Date], Pressrun, Themes, Category) VALUES (4, 5516, 0, N'I����������-7. ����������������� ���������� ���i���� ��� ���i� 7 �����', 9.0000, N'DiaSoft', 208, N'70�100/16', CAST(N'2003-05-26' AS date), 2000, N'������������� �� � �����', N'��������')
INSERT Store (Id, Code, New, Name, Price, Izd, Pages, [Format], [Date], Pressrun, Themes, Category) VALUES (5, 4043, 1, N'������ �� ������������ ����������. �����������', 19.0000, N'DiaSoft', 584, N'84�108/16', CAST(N'1999-08-05' AS date), 3000, N'������������� �� � �����', N'��������')
INSERT Store (Id, Code, New, Name, Price, Izd, Pages, [Format], [Date], Pressrun, Themes, Category) VALUES (6, 5228, 0, N'�������� ������� ������������ ����������', 29.0000, N'DiaSoft', 720, N'70�100/16', CAST(N'2000-10-25' AS date), 2000, N'������������� �� � �����', N'��������')
INSERT Store (Id, Code, New, Name, Price, Izd, Pages, [Format], [Date], Pressrun, Themes, Category) VALUES (7, 4756, 0, N'������ i���������� ���������i��i �i����:��������� �� �i����i�i', 5.0000, N'DiaSoft UP', 160, N'84�108/16', NULL, 0, N'������������� �� � �����', N'��������')
INSERT Store (Id, Code, New, Name, Price, Izd, Pages, [Format], [Date], Pressrun, Themes, Category) VALUES (8, 4985, 0, N'����� �������������� ������������ � ������ �� �� 24 ����, 2-� ���.', 18.9000, N'�������', 288, N'70�100/16', CAST(N'2000-07-07' AS date), 5000, N'������������� �� � �����', N'��������')
INSERT Store (Id, Code, New, Name, Price, Izd, Pages, [Format], [Date], Pressrun, Themes, Category) VALUES (9, 5141, 0, N'��������� ������ � ���������.', 37.8000, N'�������', 384, N'70�100/16', CAST(N'2000-09-29' AS date), 5000, N'������������� �� � �����', N'��������')
INSERT Store (Id, Code, New, Name, Price, Izd, Pages, [Format], [Date], Pressrun, Themes, Category) VALUES (10, 3055, 0, N'�������� ����������� ������ �� ����������', 18.4800, N'����', 654, N'70�100\16', CAST(N'1998-09-01' AS date), 10000, N'������������� �� � �����', N'��������')
INSERT Store (Id, Code, New, Name, Price, Izd, Pages, [Format], [Date], Pressrun, Themes, Category) VALUES (11, 4712, 0, N'�������� ����������� �� ������ � ��������', 19.2900, N'����', 528, N'70�100/16', CAST(N'2000-03-21' AS date), 10000, N'������������� �� � �����', N'��������')
INSERT Store (Id, Code, New, Name, Price, Izd, Pages, [Format], [Date], Pressrun, Themes, Category) VALUES (12, 4241, 0, N'�� ��� "��������",7 � �������', 13.2000, N'����������', 318, N'70�100/16', CAST(N'1999-11-23' AS date), 5000, N'������������� �� � �����', N'��������')
INSERT Store (Id, Code, New, Name, Price, Izd, Pages, [Format], [Date], Pressrun, Themes, Category) VALUES (13, 1395, 0, N'����������� ����� 4. ������������� �����������.', 5.9500, N'������-����', 224, N'60�84\16', CAST(N'1998-04-06' AS date), 1000, N'������������� �� � �����', N'��������')
INSERT Store (Id, Code, New, Name, Price, Izd, Pages, [Format], [Date], Pressrun, Themes, Category) VALUES (14, 696, 0, N'IBM PC ��� ������������. ������� ����', 12.0000, N'�����-�', 480, N'60�90/16', CAST(N'1998-01-05' AS date), 50000, N'������������� �� � �����', N'��������')
INSERT Store (Id, Code, New, Name, Price, Izd, Pages, [Format], [Date], Pressrun, Themes, Category) VALUES (15, 272, 0, N'IBM PC ��� ������������. ���. 7�, �������������� � �����������', 26.8500, N'�����-�', 640, N'84�108/16', CAST(N'1997-02-17' AS date), 30000, N'������������� �� � �����', N'��������')
INSERT Store (Id, Code, New, Name, Price, Izd, Pages, [Format], [Date], Pressrun, Themes, Category) VALUES (16, 4264, 0, N'��������� �� �������������� �����������', 9.5200, N'����������� ������� ������', 272, N'70�100/16', CAST(N'1999-10-05' AS date), 10000, N'������������� �� � �����', N'��������')
GO

-- ������� �������
CREATE TABLE Worker
(
	Id int NOT NULL PRIMARY KEY,
	NameWorker varchar(255),
);
GO

-- ��������� �������

INSERT Worker (Id, NameWorker) VALUES (1, N'Artem Krol')
INSERT Worker (Id, NameWorker) VALUES (2, N'Ivan Ivanov')
INSERT Worker (Id, NameWorker) VALUES (3, N'Kolia Petrov')
INSERT Worker (Id, NameWorker) VALUES (4, N'Inga Greenberg')
INSERT Worker (Id, NameWorker) VALUES (5, N'Vasia Durov')
INSERT Worker (Id, NameWorker) VALUES (6, N'Nik P')
GO

-- ������� �������
CREATE TABLE Orders
(
	OrderNumber int NOT NULL PRIMARY KEY,
	NameBuyer varchar(255),
	DateOrder date
);
GO

-- ��������� �������

INSERT Orders (OrderNumber, NameBuyer, DateOrder) VALUES (100001, N'Katia', CAST(N'2019-02-18' AS date))
INSERT Orders (OrderNumber, NameBuyer, DateOrder) VALUES (100002, N'Ivan', CAST(N'2019-02-18' AS date))
INSERT Orders (OrderNumber, NameBuyer, DateOrder) VALUES (100003, N'Dasha', CAST(N'2019-02-18' AS date))
INSERT Orders (OrderNumber, NameBuyer, DateOrder) VALUES (100004, N'Piter', CAST(N'2019-02-19' AS date))
INSERT Orders (OrderNumber, NameBuyer, DateOrder) VALUES (100005, N'Vova', CAST(N'2019-02-19' AS date))
INSERT Orders (OrderNumber, NameBuyer, DateOrder) VALUES (100006, N'Dr', CAST(N'2019-02-19' AS date))
GO

-- ������� �������
CREATE TABLE SellBook
(
    IdOfGoods int NOT NULL PRIMARY KEY,
	IdProduct int ,
	CountBooks int,
	TotalCost decimal
);
GO

-- ��������� �������

INSERT SellBook (IdOfGoods, IdProduct, CountBooks, TotalCost) VALUES (1, 5, 22, 22 * 19)
INSERT SellBook (IdOfGoods, IdProduct, CountBooks, TotalCost) VALUES (2, 3, 26, 26 * 19.91)
INSERT SellBook (IdOfGoods, IdProduct, CountBooks, TotalCost) VALUES (3, 5, 14, 14 * 19)
INSERT SellBook (IdOfGoods, IdProduct, CountBooks, TotalCost) VALUES (4, 10, 2, 2 * 18.48)
INSERT SellBook (IdOfGoods, IdProduct, CountBooks, TotalCost) VALUES (5, 15, 8, 8 * 26.85)
INSERT SellBook (IdOfGoods, IdProduct, CountBooks, TotalCost) VALUES (6, 14, 122, 122 * 12)
GO

select * 
from Store;
select * 
from Worker;
select * 
from Orders;
select * 
from SellBook;