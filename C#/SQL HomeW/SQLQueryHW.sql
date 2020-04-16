use Books
go

--1. �������� �������� ���������, ������� ���������� �� ������������� 'BHV',
--   � ����� ������� >= 3000 �����������.

select Name
from Books
where Izd like '%BHV%' AND Pressrun >= 3000;
go

--2. �������� �����, �� ��� ������� ������� ������ �� ����� ����.
--    ������ ���������� ���� ����� � ������� ������� DATEFROMPARTS().

select *
from Books
where Date > DATEFROMPARTS(2002, 03, 13);
go

--3. �������� �����, � ���� ������� ������� ������ �� ��������.

select * 
from Books 
where Date is null
order by Code desc;
go

--4. �������� ��� �����-�������, ���� ������� ���� 30 ���.

select *
from Books
where Price < 30
order by Price;
go

--5. �������� �����, � ��������� ������� ���� ����� Microsoft, �� ��� ����� Windows.

select * 
from Books
where Name Like '%Microsoft%' and Name not Like '%Windows%'
order by Pages;
go

--6. �������� �����, � ������� ���� ����� �������� < 10 ������.

select * 
from Books
where (Pages > 0 and (Price / Pages) < 0.10);
go

--7. �������� �����, � ��������� ������� ������������ ��� ������� ���� �����.

select * 
from Books
where Name Like '%[0-9]%';
go

--8. �������� �����, � ��������� ������� ������������ �� ����� ���� ����.

select * 
from Books
where Name Like '%[0-9]%[0-9]%[0-9]%';
go

--9. �������� �����, � ��������� ������� ������������ ����� ���� ����.

select * 
from Books
where Name Like '%[0-9]%[0-9]%[0-9]%[0-9]%[0-9]%' And Name not Like '%[0-9]%[0-9]%[0-9]%[0-9]%[0-9]%[0-9]%';
go

--10.	������� �����, � ���� ������� ������������ ����� 6 ��� 7.

Delete
from Books
where Name Like '%6%' Or Name Like '%7%';
go

--11.	���������� ������� ���� ��� ��� ����, � ������� ���� ������� �����������.
--      T������ ���� ����� �������� � ������� ������� GETDATE().

Update Books
set Date = GETDATE()
where Date Is Null;
go

select *
from Books
order by Date
go