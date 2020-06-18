USE WorldCup
GO

/*select *
from TeamsInGroup*/

IF EXISTS (SELECT * FROM sys.objects WHERE name = 'InsertGoolsQual' AND type = 'P')
    DROP PROCEDURE InsertGoolsQual;
GO

CREATE PROCEDURE InsertGoolsQual @Gols INT, @TeamFK INT, @StartTime INT, @EndTime INT
AS
BEGIN
WHILE @Gols > 0
	BEGIN
		DECLARE @Time INT;
		SET @Time = (SELECT FLOOR(@StartTime + RAND() * (@EndTime - @StartTime)));
		INSERT INTO GoolsQual (TeamsFK, GoolTime) VALUES(@TeamFK, @Time);
		SET @Gols = @Gols - 1;
	END;
END;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE name = 'PlaysInGroups' AND type = 'P')
    DROP PROCEDURE PlaysInGroups;
GO

CREATE PROCEDURE PlaysInGroups @GroupsName Varchar(1)
AS
BEGIN
	DECLARE @GroupsPlays INT
	SET @GroupsPlays =(SELECT Groups.ID FROM Groups WHERE Groups.Name = @GroupsName);
	DECLARE @PlayDate DATETIME = '10-01-19 15:00:00';
	DECLARE @i INT;
	DECLARE @j INT;
	DECLARE @GolsOne INT;
	DECLARE @GolsSecond INT;
	SET @i = 1;
	SET @j = 1;
	DECLARE @TeamOne INT;
	DECLARE @TeamSecond INT;

	WHILE @j <= 4
	BEGIN 
		WHILE @i <= 4
		BEGIN
			SET @TeamOne = (SELECT TeamsInGroup.TeamsFK
							FROM TeamsInGroup
							WHERE TeamsInGroup.GroupsFK = @GroupsPlays AND TeamsInGroup.TeamIdInGroup = @j)
			SET @GolsOne = (SELECT CAST((0 + RAND() * 3) AS INT));
			IF(@j = @i)
			   SET @i = @i + 1;
			IF(@i = 5)
				BREAK;
			SET @TeamSecond = (SELECT TeamsInGroup.TeamsFK
							   FROM TeamsInGroup
							   WHERE TeamsInGroup.GroupsFK = @GroupsPlays and TeamsInGroup.TeamIdInGroup = @i)
			SET @GolsSecond = (SELECT CAST((0 + RAND() * 3) AS INT));
			SET @PlayDate = DATEADD(DAY, 3, @PlayDate);

			INSERT INTO GroupsPlays (TeamsFirstFK, TeamsSecondFK, FormsFirstTeamFK, FormsSecondTeamFK, RefereesInPlayFK, StadiumFK, [PlayDate], TeamsFirstResult, TeamsSecondResult) 
			VALUES(@TeamOne, @TeamSecond, (SELECT CAST((1 + RAND() * 19)AS INT)), (SELECT CAST((1 + RAND() * 19)AS INT)), (SELECT CAST((1 + RAND() * 15)AS INT)), (SELECT CAST((1 + RAND() * 9)AS INT)), @PlayDate, @GolsOne, @GolsSecond);
			
			EXEC InsertGoolsQual @Gols = @GolsOne, @TeamFK = @TeamOne, @StartTime  = 0, @EndTime  = 90;
			EXEC InsertGoolsQual @Gols = @GolsSecond, @TeamFK = @TeamSecond, @StartTime  = 0, @EndTime  = 90;

			SET @i = @i + 1;
		END;
		SET @i = 1;
		SET @j = @j + 1;
	END;
END
GO

IF EXISTS (SELECT * FROM sys.objects WHERE name = 'InpupTablesPointInGroup' AND type = 'P')
    DROP PROCEDURE InpupTablesPointInGroup;
GO

