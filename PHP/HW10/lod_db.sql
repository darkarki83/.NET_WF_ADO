create database my_account;
use my_account;

create table acc (
id int primary key auto_increment,
login varchar(30) unique,
pass varchar(50)
);


insert into acc value(null, "a", "1");
insert into acc value(null, "ar", "qq");
insert into acc value(null, "aqqq", "1qq");
insert into acc value(null, "artt", "qq");

select acc.login, acc.pass from acc;

