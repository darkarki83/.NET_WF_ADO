USE WorldCup
GO


-- 1) обцие количество голов забитых на чемпионате

SELECT COUNT(GoolsQual.ID)
FROM GoolsQual

-- 2) AVERAGE GOOL IN THE MATCH

SELECT (COUNT(GoolsQual.ID) / ((SELECT COUNT(GroupsPlays.ID) FROM GroupsPlays) + (SELECT COUNT(PlaysOff.ID) FROM PlaysOff)))
FROM GoolsQual

--  3) MAX and min
SELECT MAX(allGools.countG) AS MaxGools, MIN(allGools.countG) AS MinGols
fROM (SELECT COUNT(Teams.Name) AS countG
	  FROM GoolsQual, Teams
	  WHERE GoolsQual.TeamsFK = Teams.ID
      GROUP BY Teams.Name) AS allGools

--  4) MAX and min GOLS ѕ–ќѕ”ў≈Ќџ’
SELECT TOP(1)Teams.Name, SUM(AllGoolsGoiters.GoolsGoiters)AS GoolsGoiters
FROM (SELECT PointsInGroup.TeamsFK AS TeamsFK, PointsInGroup.YouGoiters AS GoolsGoiters
     fROM PointsInGroup
     UNION ALL
     SELECT PlaysOff.TeamOffFirstFK, PlaysOff.TeamsSecondResult
     fROM PlaysOff
     UNION ALL
     SELECT PlaysOff.TeamOffSecondFK, PlaysOff.TeamsFirstResult
     fROM PlaysOff) AS AllGoolsGoiters, Teams
WHERE Teams.ID = AllGoolsGoiters.TeamsFK
GROUP BY Teams.Name
ORDER BY SUM(AllGoolsGoiters.GoolsGoiters) DESC


SELECT TOP(1)Teams.Name, SUM(AllGoolsGoiters.GoolsGoiters) AS GoolsGoiters
FROM (SELECT PointsInGroup.TeamsFK AS TeamsFK, PointsInGroup.YouGoiters AS GoolsGoiters
     fROM PointsInGroup
     UNION ALL
     SELECT PlaysOff.TeamOffFirstFK, PlaysOff.TeamsSecondResult
     fROM PlaysOff
     UNION ALL
     SELECT PlaysOff.TeamOffSecondFK, PlaysOff.TeamsFirstResult
     fROM PlaysOff) AS AllGoolsGoiters, Teams
WHERE Teams.ID = AllGoolsGoiters.TeamsFK
GROUP BY Teams.Name
ORDER BY SUM(AllGoolsGoiters.GoolsGoiters)
--- 5) —”ћј–Ќјя ѕќ—≈ўј»ћќ—“№ ћј“„≈…
SELECT (GroupsSum.SumGroups + PlayOffSum.SumPlayOff) AS TotalAttendence
FROM
(SELECT SUM(CountS * Stadiums.SeatsInStadium) AS SumGroups 
FROM (SELECT GroupsPlays.StadiumFK AS StadiumID, COUNT(GroupsPlays.StadiumFK) AS CountS
		FROM GroupsPlays, Stadiums
		WHERE GroupsPlays.StadiumFK = Stadiums.ID
		GROUP BY GroupsPlays.StadiumFK) AS ALLs, Stadiums
		WHERE ALLs.StadiumID = Stadiums.ID) AS GroupsSum, (SELECT SUM(ALLo.CountS * Stadiums.SeatsInStadium) AS SumPlayOff
															FROM 
															(SELECT PlaysOff.StadiumFK AS StadiumID, count(PlaysOff.StadiumFK) AS CountS
															FROM PlaysOff, Stadiums
															WHERE PlaysOff.StadiumFK = Stadiums.ID
															GROUP BY PlaysOff.StadiumFK) AS  ALLo, Stadiums
															WHERE ALLo.StadiumID = Stadiums.ID) AS PlayOffSum


--- 6) средн€€ посещ€емость одного матча
SELECT (GroupsSum.SumGroups + PlayOffSum.SumPlayOff) / ((SELECT COUNT(GroupsPlays.ID) FROM GroupsPlays) + (SELECT COUNT(PlaysOff.ID) FROM PlaysOff))
FROM
(SELECT SUM(CountS * Stadiums.SeatsInStadium) AS SumGroups 
FROM (SELECT GroupsPlays.StadiumFK AS StadiumID, COUNT(GroupsPlays.StadiumFK) AS CountS
		FROM GroupsPlays, Stadiums
		WHERE GroupsPlays.StadiumFK = Stadiums.ID
		GROUP BY GroupsPlays.StadiumFK) AS ALLs, Stadiums
		WHERE ALLs.StadiumID = Stadiums.ID) AS GroupsSum, (SELECT SUM(ALLo.CountS * Stadiums.SeatsInStadium) AS SumPlayOff
															FROM 
															(SELECT PlaysOff.StadiumFK AS StadiumID, count(PlaysOff.StadiumFK) AS CountS
															FROM PlaysOff, Stadiums
															WHERE PlaysOff.StadiumFK = Stadiums.ID
															GROUP BY PlaysOff.StadiumFK) AS  ALLo, Stadiums
															WHERE ALLo.StadiumID = Stadiums.ID) AS PlayOffSum

