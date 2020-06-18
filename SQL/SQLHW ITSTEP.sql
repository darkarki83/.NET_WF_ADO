CREATE DATABASE ITStep;
GO

USE ITStep;
GO

CREATE TABLE LessonDay(
	ID INT PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(50) NOT NULL
);
GO

CREATE TABLE LessonHour(
	ID INT PRIMARY KEY IDENTITY(1,1),
	[Start] INT NOT NULL,--TIME NOT NULL,
	[Stop] INT NOT NULL--TIME NOT NULL
);
GO

CREATE TABLE LessonHourInDay(
	ID INT PRIMARY KEY IDENTITY(1,1),
	LessonDayFK INT NOT NULL,
	LessonHourFK INT NOT NULL,
	FOREIGN KEY (LessonDayFK) REFERENCES LessonDay(ID)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	FOREIGN KEY (LessonHourFK) REFERENCES LessonHour(ID)
		ON DELETE CASCADE
		ON UPDATE CASCADE
)

CREATE TABLE Teacher(
	ID INT PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(50) NOT NULL,
	Salary MONEY NOT NULL
);
GO

CREATE TABLE Theme(
	ID INT PRIMARY KEY IDENTITY(1,1),
	[Subject] VARCHAR(50)

);
GO

CREATE TABLE TeacherReadTheme(  -- спросить нужен ли тут ключь)
	ID INT PRIMARY KEY IDENTITY(1,1),
	TeacherFK INT NOT NULL,
	ThemeFK INT NOT NULL,
	FOREIGN KEY (TeacherFK) REFERENCES Teacher(ID)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	FOREIGN KEY (ThemeFK) REFERENCES Theme(ID)
		ON DELETE CASCADE
		ON UPDATE CASCADE
)

CREATE TABLE Faculty(
	ID INT PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(50),
	HeadFaculty VARCHAR(50)
);
GO

CREATE TABLE Student(
	ID INT PRIMARY KEY IDENTITY(2020001, 1),
	[Name] VARCHAR(50),
	Debt BIT,
	DateStart DATE NOT NULL
);
GO

CREATE TABLE Grupe(
	ID INT PRIMARY KEY IDENTITY(10001, 1),
	[Name] VARCHAR(50)
);
GO

CREATE TABLE StudentsInGrope(
	GrupeFK INT NOT NULL,
	StudentFK INT NOT NULL,
	PRIMARY KEY(GrupeFK, StudentFK),
	FOREIGN KEY(GrupeFK) REFERENCES Grupe(ID)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	FOREIGN KEY(StudentFK) REFERENCES Student(ID)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);
GO

CREATE TABLE GrupesInFaculty(
	FacultyFK INT NOT NULL,
	GrupeFK INT NOT NULL,
	PRIMARY KEY(FacultyFK, GrupeFK),
	FOREIGN KEY(FacultyFK) REFERENCES Faculty(ID)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	FOREIGN KEY(GrupeFK) REFERENCES Grupe(ID)
	    ON DELETE CASCADE
		ON UPDATE CASCADE
);
GO

CREATE TABLE TimeStadyGrupe(
	GrupeFK INT NOT NULL,
	LessonHourInDayFK INT NOT NULL,
	PRIMARY KEY(GrupeFK, LessonHourInDayFK),
	FOREIGN KEY(GrupeFK) REFERENCES Grupe(ID)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	FOREIGN KEY(LessonHourInDayFK) REFERENCES LessonHourInDay(ID)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);
GO

CREATE TABLE Timetable(
	ID INT PRIMARY KEY IDENTITY(2020001,1),
	GrupeFK INT NOT NULL, 
	ThemeFK INT NOT NULL,
	TeacherFK INT NOT NULL,
	DayFK INT NOT NULL,
	HourFK INT NOT NULL,
	FOREIGN KEY(GrupeFK) REFERENCES Grupe(ID)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	FOREIGN KEY(ThemeFK) REFERENCES Theme(ID)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	FOREIGN KEY(TeacherFK) REFERENCES Teacher(ID)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	FOREIGN KEY(DayFK) REFERENCES LessonDay(ID)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	FOREIGN KEY(HourFK) REFERENCES LessonHour(ID)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);