CREATE PROCEDURE InpupTablesPointInGroup
AS
BEGIN
	DECLARE @GolsOne INT;
	DECLARE @GolsSecond INT;
	DECLARE @TeamOne INT;
	DECLARE @TeamSecond INT;
	DECLARE @i INT;
	DECLARE @countGames INT;
	DECLARE @groupFK INT;

	SET @countGames = (SELECT COUNT(GroupsPlays.ID)
					   FROM GroupsPlays);

	SET @i = (SELECT Top (1) GroupsPlays.ID
			  FROM GroupsPlays);

	WHILE(@i < @countGames)
	BEGIN
		SET @TeamOne = (SELECT GroupsPlays.TeamsFirstFK
						FROM GroupsPlays
						WHERE GroupsPlays.ID = @i);
		SET @TeamSecond = (SELECT GroupsPlays.TeamsSecondFK
						FROM GroupsPlays
						WHERE GroupsPlays.ID = @i);
		SET @groupFK = (SELECT TeamsInGroup.GroupsFK
						FROM TeamsInGroup
						WHERE TeamsInGroup.TeamsFK = @TeamOne);

		SET @GolsOne = (SELECT GroupsPlays.TeamsFirstResult
						FROM GroupsPlays
						WHERE GroupsPlays.ID = @i);
		SET @GolsSecond = (SELECT GroupsPlays.TeamsSecondResult
						FROM GroupsPlays
						WHERE GroupsPlays.ID = @i);

		IF(@GolsOne > @GolsSecond)
			UPDATE PointsInGroup SET Points = Points + 3 WHERE PointsInGroup.GroupsFK = @groupFK AND PointsInGroup.TeamsFK = @TeamOne
		IF(@GolsOne < @GolsSecond)
			UPDATE PointsInGroup SET Points = Points + 3 WHERE PointsInGroup.GroupsFK = @groupFK AND PointsInGroup.TeamsFK = @TeamSecond
		IF(@GolsOne = @GolsSecond)
		BEGIN
			UPDATE PointsInGroup SET Points = Points + 1 WHERE PointsInGroup.GroupsFK = @groupFK AND PointsInGroup.TeamsFK = @TeamOne
			UPDATE PointsInGroup SET Points = Points + 1 WHERE PointsInGroup.GroupsFK = @groupFK AND PointsInGroup.TeamsFK = @TeamSecond;
		END;
		UPDATE PointsInGroup SET YouForgot = YouForgot + @GolsSecond, YouGoiters = YouGoiters + @GolsOne WHERE PointsInGroup.GroupsFK = @groupFK AND PointsInGroup.TeamsFK = @TeamSecond;
		UPDATE PointsInGroup SET YouForgot = YouForgot + @GolsOne, YouGoiters = YouGoiters + @GolsSecond WHERE PointsInGroup.GroupsFK = @groupFK AND PointsInGroup.TeamsFK = @TeamOne;
		SET @i = @i + 1;
	END;
END
GO

IF EXISTS (SELECT * FROM sys.objects WHERE name = 'fn_GetPlayOffTeams' AND type = 'FN')
    DROP FUNCTION fn_GetPlayOffTeams;
GO

CREATE FUNCTION fn_GetPlayOffTeams(@GroupsName VARCHAR(1))
RETURNS @result TABLE (TeamOnFK INT NOT NULL)
AS
BEGIN
    -- ќбъ€вл€ем переменную типа "таблица" (по сути Ч временную таблицу)
    DECLARE @t TABLE (TeamOnFK INT NOT NULL);
	DECLARE @GroupId INT;
	SET @GroupId = (SELECT Groups.ID
					FROM Groups
					WHERE Groups.Name = @GroupsName)
	-- «аполн€ем временную таблицу
    INSERT INTO @t
	     SELECT TOP(2) PointsInGroup.TeamsFK
		 FROM PointsInGroup
		 WHERE PointsInGroup.GroupsFK = @GroupId
		 ORDER BY PointsInGroup.Points DESC, PointsInGroup.YouForgot DESC, PointsInGroup.YouGoiters DESC

	-- ‘ормируем результирующую таблицу
    INSERT INTO @result
	    SELECT TeamOnFK
        FROM @t;

    RETURN;
