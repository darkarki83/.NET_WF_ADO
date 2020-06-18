create database Users;
go

use Users
go

create table UserAndPassword(
	Id int primary key identity(1,1),
	[Login] varchar(50) not null,
	[Password] varchar(50) not null
);
go

INSERT INTO UserAndPassword ([Login], [Password])VALUES ('artem', '1234')
INSERT INTO UserAndPassword ([Login], [Password])VALUES ('arik', '2345')

create table OneUser(
	Id int primary key identity(1,1),
	UserAndPasswordFK int not null,
	Adress varchar(50) not null,
	Phone varchar(9) not null,
	Is_Admin int,
	foreign key (UserAndPasswordFK) references UserAndPassword(Id)
);
go

INSERT INTO OneUser (UserAndPasswordFK, Adress, Phone, Is_Admin)VALUES (1, 'akk', '9258658', 1)
INSERT INTO OneUser (UserAndPasswordFK, Adress, Phone, Is_Admin)VALUES (2, 'add', '2336599', 0)