--- 7) команда больше всего ¬ыигрывша€
SELECT TW.TeamsName, TW.CountWins--, MAX(TW.CountWins), MIN(TW.CountWins)
FROM
(SELECT Teams.Name AS TeamsName, SUM(TeamsFKAndWins.countS)AS CountWins
FROM
	(SELECT GroupsPlays.TeamsSecondFK as teamS, Count(GroupsPlays.TeamsSecondFK) as countS
	 FROM GroupsPlays
	 WHERE GroupsPlays.TeamsFirstResult < GroupsPlays.TeamsSecondResult
	 GROUP BY  GroupsPlays.TeamsSecondFK
     UNION all
     (SELECT GroupsPlays.TeamsFirstFK as teamO, Count(GroupsPlays.TeamsFirstFK)as countO
      FROM GroupsPlays
      WHERE GroupsPlays.TeamsFirstResult > GroupsPlays.TeamsSecondResult
      GROUP BY  GroupsPlays.TeamsFirstFK)
      UNION all	  
      (SELECT PlaysOff.WinnerFK as teamp, COUNT(PlaysOff.WinnerFK)as countP
      FROM PlaysOff
      GROUP BY PlaysOff.WinnerFK)) as TeamsFKAndWins, Teams
WHERE Teams.ID = TeamsFKAndWins.teamS
GROUP BY Teams.Name ) AS TW
WHERE TW.CountWins = (SELECT MAX( SSS.CountWins)
							FROM 
							(SELECT SUM(TeamsFKAndWins.countS)AS CountWins
					    	FROM
					 		(SELECT GroupsPlays.TeamsSecondFK as teamS, Count(GroupsPlays.TeamsSecondFK) as countS
					 		 FROM GroupsPlays
					 		 WHERE GroupsPlays.TeamsFirstResult < GroupsPlays.TeamsSecondResult
					 		 GROUP BY  GroupsPlays.TeamsSecondFK
					 	     UNION all
					 	     (SELECT GroupsPlays.TeamsFirstFK as teamO, Count(GroupsPlays.TeamsFirstFK)as countO
					 	      FROM GroupsPlays
					 	      WHERE GroupsPlays.TeamsFirstResult > GroupsPlays.TeamsSecondResult
					 	      GROUP BY  GroupsPlays.TeamsFirstFK)
					 	      UNION all	  
					 	      (SELECT PlaysOff.WinnerFK as teamp, COUNT(PlaysOff.WinnerFK)as countP
					 	      FROM PlaysOff
					 	      GROUP BY PlaysOff.WinnerFK)) as TeamsFKAndWins, Teams
					 	WHERE Teams.ID = TeamsFKAndWins.teamS
					 	GROUP BY Teams.Name) AS SSS)
						OR TW.CountWins = (SELECT MIN( SSS.CountWins)
							FROM 
							(SELECT SUM(TeamsFKAndWins.countS)AS CountWins
					    	FROM
					 		(SELECT GroupsPlays.TeamsSecondFK as teamS, Count(GroupsPlays.TeamsSecondFK) as countS
					 		 FROM GroupsPlays
					 		 WHERE GroupsPlays.TeamsFirstResult < GroupsPlays.TeamsSecondResult
					 		 GROUP BY  GroupsPlays.TeamsSecondFK
					 	     UNION all
					 	     (SELECT GroupsPlays.TeamsFirstFK as teamO, Count(GroupsPlays.TeamsFirstFK)as countO
					 	      FROM GroupsPlays
					 	      WHERE GroupsPlays.TeamsFirstResult > GroupsPlays.TeamsSecondResult
					 	      GROUP BY  GroupsPlays.TeamsFirstFK)
					 	      UNION all	  
					 	      (SELECT PlaysOff.WinnerFK as teamp, COUNT(PlaysOff.WinnerFK)as countP
					 	      FROM PlaysOff
					 	      GROUP BY PlaysOff.WinnerFK)) as TeamsFKAndWins, Teams
					 	WHERE Teams.ID = TeamsFKAndWins.teamS
					 	GROUP BY Teams.Name) AS SSS)

--ORDER BY SUM(TeamsFKAndWins.countS) DESC 
--UNION ALL
SELECT TOP(1) SUM(TeamsFKAndWins.countS)AS CountWins, Teams.Name AS TeamsName
FROM
	(SELECT GroupsPlays.TeamsSecondFK as teamS, Count(GroupsPlays.TeamsSecondFK) as countS
	 FROM GroupsPlays
	 WHERE GroupsPlays.TeamsFirstResult < GroupsPlays.TeamsSecondResult
	 GROUP BY  GroupsPlays.TeamsSecondFK
     UNION all
     (SELECT GroupsPlays.TeamsFirstFK as teamO, Count(GroupsPlays.TeamsFirstFK)as countO
      FROM GroupsPlays
      WHERE GroupsPlays.TeamsFirstResult > GroupsPlays.TeamsSecondResult
      GROUP BY  GroupsPlays.TeamsFirstFK)
      UNION all	  
      (SELECT PlaysOff.WinnerFK as teamp, COUNT(PlaysOff.WinnerFK)as countP
      FROM PlaysOff
      GROUP BY PlaysOff.WinnerFK)) as TeamsFKAndWins, Teams