END
GO

IF EXISTS (SELECT * FROM sys.objects WHERE name = 'Plays1In8' AND type = 'P')
    DROP PROCEDURE Plays1In8;
GO

CREATE PROCEDURE Plays1In8 
AS
BEGIN
	DECLARE @Winner INT;
	DECLARE @Overtime BIT;  ----------------------------------------
	DECLARE @Pendels BIT;   ----------------------------------------
	DECLARE @PendelsOne INT;  -----------------------------------
	DECLARE @PendelsSecond INT;  -------------------------------------
	DECLARE @PlayDate DATETIME = '10-03-19 15:00:00';    ---------------------------------------
	DECLARE @i INT;   --------------------------------------
	DECLARE @j INT;  -----------------------------------
	DECLARE @GolsOne INT;   -----------------------------------
	DECLARE @GolsSecond INT;   -----------------------------------
	DECLARE @GolsOneOvertime INT;    ---------------------------------
	DECLARE @GolsSecondOvertime INT;    -----------------------------------
	DECLARE @TeamOne INT;  -----------------------------------
	DECLARE @TeamSecond INT;   ---------------------------

	SET @i = 1;  -----------------------------
	SET @j = 16;  ----------------------------
	
	WHILE @i < @j
	BEGIN
		SET @Winner = 0;
		SET @Overtime = 0;  ----------------------------------------
		SET @Pendels = 0;  ------------------------------------------
		SET @PendelsOne = 0;  ----------------------------------------
		SET @PendelsSecond = 0;
		SET @GolsOne = 0;   --------
		SET @GolsSecond = 0;   -----
		SET @GolsOneOvertime = 0;   
		SET @GolsSecondOvertime = 0; 

		SET @TeamOne = (SELECT TeamsInPlayOff.TeamsFK
						FROM TeamsInPlayOff
						WHERE TeamsInPlayOff.ID = @i)
		SET @GolsOne = (SELECT CAST((0 + RAND() * 3) AS INT));
		SET @TeamSecond = (SELECT TeamsInPlayOff.TeamsFK
						FROM TeamsInPlayOff
						WHERE TeamsInPlayOff.ID = @j)
		SET @GolsSecond = (SELECT CAST((0 + RAND() * 3) AS INT));
		IF @GolsOne = @GolsSecond
		BEGIN
			SET @Overtime = 1;
			SET @GolsOneOvertime = (SELECT CAST((0 + RAND() * 2) AS INT));
			SET @GolsSecondOvertime = (SELECT CAST((0 + RAND() * 2) AS INT));
			IF  @GolsOneOvertime = @GolsSecondOvertime
			BEGIN
				SET @Pendels = 1;
				WHILE @PendelsOne != @PendelsSecond
				BEGIN
					SET @PendelsOne = (SELECT CAST((0 + RAND() * 5) AS INT));
					SET @PendelsSecond = (SELECT CAST((0 + RAND() * 5) AS INT));
				END;
				IF @PendelsOne > @PendelsSecond
				SET @Winner =  @TeamOne;
				ELSE
				SET @Winner = @TeamSecond;
			END;
		END;
		IF @Winner = 0
		BEGIN
			IF @GolsOne + @GolsOneOvertime > @GolsSecond + @GolsSecondOvertime
			SET @Winner =  @TeamOne;
			ELSE
			SET @Winner = @TeamSecond;
		END;

		INSERT INTO PlaysOff (TeamOffFirstFK, TeamOffSecondFK, FormFirstTeamFK, FormSecondTeamFK, StadiumFK, RefereesInPlayFK, [PlayDate], Overtime, Pendels, TeamsFirstResult, TeamsSecondResult, WinnerFK)
		VALUES (@TeamOne, @TeamSecond, (SELECT CAST((1 + RAND() * 19)AS INT)), (SELECT CAST((1 + RAND() * 19)AS INT)), (SELECT CAST((1 + RAND() * 9)AS INT)), 
		(SELECT CAST((1 + RAND() * 15)AS INT)), @PlayDate, @Overtime, @Pendels, @GolsOne + @GolsOneOvertime, @GolsSecond + @GolsSecondOvertime, @Winner);

		SET @PlayDate = DATEADD(DAY, 3, @PlayDate);

		SET @i = @i + 1;
		SET @j = @j - 1;

		EXEC InsertGoolsQual @Gols = @GolsOne, @TeamFK = @TeamOne,  @StartTime  = 0, @EndTime  = 90;
		EXEC InsertGoolsQual @Gols = @GolsOneOvertime, @TeamFK = @TeamOne, @StartTime  = 91, @EndTime  = 120;
		EXEC InsertGoolsQual @Gols = @GolsSecond, @TeamFK = @TeamSecond, @StartTime  = 0, @EndTime  = 90;
		EXEC InsertGoolsQual @Gols = @GolsSecondOvertime, @TeamFK = @TeamSecond, @StartTime  = 91, @EndTime  = 120;
	END;
