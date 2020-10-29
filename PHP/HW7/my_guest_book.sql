create database my_guest_book
use my_guest_book;


create table guest
(
	id_msg int primary key auto_increment,
    name varchar(30) not null,
    city varchar(50),
    email varchar(50),
    url varchar(80),
    msg varchar(100) not null,
    puttime datetime,
    hide enum('show', 'hide'),
    answer varchar(100)
);

insert into guest value (1, "vseh lubluuuu", "ariel", null, null, " la la la tapalia ppp", null, 'show', null);
insert into guest value (2, "vseh lubluuuu2222", "ariel", null, null, " la ", null, 'show', null);
insert into guest value (3, "vseh lubluuuu3333", "ariel", null, null, " la la la i", null, null, null);
insert into guest value (4, "vseh lubluuuu4444", "ariel", null, null, " jjjjjjjjjj", null, null, null);
insert into guest value (null, "vseh lubluuuu55555", "ariel", null, null, " anjcbhvbf", null, null, null);
insert into guest value (null, "vseh lubluuuu6666", "ariel", null, null, " fffffffffff fffff", null, null, null);
insert into guest value (null, "vseh lubluuuu77777", "ariel", null, null, " 1234568798", null, null, null);


insert into guest values(null,'$name', '$city', '$email', '$url', '$msg', 'show', null  ,null);

SHOW COLUMNS FROM guest;
select *
from guest g;

update  guest set answer = "artem" where id_msg = 2;
update guest set answer = '4teeeeeeee' where id_msg = 12;
delete from guest where id_msg = 1;

drop table guest;

drop TABLE my_enum;