GO

--INSERT INTO dbo.LessonDay
  SELECT *
  FROM LessonDay

SET IDENTITY_INSERT dbo.LessonDay ON

INSERT INTO LessonDay (ID, Name)VALUES (1, 'Понеделник')
INSERT INTO LessonDay (ID, Name)VALUES (2, 'Вторник')
INSERT INTO LessonDay (ID, Name)VALUES (3, 'Среда')
INSERT INTO LessonDay (ID, Name)VALUES (4, 'Четверг')
INSERT INTO LessonDay (ID, Name)VALUES (5, 'Пятница')
INSERT INTO LessonDay (ID, Name)VALUES (6, 'Суббота')
INSERT INTO LessonDay (ID, Name)VALUES (7, 'Воскресенья')
SET IDENTITY_INSERT dbo.LessonDay OFF
GO

SET IDENTITY_INSERT dbo.LessonHour ON
INSERT INTO LessonHour (ID, [Start], [Stop])VALUES (1, 900, 1230)
INSERT INTO LessonHour (ID, [Start], [Stop])VALUES (2, 1300, 1630)
INSERT INTO LessonHour (ID, [Start], [Stop])VALUES (3, 1700, 2030)
INSERT INTO LessonHour (ID, [Start], [Stop])VALUES (4, 900, 1500)
INSERT INTO LessonHour (ID, [Start], [Stop])VALUES (5, 1500, 2100)

SET IDENTITY_INSERT dbo.LessonHour OFF
GO

SET IDENTITY_INSERT dbo.LessonHourInDay ON
INSERT INTO LessonHourInDay (ID, LessonDayFK, LessonHourFK)VALUES (1, 1, 1)
INSERT INTO LessonHourInDay (ID, LessonDayFK, LessonHourFK)VALUES (2, 1, 2)
INSERT INTO LessonHourInDay (ID, LessonDayFK, LessonHourFK)VALUES (3, 1, 3)
INSERT INTO LessonHourInDay (ID, LessonDayFK, LessonHourFK)VALUES (4, 2, 1)
INSERT INTO LessonHourInDay (ID, LessonDayFK, LessonHourFK)VALUES (5, 2, 2)
INSERT INTO LessonHourInDay (ID, LessonDayFK, LessonHourFK)VALUES (6, 2, 3)
INSERT INTO LessonHourInDay (ID, LessonDayFK, LessonHourFK)VALUES (7, 3, 1)
INSERT INTO LessonHourInDay (ID, LessonDayFK, LessonHourFK)VALUES (8, 3, 2)
INSERT INTO LessonHourInDay (ID, LessonDayFK, LessonHourFK)VALUES (9, 3, 3)
INSERT INTO LessonHourInDay (ID, LessonDayFK, LessonHourFK)VALUES (10, 4, 1)
INSERT INTO LessonHourInDay (ID, LessonDayFK, LessonHourFK)VALUES (11, 4, 2)
INSERT INTO LessonHourInDay (ID, LessonDayFK, LessonHourFK)VALUES (12, 4, 3)
INSERT INTO LessonHourInDay (ID, LessonDayFK, LessonHourFK)VALUES (13, 5, 1)
INSERT INTO LessonHourInDay (ID, LessonDayFK, LessonHourFK)VALUES (14, 5, 2)
INSERT INTO LessonHourInDay (ID, LessonDayFK, LessonHourFK)VALUES (15, 5, 3)
INSERT INTO LessonHourInDay (ID, LessonDayFK, LessonHourFK)VALUES (16, 6, 4)
INSERT INTO LessonHourInDay (ID, LessonDayFK, LessonHourFK)VALUES (17, 6, 5)
INSERT INTO LessonHourInDay (ID, LessonDayFK, LessonHourFK)VALUES (20, 7, 4)
INSERT INTO LessonHourInDay (ID, LessonDayFK, LessonHourFK)VALUES (21, 7, 5)
SET IDENTITY_INSERT dbo.LessonHourInDay OFF
GO