END
GO

IF EXISTS (SELECT * FROM sys.objects WHERE name = 'fn_EquelWin' AND type = 'FN')
    DROP FUNCTION fn_EquelWin;
GO

CREATE FUNCTION fn_EquelWin(@One INT, @Second INT, @TeamOne INT, @TeamSecond INT)
RETURNS INT
AS
BEGIN
   IF @One > @Second
		RETURN @TeamOne;
	ELSE
		RETURN @TeamSecond;
    RETURN 0;
END
GO

IF EXISTS (SELECT * FROM sys.objects WHERE name = 'QuarterFinal' AND type = 'P')
    DROP PROCEDURE QuarterFinal;
GO

CREATE PROCEDURE QuarterFinal 
AS
BEGIN
	DECLARE @Winner INT;
	DECLARE @Overtime BIT;  ----------------------------------------
	DECLARE @Pendels BIT;   ----------------------------------------
	DECLARE @PendelsOne INT;  -----------------------------------
	DECLARE @PendelsSecond INT;  -------------------------------------
	DECLARE @PlayDate DATETIME = '10-27-19 15:00:00';    ---------------------------------------
	DECLARE @i INT;   --------------------------------------
	DECLARE @j INT;  -----------------------------------
	DECLARE @GolsOne INT;   -----------------------------------
	DECLARE @GolsSecond INT;   -----------------------------------
	DECLARE @GolsOneOvertime INT;    ---------------------------------
	DECLARE @GolsSecondOvertime INT;    -----------------------------------

	SET @i = 1;  -----------------------------
	--SET @j = 16;  ----------------------------
	
	DECLARE @TeamOne INT;  -----------------------------------
	DECLARE @TeamSecond INT;   ---------------------------
	
	WHILE @i <= 4
	BEGIN
		SET @Winner = 0;
		SET @Overtime = 0;  ----------------------------------------
		SET @Pendels = 0;  ------------------------------------------
		SET @PendelsOne = 0;  ----------------------------------------
		SET @PendelsSecond = 0;
		SET @GolsOne = 0;   --------
		SET @GolsSecond = 0;   -----
		SET @GolsOneOvertime = 0;   
		SET @GolsSecondOvertime = 0; 

		SET @TeamOne = (SELECT PlaysOff.WinnerFK
						FROM PlaysOff
						WHERE PlaysOff.ID = @i)
		SET @GolsOne = (SELECT CAST((0 + RAND() * 3) AS INT));
		SET @TeamSecond = (SELECT PlaysOff.WinnerFK
						FROM PlaysOff
						WHERE PlaysOff.ID = @i + 4)
		SET @GolsSecond = (SELECT CAST((0 + RAND() * 3) AS INT));
		IF @GolsOne = @GolsSecond
		BEGIN
			SET @Overtime = 1;
			SET @GolsOneOvertime = (SELECT CAST((0 + RAND() * 2) AS INT));
			SET @GolsSecondOvertime = (SELECT CAST((0 + RAND() * 2) AS INT));
			IF  @GolsOneOvertime = @GolsSecondOvertime
			BEGIN
				SET @Pendels = 1;
				WHILE @PendelsOne != @PendelsSecond
				BEGIN
					SET @PendelsOne = (SELECT CAST((0 + RAND() * 5) AS INT));
					SET @PendelsSecond = (SELECT CAST((0 + RAND() * 5) AS INT));
				END;
				IF @PendelsOne > @PendelsSecond
				SET @Winner =  @TeamOne;
				ELSE
				SET @Winner = @TeamSecond;
			END;
		END;
		IF @Winner = 0
		BEGIN
			IF @GolsOne + @GolsOneOvertime > @GolsSecond + @GolsSecondOvertime
			SET @Winner =  @TeamOne;
			ELSE
			SET @Winner = @TeamSecond;
		END;

		INSERT INTO PlaysOff (TeamOffFirstFK, TeamOffSecondFK, FormFirstTeamFK, FormSecondTeamFK, StadiumFK, RefereesInPlayFK, [PlayDate], Overtime, Pendels, TeamsFirstResult, TeamsSecondResult, WinnerFK)
		VALUES (@TeamOne, @TeamSecond, (SELECT CAST((1 + RAND() * 19)AS INT)), (SELECT CAST((1 + RAND() * 19)AS INT)), (SELECT CAST((1 + RAND() * 9)AS INT)),  (SELECT CAST((1 + RAND() * 15)AS INT)), @PlayDate, @Overtime, @Pendels, @GolsOne + @GolsOneOvertime, @GolsSecond + @GolsSecondOvertime, @Winner);

		SET @PlayDate = DATEADD(DAY, 3, @PlayDate);

		SET @i = @i + 1;
		EXEC InsertGoolsQual @Gols = @GolsOne, @TeamFK = @TeamOne,  @StartTime  = 0, @EndTime  = 90;
		EXEC InsertGoolsQual @Gols = @GolsOneOvertime, @TeamFK = @TeamOne, @StartTime  = 91, @EndTime  = 120;
		EXEC InsertGoolsQual @Gols = @GolsSecond, @TeamFK = @TeamSecond, @StartTime  = 0, @EndTime  = 90;
		EXEC InsertGoolsQual @Gols = @GolsSecondOvertime, @TeamFK = @TeamSecond, @StartTime  = 91, @EndTime  = 120;
	END;
