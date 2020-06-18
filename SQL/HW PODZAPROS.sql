USE Library
GO

--1)
SELECT *
FROM Books B
WHERE B.Pages = (SELECT MAX(Pages) AS MaxPages
	FROM Books);

--2)
SELECT *
FROM Books B
WHERE B.Pages IN
(SELECT MAX(Pages) AS MaxPages
	FROM Books 
	WHERE Books.ThemeFk = (SELECT Themes.Id
	FROM Themes
	WHERE Themes.Name = N'Программирование'))

/*SELECT G.Name, COUNT(G.Name) AS GoToLib  -- количество студентов
	FROM Students S, Groups G                -- в каждой групе
	WHERE G.Id = S.GroupFk
	GROUP BY G.Name   */

--3. Вывести статистику посещений библиотеки по каждой группе студентов
SELECT G.Name, COUNT(SC.StudentFk) AS CounInGrupe
FROM Groups G , StudentCards SC, Students S
WHERE G.Id IN
	(SELECT S.GroupFk
	FROM StudentCards, Students S
	WHERE S.Id = StudentCards.StudentFk) AND S.Id = SC.StudentFk AND S.GroupFk = G.Id
GROUP BY G.Name



	SELECT COUNT(B.Id) AS CountBookFromLib, SUM(B.Pages) AS SumAllPages
	FROM StudentCards SC, Books B , Students S
	WHERE SC.StudentFk = S.Id AND SC.BookFk = B.Id  AND StudentFk IN 
		(SELECT Students.Id           --------   это все студенты на прогромирование
		FROM Students
		WHERE Students.GroupFk IN
			(SELECT Groups.Id
			FROM Groups
			WHERE Groups.FacultyFk = 
				(SELECT Faculties.Id
				FROM Faculties
				WHERE Faculties.Name = 'Программирования')))         -------    это все студенты на прогромирование
    AND SC.BookFk IN
		(SELECT B.Id
		FROM Books B
		WHERE B.ThemeFk IN
			(SELECT T.Id 
			FROM Themes T
			WHERE T.Name = N'Программирование' OR T.Name = N'Базы данных'))

--5. Допустим, что студент имеет право держать книгу у себя дома только 1 месяц,
--   а за каждую неделю сверх того он обязан «выставить» уважаемому библиотекарю Сергею Максименко
--    полбутылки (емкость бутылки 0.5 л) светлого пива. Необходимо вывести сколько литров
--    должен каждый студент, а также суммарное количество литров пива. Итоговая сумма должна
--   округляться в большую сторону, то есть суммарное число литров должно быть целым.
--    Используйте функции DATEDIFF и CAST.
(SELECT DATEDIFF(MM, SC.DateOut,  CAST(COALESCE (SC.DateIn , GETDATE()) AS datetime))   
                 FROM StudentCards SC)  -- разница в месяцах между взятием книги

--Update StudentCards
--SET DateIn = GETDATE()
--WHERE DateIn Is Null

SELECT CAST(SUM(DATEDIFF(WK, SC.DateOut,  CAST(COALESCE (SC.DateIn , GETDATE()) AS datetime)) - 4) * 0.5 AS INT) AS TotalMonth	
FROM StudentCards SC, Students S
WHERE SC.StudentFk = S.Id AND (DATEDIFF(WK, SC.DateOut,  CAST(COALESCE (SC.DateIn , GETDATE()) AS datetime)) - 4) > 0
GO

--  6. Если считать общее количество книг в библиотеке за 100%, то необходимо подсчитать
--  сколько книг (в процентном отношении) брал каждый факультет.

	SELECT F.Name, (COUNT(F.Name) * 100 / (SELECT COUNT(Books.ID) FROM Books))
	FROM StudentCards SC, Books B , Students S, Groups G, Faculties F
	WHERE SC.StudentFk = S.Id AND SC.BookFk = B.Id AND G.FacultyFk = F.Id AND G.Id = S.GroupFk AND StudentFk IN 
		(SELECT Students.Id           --------   это все студенты на прогромирование
		FROM Students
		WHERE Students.GroupFk IN
			(SELECT G.Id
			FROM Groups G
			WHERE G.FacultyFk IN
				(SELECT F.Id
				FROM Faculties F)))
	GROUP BY F.Name

-- 7. Вывести самого популярного автора(ов) среди студентов.

	SELECT A.LastName ,COUNT(A.LastName) AS BookThisAuthor--, A.FirstName
	FROM Authors A, Books B, StudentCards SC
	WHERE SC.BookFk = B.Id AND A.Id = B.AuthorFk AND A.Id IN 
		(SELECT B.AuthorFk
		FROM Books B
		WHERE B.Id IN
			(SELECT SC.BookFk
			FROM StudentCards SC))
	GROUP BY A.LastName
	HAVING COUNT(A.LastName) = 2

--8. Вывести самого популярного автора(ов) среди преподавателей и количество книг
--   этого автора, взятых в библиотеке.

SELECT A.LastName ,COUNT(A.LastName) AS BookThisAuthor--, A.FirstName
	FROM Authors A, Books B, TeacherCards TC
	WHERE TC.BookFk = B.Id AND A.Id = B.AuthorFk AND A.Id IN 
		(SELECT B.AuthorFk
		FROM Books B
		WHERE B.Id IN
			(SELECT TC.BookFk
			FROM TeacherCards TC))
	GROUP BY A.LastName

--9. Вывести самого популярную(ые) тематику(и) среди студентов и преподавателей.

SELECT T.Name ,COUNT(T.Name) AS BookThisAuthor--, A.FirstName
	FROM Themes T, Books B--, TeacherCards TC
	WHERE T.Id = B.ThemeFk AND 
		B.Id  IN (SELECT TC.BookFk
						FROM TeacherCards TC)
			OR T.Id = B.ThemeFk AND B.Id IN	
					(SELECT SC.BookFk
					FROM StudentCards SC)
GROUP BY T.Name
			
--10. «Заставить» сдать книги тех студентов, которые не сдавали книги более года,
--    т.е. в таблице «Карточка студентов» (StudentCards) заполнить поле «Дата возврата»
--   (DateIn) текущей датой.

Update StudentCards
SET DateIn = GETDATE()
WHERE DateIn Is Null AND (DATEDIFF(Y, StudentCards.DateOut,  CAST(COALESCE (StudentCards.DateIn , GETDATE()) AS datetime))) > 1

SELECT *
FROM StudentCards


--11.	Удалить из таблицы «Карточка студентов» студентов, которые уже вернули книги.

DELETE
FROM StudentCards
WHERE DateIn IS NOT Null
