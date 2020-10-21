create database my_guest_book
use my_guest_book;

CREATE TABLE my_enum ( f ENUM('show', 'hide') );

create table guest
(
	id_msg int primary key auto_increment,
    name varchar(30) not null,
    city varchar(50),
    email varchar(50),
    url varchar(80),
    msg varchar(100) not null,
    answer varchar(100),
    puttime datetime,
    hide enum('show', 'hide') default null
);

insert into guest value (1, "vseh lubluuuu", "ariel", null, null, " la la la tapalia ppp", null, null, 'show');
insert into guest value (2, "vseh lubluuuu2222", "ariel", null, null, " la ", null, null, 'show');
insert into guest value (3, "vseh lubluuuu3333", "ariel", null, null, " la la la i", null, null, 'show');
insert into guest value (4, "vseh lubluuuu4444", "ariel", null, null, " jjjjjjjjjj", null, null, 'show');
insert into guest value (null, "vseh lubluuuu55555", "ariel", null, null, " anjcbhvbf", null, null, 'show');
insert into guest value (null, "vseh lubluuuu6666", "ariel", null, null, " fffffffffff fffff", null, null, 'show');
insert into guest value (null, "vseh lubluuuu77777", "ariel", null, null, " 1234568798", null, null, 'show');


select g.id_msg, g.name, g.msg 
from guest g;


insert into authors value (1, 'Булгаков');


drop table guest;