END
GO

IF EXISTS (SELECT * FROM sys.objects WHERE name = 'SemiFinalAndFinal' AND type = 'P')
    DROP PROCEDURE SemiFinalAndFinal;
GO

CREATE PROCEDURE SemiFinalAndFinal
AS
BEGIN
	DECLARE @Winner INT;
	DECLARE @Overtime BIT;  ----------------------------------------
	DECLARE @Pendels BIT;   ----------------------------------------
	DECLARE @PendelsOne INT;  -----------------------------------
	DECLARE @PendelsSecond INT;  -------------------------------------
	DECLARE @PlayDate DATETIME = '11-07-19 15:00:00';    ---------------------------------------
	DECLARE @i INT;   --------------------------------------
	DECLARE @j INT;  -----------------------------------
	DECLARE @GolsOne INT;   -----------------------------------
	DECLARE @GolsSecond INT;   -----------------------------------
	DECLARE @GolsOneOvertime INT;    ---------------------------------
	DECLARE @GolsSecondOvertime INT;    -----------------------------------

	SET @i = 1;  -----------------------------
	SET @j = 9;  ----------------------------
	
	DECLARE @TeamOne INT;  -----------------------------------
	DECLARE @TeamSecond INT;   ---------------------------
	
	WHILE @i <= 3
	BEGIN
		SET @Winner = 0;
		SET @Overtime = 0;  ----------------------------------------
		SET @Pendels = 0;  ------------------------------------------
		SET @PendelsOne = 0;  ----------------------------------------
		SET @PendelsSecond = 0;
		SET @GolsOne = 0;   --------
		SET @GolsSecond = 0;   -----
		SET @GolsOneOvertime = 0;   
		SET @GolsSecondOvertime = 0; 

		SET @TeamOne = (SELECT PlaysOff.WinnerFK
						FROM PlaysOff
						WHERE PlaysOff.ID = @j)
		SET @GolsOne = (SELECT CAST((0 + RAND() * 3) AS INT));
		SET @TeamSecond = (SELECT PlaysOff.WinnerFK
						FROM PlaysOff
						WHERE PlaysOff.ID = @j + 1)
		SET @GolsSecond = (SELECT CAST((0 + RAND() * 3) AS INT));
		IF @GolsOne = @GolsSecond
		BEGIN
			SET @Overtime = 1;
			SET @GolsOneOvertime = (SELECT CAST((0 + RAND() * 2) AS INT));
			SET @GolsSecondOvertime = (SELECT CAST((0 + RAND() * 2) AS INT));
			IF  @GolsOneOvertime = @GolsSecondOvertime
			BEGIN
				SET @Pendels = 1;
				WHILE @PendelsOne != @PendelsSecond
				BEGIN
					SET @PendelsOne = (SELECT CAST((0 + RAND() * 5) AS INT));
					SET @PendelsSecond = (SELECT CAST((0 + RAND() * 5) AS INT));
				END;
				IF @PendelsOne > @PendelsSecond
				SET @Winner =  @TeamOne;
				ELSE
				SET @Winner = @TeamSecond;
			END;
		END;
		IF @Winner = 0
		BEGIN
			IF @GolsOne + @GolsOneOvertime > @GolsSecond + @GolsSecondOvertime
			SET @Winner =  @TeamOne;
			ELSE
			SET @Winner = @TeamSecond;
		END;

		INSERT INTO PlaysOff (TeamOffFirstFK, TeamOffSecondFK, FormFirstTeamFK, FormSecondTeamFK, StadiumFK, RefereesInPlayFK, [PlayDate], Overtime, Pendels, TeamsFirstResult, TeamsSecondResult, WinnerFK)
		VALUES (@TeamOne, @TeamSecond, (SELECT CAST((1 + RAND() * 19)AS INT)), (SELECT CAST((1 + RAND() * 19)AS INT)), (SELECT CAST((1 + RAND() * 9)AS INT)),  (SELECT CAST((1 + RAND() * 15)AS INT)), @PlayDate, @Overtime, @Pendels, @GolsOne + @GolsOneOvertime, @GolsSecond + @GolsSecondOvertime, @Winner);

		SET @PlayDate = DATEADD(DAY, 3, @PlayDate);

		SET @i = @i + 1;
		SET @j = @j + 2;
		EXEC InsertGoolsQual @Gols = @GolsOne, @TeamFK = @TeamOne,  @StartTime  = 0, @EndTime  = 90;
		EXEC InsertGoolsQual @Gols = @GolsOneOvertime, @TeamFK = @TeamOne, @StartTime  = 91, @EndTime  = 120;
		EXEC InsertGoolsQual @Gols = @GolsSecond, @TeamFK = @TeamSecond, @StartTime  = 0, @EndTime  = 90;
		EXEC InsertGoolsQual @Gols = @GolsSecondOvertime, @TeamFK = @TeamSecond, @StartTime  = 91, @EndTime  = 120;
	END;
