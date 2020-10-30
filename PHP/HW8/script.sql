create database internet_vote;
use internet_vote;


create table vote
(
	id int primary key auto_increment,
    name varchar(50) not null,
    votes_count int not null default 0
);

insert into vote value (1, "Oleg Blohin", 0);
insert into vote value (null, "Uri Kaletvinjev", 0);
insert into vote value (null, "Mircha Lechesku", 0);
insert into vote value (null, "Miron Markevich", 0);
insert into vote value (null, "Alexei Mihailichenkov", 0);
insert into vote value (null, "Pavel Iakovenko", 0);
insert into vote value (null, "Another domestic coach", default);
insert into vote value (null, "Foreign coach", default);

SHOW COLUMNS FROM vote;
select *
from vote v;

drop table vote;






