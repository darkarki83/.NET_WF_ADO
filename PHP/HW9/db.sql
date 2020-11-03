create database hotel_comments;
use hotel_comments;

create table hotels (
id int primary key auto_increment,
name varchar(30),
town varchar(30)
);


insert into hotels value(null, "Shavei shomron", "Ariel");
insert into hotels value(null, "City Towr", "Tel Aviv");
insert into hotels value(null, "Dan Ponorama", "Eilat");
insert into hotels value(null, "Dan", "Tel Aviv");
insert into hotels value(null, "Black Sea", "Odessa");

select hotels.name from hotels;

create table commets (
id int primary key auto_increment,
commet varchar(30),
hotels_fk int,

foreign key(hotels_fk) references hotels(id)
);

select * from commets;