END
GO


IF EXISTS (SELECT * FROM sys.objects WHERE name = 'PlaceThird' AND type = 'P')
    DROP PROCEDURE PlaceThird;
GO

CREATE PROCEDURE PlaceThird
AS
BEGIN
	DECLARE @Winner INT;
	DECLARE @Overtime BIT;  ----------------------------------------
	DECLARE @Pendels BIT;   ----------------------------------------
	DECLARE @PendelsOne INT;  -----------------------------------
	DECLARE @PendelsSecond INT;  -------------------------------------
	DECLARE @PlayDate DATETIME = '11-19-19 15:00:00';    ---------------------------------------
	DECLARE @i INT;   --------------------------------------
	DECLARE @j INT;  -----------------------------------
	DECLARE @GolsOne INT;   -----------------------------------
	DECLARE @GolsSecond INT;   -----------------------------------
	DECLARE @GolsOneOvertime INT;    ---------------------------------
	DECLARE @GolsSecondOvertime INT;    -----------------------------------

	DECLARE @TeamOne INT;  -----------------------------------
	DECLARE @TeamSecond INT;   ---------------------------
	

	SET @Winner = 0;
	SET @Overtime = 0;  ----------------------------------------
	SET @Pendels = 0;  ------------------------------------------
	SET @PendelsOne = 0;  ----------------------------------------
	SET @PendelsSecond = 0;
	SET @GolsOne = 0;   --------
	SET @GolsSecond = 0;   -----
	SET @GolsOneOvertime = 0;   
	SET @GolsSecondOvertime = 0; 

	SET @TeamOne = (SELECT PlaysOff.TeamOffFirstFK
					FROM PlaysOff
					Where PlaysOff.ID = 13)
	IF @TeamOne = (SELECT PlaysOff.WinnerFK FROM PlaysOff WHERE PlaysOff.ID = 13)
	BEGIN
	SET @TeamOne = (SELECT PlaysOff.TeamOffSecondFK FROM PlaysOff WHERE PlaysOff.ID = 13);
	END;
	SET @GolsOne = (SELECT CAST((0 + RAND() * 3) AS INT));

	SET @TeamSecond = (SELECT PlaysOff.TeamOffFirstFK FROM PlaysOff WHERE PlaysOff.ID = 14);
	IF @TeamSecond = (SELECT PlaysOff.WinnerFK FROM PlaysOff WHERE PlaysOff.ID = 14)
	BEGIN
	SET @TeamSecond = (SELECT PlaysOff.TeamOffSecondFK FROM PlaysOff WHERE PlaysOff.ID = 14);
	END;
	SET @GolsSecond = (SELECT CAST((0 + RAND() * 3) AS INT));
	IF @GolsOne = @GolsSecond
	BEGIN
		SET @Overtime = 1;
		SET @GolsOneOvertime = (SELECT CAST((0 + RAND() * 2) AS INT));
		SET @GolsSecondOvertime = (SELECT CAST((0 + RAND() * 2) AS INT));
		IF  @GolsOneOvertime = @GolsSecondOvertime
		BEGIN
			SET @Pendels = 1;
			WHILE @PendelsOne != @PendelsSecond
			BEGIN
				SET @PendelsOne = (SELECT CAST((0 + RAND() * 5) AS INT));
				SET @PendelsSecond = (SELECT CAST((0 + RAND() * 5) AS INT));
			END;
			IF @PendelsOne > @PendelsSecond
			SET @Winner =  @TeamOne;
			ELSE
			SET @Winner = @TeamSecond;
		END;
	END;
	IF @Winner = 0
	BEGIN
		IF @GolsOne + @GolsOneOvertime > @GolsSecond + @GolsSecondOvertime
		SET @Winner =  @TeamOne;
		ELSE
		SET @Winner = @TeamSecond;
	END;

	INSERT INTO PlaysOff (TeamOffFirstFK, TeamOffSecondFK, FormFirstTeamFK, FormSecondTeamFK, StadiumFK, RefereesInPlayFK, [PlayDate], Overtime, Pendels, TeamsFirstResult, TeamsSecondResult, WinnerFK)
	VALUES (@TeamOne, @TeamSecond, (SELECT CAST((1 + RAND() * 19)AS INT)), (SELECT CAST((1 + RAND() * 19)AS INT)), (SELECT CAST((1 + RAND() * 9)AS INT)),  (SELECT CAST((1 + RAND() * 15)AS INT)), @PlayDate, @Overtime, @Pendels, @GolsOne + @GolsOneOvertime, @GolsSecond + @GolsSecondOvertime, @Winner);

	SET @PlayDate = DATEADD(DAY, 3, @PlayDate);

	SET @i = @i + 1;
	SET @j = @j + 2;
	EXEC InsertGoolsQual @Gols = @GolsOne, @TeamFK = @TeamOne,  @StartTime  = 0, @EndTime  = 90;
	EXEC InsertGoolsQual @Gols = @GolsOneOvertime, @TeamFK = @TeamOne, @StartTime  = 91, @EndTime  = 120;
	EXEC InsertGoolsQual @Gols = @GolsSecond, @TeamFK = @TeamSecond, @StartTime  = 0, @EndTime  = 90;
	EXEC InsertGoolsQual @Gols = @GolsSecondOvertime, @TeamFK = @TeamSecond, @StartTime  = 91, @EndTime  = 120;
