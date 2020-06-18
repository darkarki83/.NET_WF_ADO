

-- 8.Найти авторов, которые живут в тех странах, где есть хотя бы один из магазинов по распространению книг,
-- занесенных в БД. Результат запроса разместить в отдельные представления.

CREATE VIEW AutorsFromCountryWhereShop
AS
SELECT A.FirstName, A.LastName, C.NAME
FROM Authors A, Contry C
WHERE A.ContryFK = C.Id AND  A.ContryFK IN (SELECT ContryFK
											FROM Shop)

SELECT * 
FROM AutorsFromCountryWhereShop

--9. Написать представления, которые содержат самую дорогую книгу тематики, 
-- например, "программирование".

CREATE VIEW BookMaxPages
AS
SELECT * 
FROM (SELECT *
FROM Books B
WHERE B.ThemeFk = (SELECT Id
			FROM Themes
			WHERE Themes.Name = N'Программирование'))  BBB
WHERE BBB.Pages = (SELECT MAX(B.Pages)
FROM Books B
WHERE B.ThemeFk = (SELECT Id
			FROM Themes
			WHERE Themes.Name = N'Программирование'))

SELECT *
FROM BookMaxPages

--10. Написать представление, которое позволяет вывести всю информацию про работу магазинов. 
--Отсортировать выборку по странам в возрастающем и по названиям магазинов в спадающем порядке.

CREATE VIEW ShopSortedByContry
AS
SELECT Shop.NAME AS SHOPNAME  , Contry.NAME AS CONTRYNAME
FROM Shop, Contry
WHERE Shop.ContryFK = Contry.Id

SELECT *
FROM ShopSortedByContry S
ORDER BY S.CONTRYNAME, S.SHOPNAME

--11. Написать зашифрованное представление, которое показывает самую популярную книгу.
SELECT B.Id, COUNT(B.Id)
FROM Books B, StudentCards SC, TeacherCards TC
WHERE B.Id IN (SELECT  SC.BookFk
				FROM StudentCards SC
				) AND B.Id = SC.BookFk OR (B.Id IN (SELECT TC.BookFk
												FROM TeacherCards TC) AND TC.BookFk = B.Id)  AND SC.BookFk = TC.BookFk
GROUP BY B.Id
HAVING COUNT(B.NAME) > 1


SELECT BBB.BookFk, COUNT(BBB.BookFk) AS RESULT
FROM 
	(SELECT TC.BookFk
	FROM TeacherCards TC
	UNION ALL
	SELECT  SC.BookFk
	FROM StudentCards SC) BBB
GROUP BY BBB.BookFk
HAVING COUNT(BBB.BookFk) = MAX(SELECT COUNT(AAA.BookFk)
								FROM
								(SELECT TC.BookFk
	                             FROM TeacherCards TC
	                             UNION ALL
	                             SELECT  SC.BookFk
	                             FROM StudentCards SC) AAA
								 GROUP BY AAA.BookFk)

	SELECT MAX(Result.BookThisAuthor)
    FROM 
    (SELECT COUNT(A.LastName) AS BookThisAuthor--, A.FirstName
    	FROM Authors A, Books B, TeacherCards TC
    	WHERE TC.BookFk = B.Id AND A.Id = B.AuthorFk AND A.Id IN 
    		(SELECT B.AuthorFk
    		FROM Books B
    		WHERE B.Id IN
    			(SELECT TC.BookFk
    			FROM TeacherCards TC))
    	GROUP BY A.LastName) Result


--12. Написать модифицированное представление, 
-- в котором предоставляется информация об авторах, имена которых начинаются на А или В.
CREATE VIEW AuthorsNameStart
AS
SELECT A.FirstName, A.LastName, C.NAME
FROM Authors A, Contry C
WHERE (A.FirstName LIKE N'А%' OR A.FirstName LIKE N'Б%') AND A.ContryFK = C.Id
GO

SELECT *
FROM AuthorsNameStart


--13. Написать представление, в котором с помощью подзапросов вывести названия магазинов,
--которые еще не продают книги вашего издательства.
CREATE VIEW ShopsNotYeatSell
AS
SELECT * 
FROM Shop S
WHERE S.Id NOT IN
(SELECT S.Id
FROM Shop S
WHERE S.Id IN (SELECT BS.ShopFK
                FROM BooksInShop BS
                WHERE BS.Id IN (SELECT B.Id
                                FROM Books B
                                WHERE B.PressFk = (SELECT  P.Id
                                				   FROM Presses P
                                				   WHERE P.Name = N'BHV'))))


SELECT *
FROM ShopsNotYeatSell