SET IDENTITY_INSERT dbo.Teacher ON
INSERT INTO Teacher (ID, [Name], Salary) VALUES (1, 'Dmitry', 2000)
INSERT INTO Teacher (ID, [Name], Salary) VALUES (2, 'Alex', 3000)
INSERT INTO Teacher (ID, [Name], Salary) VALUES (3, 'Vitalii', 1500)
INSERT INTO Teacher (ID, [Name], Salary) VALUES (4, 'Alexis', 800)
INSERT INTO Teacher (ID, [Name], Salary) VALUES (5, 'Andrei', 450)
INSERT INTO Teacher (ID, [Name], Salary) VALUES (6, 'Oleg', 2250)
SET IDENTITY_INSERT dbo.Teacher OFF
GO

SET IDENTITY_INSERT dbo.Theme ON
INSERT INTO Theme (ID, [Subject]) VALUES (1, 'C++')
INSERT INTO Theme (ID, [Subject]) VALUES (2, 'C#')
INSERT INTO Theme (ID, [Subject]) VALUES (3, 'Grafic')
INSERT INTO Theme (ID, [Subject]) VALUES (4, 'Foto shop')
INSERT INTO Theme (ID, [Subject]) VALUES (5, 'Windows')
INSERT INTO Theme (ID, [Subject]) VALUES (6, 'Web')
SET IDENTITY_INSERT dbo.Theme OFF
GO

SET IDENTITY_INSERT dbo.TeacherReadTheme ON
INSERT INTO TeacherReadTheme (ID, TeacherFK, ThemeFK) VALUES (1, 1, 1)
INSERT INTO TeacherReadTheme (ID, TeacherFK, ThemeFK) VALUES (2, 1, 2)
INSERT INTO TeacherReadTheme (ID, TeacherFK, ThemeFK) VALUES (3, 2, 1)
INSERT INTO TeacherReadTheme (ID, TeacherFK, ThemeFK) VALUES (4, 3, 2)
INSERT INTO TeacherReadTheme (ID, TeacherFK, ThemeFK) VALUES (5, 3, 6)
INSERT INTO TeacherReadTheme (ID, TeacherFK, ThemeFK) VALUES (6, 4, 3)
INSERT INTO TeacherReadTheme (ID, TeacherFK, ThemeFK) VALUES (7, 5, 4)
INSERT INTO TeacherReadTheme (ID, TeacherFK, ThemeFK) VALUES (8, 5, 6)
INSERT INTO TeacherReadTheme (ID, TeacherFK, ThemeFK) VALUES (9, 6, 5)
SET IDENTITY_INSERT dbo.TeacherReadTheme OFF
GO


SET IDENTITY_INSERT dbo.Faculty ON
INSERT INTO Faculty (ID, [Name], HeadFaculty) VALUES (1, 'Program', 'Dmitry')
INSERT INTO Faculty (ID, [Name], HeadFaculty) VALUES (2, 'Web', 'Oleg')
INSERT INTO Faculty (ID, [Name], HeadFaculty) VALUES (3, 'Windows','Petrovich')
SET IDENTITY_INSERT dbo.Faculty OFF
GO