WHERE Teams.ID = TeamsFKAndWins.teamS
GROUP BY Teams.Name
ORDER BY SUM(TeamsFKAndWins.countS) DESC

SELECT TOP(1) SUM(TeamsFKAndWins.countS)AS CountWins, Teams.Name AS TeamsName
FROM
	(SELECT GroupsPlays.TeamsSecondFK as teamS, Count(GroupsPlays.TeamsSecondFK) as countS
	 FROM GroupsPlays
	 WHERE GroupsPlays.TeamsFirstResult < GroupsPlays.TeamsSecondResult
	 GROUP BY  GroupsPlays.TeamsSecondFK
     UNION all
     (SELECT GroupsPlays.TeamsFirstFK as teamO, Count(GroupsPlays.TeamsFirstFK)as countO
      FROM GroupsPlays
      WHERE GroupsPlays.TeamsFirstResult > GroupsPlays.TeamsSecondResult
      GROUP BY  GroupsPlays.TeamsFirstFK)
      UNION all	  
      (SELECT PlaysOff.WinnerFK as teamp, COUNT(PlaysOff.WinnerFK)as countP
      FROM PlaysOff
      GROUP BY PlaysOff.WinnerFK)) as TeamsFKAndWins, Teams
WHERE Teams.ID = TeamsFKAndWins.teamS
GROUP BY Teams.Name
ORDER BY SUM(TeamsFKAndWins.countS) 

--- 8) команда больше всего ѕ–ќ»√–ј¬Ўјя
SELECT TOP (1) SUM(AAA.countS)AS CountS, Teams.Name AS TeamsName
       FROM
        (SELECT GroupsPlays.TeamsSecondFK as teamS, Count(GroupsPlays.TeamsSecondFK) as countS
       	 FROM GroupsPlays
       	 WHERE GroupsPlays.TeamsFirstResult > GroupsPlays.TeamsSecondResult
       	 GROUP BY  GroupsPlays.TeamsSecondFK
         UNION ALL
         (SELECT GroupsPlays.TeamsFirstFK as teamO, Count(GroupsPlays.TeamsFirstFK)as countO
          FROM GroupsPlays
          WHERE GroupsPlays.TeamsFirstResult < GroupsPlays.TeamsSecondResult
          GROUP BY  GroupsPlays.TeamsFirstFK)
          UNION ALL  
          (SELECT PlaysOff.TeamOffFirstFK AS teamp, COUNT(PlaysOff.TeamOffFirstFK)as countP
          FROM PlaysOff
       	  WHERE PlaysOff.TeamOffFirstFK != PlaysOff.WinnerFK
          GROUP BY PlaysOff.TeamOffFirstFK)
       	  UNION ALL
       	  (SELECT PlaysOff.TeamOffSecondFK AS teamp, COUNT(PlaysOff.TeamOffSecondFK)as countP
          FROM PlaysOff
       	  WHERE PlaysOff.TeamOffSecondFK != PlaysOff.WinnerFK
          GROUP BY PlaysOff.TeamOffSecondFK)) AS AAA, Teams
          WHERE Teams.ID = AAA.teamS
          GROUP BY Teams.Name
       ORDER BY SUM(AAA.countS) DESC

--- 9) лучшие бомбордиры
SELECT TOP(10) PlayrsInTeam.GoolCount, Playrs.Name
FROM PlayrsInTeam, Playrs
WHERE PlayrsInTeam.PlayrsFK = Playrs.ID
ORDER BY PlayrsInTeam.GoolCount DESC

--- 10) ѕјЅ≈ƒ»“≈Ћ»
SELECT Teams.Name
FROM (SELECT PlaysOff.WinnerFK AS TeamWinFK, NEWID()AS ID
      FROM PlaysOff
      WHERE PlaysOff.ID = 15
      UNION ALL
      SELECT PlaysOff.TeamOffFirstFK,  NEWID()
      FROM PlaysOff
      WHERE PlaysOff.ID = 15 AND PlaysOff.WinnerFK != PlaysOff.TeamOffFirstFK
      UNION ALL
      SELECT PlaysOff.TeamOffSecondFK,  NEWID()
      FROM PlaysOff
      WHERE PlaysOff.ID = 15 AND PlaysOff.WinnerFK != PlaysOff.TeamOffSecondFK
      UNION ALL
      SELECT PlaysOff.WinnerFK,  NEWID()
      FROM PlaysOff
      WHERE PlaysOff.ID = 16) AS Winners, Teams
WHERE Winners.TeamWinFK = Teams.ID