END
GO

IF EXISTS (SELECT * FROM sys.objects WHERE name = 'GoolTeamsInPlayrs' AND type = 'P')
    DROP PROCEDURE GoolTeamsInPlayrs;
GO

CREATE PROCEDURE GoolTeamsInPlayrs
AS
BEGIN
	DECLARE @TeamsFK INT;
	DECLARE @TeamID INT;  -----------------------------------
	DECLARE @PlayrsFK INT;
	DECLARE @GoolCount INT;
	DECLARE @i INT;   --------------------------------------
	DECLARE @j INT;  -----------------------------------

	SET @i = 1;  -----------------------------
	SET @j = (SELECT COUNT(GoolsQual.ID) FROM GoolsQual); ----------------------------
	
	WHILE @i <= @j
	BEGIN 

		SET @TeamID = @i;
		SET @TeamsFK = (SELECT GoolsQual.TeamsFK FROM GoolsQual WHERE GoolsQual.ID = @i);
		SET @PlayrsFK = (SELECT CAST((4 + RAND() * 20)AS INT));
		SET @PlayrsFK = @TeamsFK * @PlayrsFK;
		SET @GoolCount = (SELECT PlayrsInTeam.GoolCount FROM PlayrsInTeam WHERE PlayrsInTeam.PlayrsFK = @PlayrsFK);

		UPDATE PlayrsInTeam SET GoolCount = @GoolCount + 1 WHERE PlayrsInTeam.PlayrsFK = @PlayrsFK
		
		SET @i = @i + 1;
	END;