SET IDENTITY_INSERT dbo.Student ON
INSERT INTO Student (ID, [Name], Debt, DateStart) VALUES (2020001, 'Artem', 0, CAST(N'2018-02-23' AS DATE))
INSERT INTO Student (ID, [Name], Debt, DateStart) VALUES (2020002, 'Petro', 1, CAST(N'2018-02-23' AS DATE))
INSERT INTO Student (ID, [Name], Debt, DateStart) VALUES (2020003, 'Ivan', 0, CAST(N'2018-02-23' AS DATE))
INSERT INTO Student (ID, [Name], Debt, DateStart) VALUES (2020004, 'Dmitro', 0, CAST(N'2018-02-23' AS DATE))
INSERT INTO Student (ID, [Name], Debt, DateStart) VALUES (2020005, 'Stas', 0, CAST(N'2018-08-23' AS DATE))
INSERT INTO Student (ID, [Name], Debt, DateStart) VALUES (2020006, 'Kolia', 0, CAST(N'2018-08-23' AS DATE))
INSERT INTO Student (ID, [Name], Debt, DateStart) VALUES (2020007, 'Dash', 0, CAST(N'2018-08-23' AS DATE))
INSERT INTO Student (ID, [Name], Debt, DateStart) VALUES (2020008, 'Masha', 0, CAST(N'2018-08-23' AS DATE))
INSERT INTO Student (ID, [Name], Debt, DateStart) VALUES (2020009, 'Olai', 0, CAST(N'2019-02-23' AS DATE))
INSERT INTO Student (ID, [Name], Debt, DateStart) VALUES (2020010, 'Stanislav', 1, CAST(N'2019-02-23' AS DATE))
INSERT INTO Student (ID, [Name], Debt, DateStart) VALUES (2020011, 'Ron', 0, CAST(N'2019-02-23' AS DATE))
INSERT INTO Student (ID, [Name], Debt, DateStart) VALUES (2020012, 'Ira', 0, CAST(N'2019-02-23' AS DATE))
INSERT INTO Student (ID, [Name], Debt, DateStart) VALUES (2020013, 'Katia', 0, CAST(N'2019-08-23' AS DATE))
INSERT INTO Student (ID, [Name], Debt, DateStart) VALUES (2020014, 'Alex', 0, CAST(N'2019-08-23' AS DATE))
INSERT INTO Student (ID, [Name], Debt, DateStart) VALUES (2020015, 'Fedia', 0, CAST(N'2019-08-23' AS DATE))
INSERT INTO Student (ID, [Name], Debt, DateStart) VALUES (2020016, 'Tania', 0, CAST(N'2019-05-1' AS DATE))
INSERT INTO Student (ID, [Name], Debt, DateStart) VALUES (2020017, 'Katia', 0, CAST(N'2019-05-1' AS DATE))
INSERT INTO Student (ID, [Name], Debt, DateStart) VALUES (2020018, 'Valik', 0, CAST(N'2019-10-2' AS DATE))
SET IDENTITY_INSERT dbo.Student OFF
GO

SET IDENTITY_INSERT dbo.Grupe ON
INSERT INTO Grupe (ID, [Name]) VALUES (1, 'БПУ-1821')
INSERT INTO Grupe (ID, [Name]) VALUES (2, 'БПУ-1822')
INSERT INTO Grupe (ID, [Name]) VALUES (3, 'БПП-1823')
INSERT INTO Grupe (ID, [Name]) VALUES (4, 'БПП-1824')
INSERT INTO Grupe (ID, [Name]) VALUES (5, 'БПН-1825')
SET IDENTITY_INSERT dbo.Grupe OFF
GO

