use Books
go

--1. Вытащить название учебников, которые издавались не издательством 'BHV',
--   и тираж которых >= 3000 экземпляров.

select Name
from Books
where Izd like '%BHV%' AND Pressrun >= 3000;
go

--2. Вытащить книги, со дня издания которых прошло не более года.
--    Задать конкретную дату можно с помощью функции DATEFROMPARTS().

select *
from Books
where Date > DATEFROMPARTS(2002, 03, 13);
go

--3. Вытащить книги, о дате издания которых ничего не известно.

select * 
from Books 
where Date is null
order by Code desc;
go

--4. Вытащить все книги-новинки, цена которых ниже 30 грн.

select *
from Books
where Price < 30
order by Price;
go

--5. Вытащить книги, в названиях которых есть слово Microsoft, но нет слова Windows.

select * 
from Books
where Name Like '%Microsoft%' and Name not Like '%Windows%'
order by Pages;
go

--6. Вытащить книги, у которых цена одной страницы < 10 копеек.

select * 
from Books
where (Pages > 0 and (Price / Pages) < 0.10);
go

--7. Вытащить книги, в названиях которых присутствует как минимум одна цифра.

select * 
from Books
where Name Like '%[0-9]%';
go

--8. Вытащить книги, в названиях которых присутствует не менее трех цифр.

select * 
from Books
where Name Like '%[0-9]%[0-9]%[0-9]%';
go

--9. Вытащить книги, в названиях которых присутствует ровно пять цифр.

select * 
from Books
where Name Like '%[0-9]%[0-9]%[0-9]%[0-9]%[0-9]%' And Name not Like '%[0-9]%[0-9]%[0-9]%[0-9]%[0-9]%[0-9]%';
go

--10.	Удалить книги, в коде которых присутствует цифры 6 или 7.

Delete
from Books
where Name Like '%6%' Or Name Like '%7%';
go

--11.	Проставить текущую дату для тех книг, у которых дата издания отсутствует.
--      Tекущую дату можно получить с помощью функции GETDATE().

Update Books
set Date = GETDATE()
where Date Is Null;
go

select *
from Books
order by Date
go