END

EXEC PlaysInGroups @GroupsName = 'A'
EXEC PlaysInGroups @GroupsName = 'B'
EXEC PlaysInGroups @GroupsName = 'C'
EXEC PlaysInGroups @GroupsName = 'D'
EXEC PlaysInGroups @GroupsName = 'E'
EXEC PlaysInGroups @GroupsName = 'F'
EXEC PlaysInGroups @GroupsName = 'G'
EXEC PlaysInGroups @GroupsName = 'H'
GO

/*SELECT *
from GroupsPlays
SELECT *
from GoolsQual*/

EXEC InpupTablesPointInGroup
GO

INSERT INTO TeamsInPlayOff
			SELECT * FROM  fn_GetPlayOffTeams ('A');
INSERT INTO TeamsInPlayOff
			SELECT * FROM  fn_GetPlayOffTeams ('B');
INSERT INTO TeamsInPlayOff
			SELECT * FROM  fn_GetPlayOffTeams ('C');
INSERT INTO TeamsInPlayOff
			SELECT * FROM  fn_GetPlayOffTeams ('D');
INSERT INTO TeamsInPlayOff
			SELECT * FROM  fn_GetPlayOffTeams ('E');
INSERT INTO TeamsInPlayOff
			SELECT * FROM  fn_GetPlayOffTeams ('F');
INSERT INTO TeamsInPlayOff
			SELECT * FROM  fn_GetPlayOffTeams ('G');
INSERT INTO TeamsInPlayOff
			SELECT * FROM  fn_GetPlayOffTeams ('H');
GO

select*
from GoolsQual

select *
from PlayrsInTeam

EXEC Plays1In8
GO

EXEC QuarterFinal
GO

EXEC SemiFinalAndFinal
GO

EXEC PlaceThird
GO

EXEC GoolTeamsInPlayrs
GO