INSERT INTO StudentsInGrope (GrupeFK, StudentFK) VALUES (1, 2020001)
INSERT INTO StudentsInGrope (GrupeFK, StudentFK) VALUES (1, 2020004)
INSERT INTO StudentsInGrope (GrupeFK, StudentFK) VALUES (1, 2020005)
INSERT INTO StudentsInGrope (GrupeFK, StudentFK) VALUES (1, 2020010)
INSERT INTO StudentsInGrope (GrupeFK, StudentFK) VALUES (1, 2020015)
INSERT INTO StudentsInGrope (GrupeFK, StudentFK) VALUES (2, 2020002)
INSERT INTO StudentsInGrope (GrupeFK, StudentFK) VALUES (2, 2020003)
INSERT INTO StudentsInGrope (GrupeFK, StudentFK) VALUES (2, 2020008)
INSERT INTO StudentsInGrope (GrupeFK, StudentFK) VALUES (2, 2020011)
INSERT INTO StudentsInGrope (GrupeFK, StudentFK) VALUES (2, 2020014)
INSERT INTO StudentsInGrope (GrupeFK, StudentFK) VALUES (3, 2020006)
INSERT INTO StudentsInGrope (GrupeFK, StudentFK) VALUES (3, 2020007)
INSERT INTO StudentsInGrope (GrupeFK, StudentFK) VALUES (3, 2020009)
INSERT INTO StudentsInGrope (GrupeFK, StudentFK) VALUES (3, 2020012)
INSERT INTO StudentsInGrope (GrupeFK, StudentFK) VALUES (3, 2020017)
INSERT INTO StudentsInGrope (GrupeFK, StudentFK) VALUES (4, 2020013)
INSERT INTO StudentsInGrope (GrupeFK, StudentFK) VALUES (4, 2020016)
INSERT INTO StudentsInGrope (GrupeFK, StudentFK) VALUES (5, 2020018)
INSERT INTO StudentsInGrope (GrupeFK, StudentFK) VALUES (5, 2020011)
INSERT INTO StudentsInGrope (GrupeFK, StudentFK) VALUES (5, 2020002)
GO

INSERT INTO GrupesInFaculty (FacultyFK, GrupeFK) VALUES (1, 1)
INSERT INTO GrupesInFaculty (FacultyFK, GrupeFK) VALUES (1, 2)
INSERT INTO GrupesInFaculty (FacultyFK, GrupeFK) VALUES (2, 3)
INSERT INTO GrupesInFaculty (FacultyFK, GrupeFK) VALUES (2, 4)
INSERT INTO GrupesInFaculty (FacultyFK, GrupeFK) VALUES (3, 5)
GO


INSERT INTO TimeStadyGrupe (GrupeFK, LessonHourInDayFK) VALUES (1, 1)
INSERT INTO TimeStadyGrupe (GrupeFK, LessonHourInDayFK) VALUES (1, 4)
INSERT INTO TimeStadyGrupe (GrupeFK, LessonHourInDayFK) VALUES (1, 7)
INSERT INTO TimeStadyGrupe (GrupeFK, LessonHourInDayFK) VALUES (1, 10)
INSERT INTO TimeStadyGrupe (GrupeFK, LessonHourInDayFK) VALUES (2, 2)
INSERT INTO TimeStadyGrupe (GrupeFK, LessonHourInDayFK) VALUES (2, 5)
INSERT INTO TimeStadyGrupe (GrupeFK, LessonHourInDayFK) VALUES (2, 8)
INSERT INTO TimeStadyGrupe (GrupeFK, LessonHourInDayFK) VALUES (2, 11)
INSERT INTO TimeStadyGrupe (GrupeFK, LessonHourInDayFK) VALUES (3, 3)
INSERT INTO TimeStadyGrupe (GrupeFK, LessonHourInDayFK) VALUES (3, 6)
INSERT INTO TimeStadyGrupe (GrupeFK, LessonHourInDayFK) VALUES (3, 9)
INSERT INTO TimeStadyGrupe (GrupeFK, LessonHourInDayFK) VALUES (4, 16)
INSERT INTO TimeStadyGrupe (GrupeFK, LessonHourInDayFK) VALUES (4, 17)
INSERT INTO TimeStadyGrupe (GrupeFK, LessonHourInDayFK) VALUES (5, 20)
INSERT INTO TimeStadyGrupe (GrupeFK, LessonHourInDayFK) VALUES (5, 21)
GO

SET IDENTITY_INSERT dbo.Timetable ON
INSERT INTO Timetable (ID, GrupeFK, ThemeFK, TeacherFK, DayFK, HourFK) VALUES (1, 1, 1, 2, 1, 1)
INSERT INTO Timetable (ID, GrupeFK, ThemeFK, TeacherFK, DayFK, HourFK) VALUES (2, 1, 5, 6, 2, 1)
INSERT INTO Timetable (ID, GrupeFK, ThemeFK, TeacherFK, DayFK, HourFK) VALUES (3, 1, 1, 1, 3, 1)
INSERT INTO Timetable (ID, GrupeFK, ThemeFK, TeacherFK, DayFK, HourFK) VALUES (4, 1, 5, 6, 4, 1)
INSERT INTO Timetable (ID, GrupeFK, ThemeFK, TeacherFK, DayFK, HourFK) VALUES (5, 2, 2, 3, 1, 1)
INSERT INTO Timetable (ID, GrupeFK, ThemeFK, TeacherFK, DayFK, HourFK) VALUES (6, 2, 6, 3, 2, 2)
INSERT INTO Timetable (ID, GrupeFK, ThemeFK, TeacherFK, DayFK, HourFK) VALUES (7, 2, 2, 1, 3, 1)
INSERT INTO Timetable (ID, GrupeFK, ThemeFK, TeacherFK, DayFK, HourFK) VALUES (8, 2, 6, 5, 4, 2)
INSERT INTO Timetable (ID, GrupeFK, ThemeFK, TeacherFK, DayFK, HourFK) VALUES (9, 3, 1, 1, 3, 3)
INSERT INTO Timetable (ID, GrupeFK, ThemeFK, TeacherFK, DayFK, HourFK) VALUES (10, 3, 2, 1, 4, 1)
INSERT INTO Timetable (ID, GrupeFK, ThemeFK, TeacherFK, DayFK, HourFK) VALUES (11, 3, 3, 4, 5, 2)
INSERT INTO Timetable (ID, GrupeFK, ThemeFK, TeacherFK, DayFK, HourFK) VALUES (12, 3, 5, 6, 5, 3)
INSERT INTO Timetable (ID, GrupeFK, ThemeFK, TeacherFK, DayFK, HourFK) VALUES (13, 4, 6, 3, 6, 4)
INSERT INTO Timetable (ID, GrupeFK, ThemeFK, TeacherFK, DayFK, HourFK) VALUES (14, 4, 5, 6, 6, 4)
INSERT INTO Timetable (ID, GrupeFK, ThemeFK, TeacherFK, DayFK, HourFK) VALUES (15, 4, 4, 5, 6, 5)
INSERT INTO Timetable (ID, GrupeFK, ThemeFK, TeacherFK, DayFK, HourFK) VALUES (16, 4, 3, 4, 6, 5)
INSERT INTO Timetable (ID, GrupeFK, ThemeFK, TeacherFK, DayFK, HourFK) VALUES (17, 5, 2, 1, 7, 4)
INSERT INTO Timetable (ID, GrupeFK, ThemeFK, TeacherFK, DayFK, HourFK) VALUES (18, 5, 1, 2, 7, 4)
INSERT INTO Timetable (ID, GrupeFK, ThemeFK, TeacherFK, DayFK, HourFK) VALUES (19, 5, 3, 4, 7, 5)
INSERT INTO Timetable (ID, GrupeFK, ThemeFK, TeacherFK, DayFK, HourFK) VALUES (20, 5, 4, 5, 7, 5)
GO
SET IDENTITY_INSERT dbo.Timetable OFF

--SET IDENTITY_INSERT dbo.Teacher ON

--SET IDENTITY_INSERT dbo.Teacher OFF
--GO

SELECT *
FROM LessonDay
GO

SELECT *
FROM LessonHour
GO

SELECT *
FROM LessonHourInDay
GO

SELECT *
FROM Teacher
GO

SELECT *
FROM Theme
GO

SELECT *
FROM TeacherReadTheme
GO

SELECT *
FROM Faculty
GO

SELECT *
FROM Student
GO

SELECT *
FROM Grupe
GO

SELECT *
FROM StudentsInGrope
GO

SELECT *
FROM GrupesInFaculty
GO

SELECT *
FROM TimeStadyGrupe
GO

SELECT *
FROM Timetable
GO

--SELECT *
--FROM LessonHourInDay
--GO

Delete
FROM LessonDay
GO